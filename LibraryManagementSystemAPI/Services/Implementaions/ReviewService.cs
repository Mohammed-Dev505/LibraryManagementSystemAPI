using AutoMapper;
using LibraryManagementSystemAPI.Exceptions;
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
        public async Task<ReviewDto> CreateAsync(CreateReviwDto dto , string userId)
        {
            var review = _mapper.Map<Review>(dto);
            if (review == null) throw new BadRequestException("Falid to map review the provided data"); 
            review.UserId = userId;
            await _context.Reviews.AddAsync(review);
            await _context.SaveChangesAsync();
            return _mapper.Map<ReviewDto>(review);
        }

        public async Task<IEnumerable<ReviewDto>> GetByBookAsync(int bookId)
        {
            var review = await _context.Reviews.Where(a => a.BookId ==  bookId).Include(a => a.User).Include(a => a.Book).ThenInclude(a => a.Author).AsNoTracking().ToListAsync();
            if (review == null || review.Count < 1) throw new NotFoundException($"Review with BookID {bookId} not found");
            return _mapper.Map<List<ReviewDto>>(review);
        }

        public async Task<bool> UpdateAsync(UpdateReviewDto dto)
        {
            var review = await _context.Reviews.FindAsync(dto.Id);
            if (review == null) throw new NotFoundException($"Review with ID {dto.Id} not found");
            review.Rating = dto.Rating;
            review.Comment = dto.Comment;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
