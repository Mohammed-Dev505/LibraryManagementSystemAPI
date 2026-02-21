using AutoMapper;
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
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
            return _mapper.Map<AuthorDto>(author);
        }

        public async Task<bool> DeleteAuthorAsync(int id)
        {
           var author = await _context.Authors.FindAsync(id);
            if (author == null) return false;
            _context.Remove(author);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync()
        {
            var authors = await _context.Authors.AsNoTracking().ToListAsync();
            return _mapper.Map<List<AuthorDto>>(authors);
        }

        public async Task<AuthorDto?> GetAuthorByIdAsync(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if(author == null) return null;
            return _mapper.Map<AuthorDto>(author);
        }

        public async Task<bool> UpdateAuthorAsync(UpdateAuthorDto dto)
        {
            var author = await _context.Authors.FindAsync(dto.Id);
            if (author == null) return false;
            author.Name = dto.Name;
            author.Biography = dto.Biography;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
