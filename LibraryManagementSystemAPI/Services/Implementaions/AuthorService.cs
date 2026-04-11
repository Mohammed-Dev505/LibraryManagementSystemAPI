using AutoMapper;
using LibraryManagementSystemAPI.Data.Models;
using LibraryManagementSystemAPI.Exceptions;
using LibraryManagementSystemAPI.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;
using Trining_RESTApi.Data;
using Trining_RESTApi.Data.Models;
using Trining_RESTApi.DTOs;
using Trining_RESTApi.Services.Interfaces;

namespace Trining_RESTApi.Services.Implementaions
{
    public class AuthorService : IAuthorService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public AuthorService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AuthorDto> CreateAuthorAsync(CreateAuthorDto dto)
        {
            var author = _mapper.Map<Author>(dto);
            if(author == null) throw new BadRequestException($"Falid to map author from the provided data");
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
            return _mapper.Map<AuthorDto>(author);
        }

        public async Task<bool> DeleteAuthorAsync(int id)
        {
           var author = await _context.Authors.FindAsync(id);
            if (author == null) throw new NotFoundException($"Author with ID {id} not found");
            _context.Remove(author);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<PagedResult<AuthorDto>> GetAllAsync(AuthorParams pagination)
        {
            var query = _context.Authors.AsNoTracking().AsQueryable();
            if (!string.IsNullOrEmpty(pagination.Search))
                query = query.Where(a => a.Name.Contains(pagination.Search));
            var pagedAuthors = await query.ToPagedResultAsync(pagination.PageNumber, pagination.PageSize);
            return new PagedResult<AuthorDto>
            {
                Data = _mapper.Map<IEnumerable<AuthorDto>>(pagedAuthors.Data),
                PageNumber = pagedAuthors.PageNumber,
                PageSize = pagedAuthors.PageSize,
                TotalCount = pagedAuthors.TotalCount,
                TotalPages = pagedAuthors.TotalPages
            };
        }

        public async Task<AuthorDto?> GetAuthorByIdAsync(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if(author == null) throw new NotFoundException($"Author with ID {id} not found");
            return _mapper.Map<AuthorDto>(author);
        }

        public async Task<bool> UpdateAuthorAsync(UpdateAuthorDto dto)
        {
            var author = await _context.Authors.FindAsync(dto.Id);
            if (author == null) throw new NotFoundException($"Author with ID {dto.Id} not found");
            author.Name = dto.Name;
            author.Biography = dto.Biography;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
