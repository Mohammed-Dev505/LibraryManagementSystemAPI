using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Trining_RESTApi.Data;
using Trining_RESTApi.Data.Models;
using Trining_RESTApi.DTOs;
using Trining_RESTApi.Services.Interfaces;

namespace Trining_RESTApi.Services.Implementaions
{
    public class ReviewService : IReviewService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ReviewService(AppDbContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ReviewDto> CreateAsync(CreateReviwDto dto)
        {
            var review = _mapper.Map<Review>(dto);
            await _context.Reviews.AddAsync(review);
            await _context.SaveChangesAsync();
            return _mapper.Map<ReviewDto>(review);
        }

        public async Task<IEnumerable<ReviewDto>> GetByBookAsync(int bookId)
        {
            var review = await _context.Reviews.Where(a => a.BookId ==  bookId).Include(a => a.User).Include(a => a.Book).ThenInclude(a => a.Author).AsNoTracking().ToListAsync();
            return _mapper.Map<List<ReviewDto>>(review);
        }

        public async Task<bool> UpdateAsync(UpdateReviewDto dto)
        {
            var reviw = await _context.Reviews.FindAsync(dto.Id);
            if(reviw == null) return false;
            reviw.Rating = dto.Rating;
            reviw.Comment = dto.Comment;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
