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
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BookService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BookDto> CreateAsync(CreateBookDto dto)
        {
            var book = _mapper.Map<Book>(dto);
            await _unitOfWork.Repository<Book>().AddAsync(book);

            var saveResult = await _unitOfWork.CompleteAsync();
            if (saveResult < 1)
                throw new BadRequestException("Failed to create the book record.");

            return _mapper.Map<BookDto>(book);
        }

        public async Task<bool> DeleteBookAsync(Guid id)
        {
            var bookRepo = _unitOfWork.Repository<Book>();
            var book = await bookRepo.GetByIdAsync(id);

            if (book is null)
                throw new NotFoundException("No book found with the provided ID.");

            bookRepo.Delete(book);

            var saveResult = await _unitOfWork.CompleteAsync();
            if (saveResult < 1)
                throw new BadRequestException("Failed to delete the book record.");

            return true;
        }

        public async Task<PagedResult<BookDto>> GetAllAsync(BookParams pagination)
        {
            int skip = (pagination.PageNumber - 1) * pagination.PageSize;
            int take = pagination.PageSize;

            Expression<Func<Book, bool>> filter = b => (string.IsNullOrEmpty(pagination.AuthorName) || b.Author.Name.Contains(pagination.AuthorName)) && (string.IsNullOrEmpty(pagination.Title) || b.Title.Contains(pagination.Title));

            var bookRepo = _unitOfWork.Repository<Book>();

            var book = await bookRepo.GetPagedResultAsync(filter, skip, take);
            int totalCount = await bookRepo.CountAsync(filter);

            var bookDto = _mapper.Map<IEnumerable<BookDto>>(book);

            return new PagedResult<BookDto>
            {
                Data = bookDto.ToList(),
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize,
                TotalCount = totalCount
            };
        }

        public async Task<BookDto> GetByIdAsync(Guid id)
        {
           var book = await _unitOfWork.Repository<Book>().GetByIdAsync(id);

            if (book is null)
                throw new NotFoundException("No book found with the provided ID.");

            return _mapper.Map<BookDto>(book);
        }

        public async Task<bool> UpdateAsync(Guid id , UpdateBookDto dto)
        {
            var bookRepo = _unitOfWork.Repository<Book>();
            var book = await bookRepo.GetByIdAsync(id);

            if (book is null)
                throw new NotFoundException("No book found with the provided ID.");

            book.Title = dto.Title ?? book.Title;
            book.Description = dto.Description ?? book.Description;
            book.CopiesAvailable = dto.CopiesAvailable ?? book.CopiesAvailable;

            bookRepo.Update(book);

            var saveResult = await _unitOfWork.CompleteAsync();
            if (saveResult < 1)
                throw new BadRequestException("Failed to update the book details.");

            return true;
        }
    }
}
