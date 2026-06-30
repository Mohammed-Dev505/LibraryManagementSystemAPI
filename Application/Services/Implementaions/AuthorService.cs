using Application.Services.Interfaces;
using AutoMapper;
using LibraryManagementSystemAPI.Application.DTOs;
using LibraryManagementSystemAPI.Application.Exceptions;
using LibraryManagementSystemAPI.Application.Models;
using LibraryManagementSystemAPI.Application.Services.Interfaces;
using LibraryManagementSystemAPI.Domain.Entities;
using System.Linq.Expressions;

namespace LibraryManagementSystemAPI.Application.Services.Implementaions
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AuthorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AuthorDto> CreateAuthorAsync(CreateAuthorDto dto)
        {
            var author = _mapper.Map<Author>(dto);

            await _unitOfWork.Repository<Author>().AddAsync(author);

            var saveResult = await _unitOfWork.CompleteAsync();
            if (saveResult < 1)
                throw new BadRequestException("Failed to create the author record.");

            return _mapper.Map<AuthorDto>(author);
        }

        public async Task<bool> DeleteAuthorAsync(Guid id)
        {
            var authorRepo = _unitOfWork.Repository<Author>();
            var author = await authorRepo.GetByIdAsync(id);

            if (author is null)
                throw new NotFoundException("No author found with the provided ID.");

            authorRepo.Delete(author);

            var saveResult = await _unitOfWork.CompleteAsync();

            if (saveResult < 1)
                throw new BadRequestException("Failed to delete the author record.");

            return true;
        }

        public async Task<PagedResult<AuthorDto>> GetAllAsync(AuthorParams pagination)
        {
            int skip = (pagination.PageNumber - 1) * pagination.PageSize;
            int take = pagination.PageSize;

            Expression<Func<Author, bool>> filter = a => string.IsNullOrEmpty(pagination.AuthorName) ||  a.Name.Contains(pagination.AuthorName);

            var authroRepo = _unitOfWork.Repository<Author>();

            var authors = await authroRepo.GetPagedResultAsync(filter, skip, take);

            int totalCount = await authroRepo.CountAsync(filter);


            var authorDto = _mapper.Map<IEnumerable<AuthorDto>>(authors);

            return new PagedResult<AuthorDto>
            {
                Data = authorDto.ToList(),
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize,
                TotalCount = totalCount
            };
        }

        public async Task<AuthorDto> GetAuthorByIdAsync(Guid id)
        {
            var author = await _unitOfWork.Repository<Author>().GetByIdAsync(id);

            if (author is null)
                throw new NotFoundException("No author found with the provided ID.");

            return _mapper.Map<AuthorDto>(author);
        }

        public async Task<bool> UpdateAuthorAsync(Guid id , UpdateAuthorDto dto)
        {
            var authorRepo = _unitOfWork.Repository<Author>();
            var author = await authorRepo.GetByIdAsync(id);

            if (author is null)
                throw new NotFoundException("No author found with the provided ID.");

            author.Name = dto.Name ?? author.Name;
            author.Biography = dto.Biography ?? author.Biography;

            authorRepo.Update(author);

            var saveResult = await _unitOfWork.CompleteAsync();
            if (saveResult < 1)
                throw new BadRequestException("Failed to update the author details."); 
            return true;

        }
    }
}
