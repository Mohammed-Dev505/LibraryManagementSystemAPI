using AutoMapper;
using LibraryManagementSystemAPI.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Trining_RESTApi.Data;
using Trining_RESTApi.Data.Models;
using Trining_RESTApi.DTOs;
using Trining_RESTApi.Services.Interfaces;

namespace Trining_RESTApi.Services.Implementaions
{
    public class BookService : IBookService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public BookService(AppDbContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<BookDto?> CreateAsync(CreateBookDto dto)
        {
           var book = _mapper.Map<Book>(dto);
            if (book == null) throw new BadRequestException($"Falid to map book from the provided data");
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return _mapper.Map<BookDto>(book);
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) throw new NotFoundException($"Book with ID {id} not found");
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<BookDto>> GetAllAsync()
        {
            var books = await _context.Books.Include(a => a.Author).AsNoTracking().ToListAsync();
            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

        public async Task<BookDto?> GetByIdAsync(int id)
        {
            var book = await _context.Books.Include(a => a.Author).AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
            if (book == null) throw new NotFoundException($"Book with ID {id} not found");
            return book == null ? null : _mapper.Map<BookDto>(book);
        }

        public async Task<bool> UpdateAsync(UpdateBookDto dto)
        {
            var book = await _context.Books.FindAsync(dto.Id);
            if (book == null) throw new NotFoundException($"Book with ID {dto.Id} not found");
            _mapper.Map(dto, book);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
