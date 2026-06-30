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
    public class ReviewService : IReviewService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ReviewService(IUnitOfWork unitOfWorkt, IMapper mapper)
        {
            _unitOfWork = unitOfWorkt;
            _mapper = mapper;
        }
        public async Task<ReviewDto> CreateAsync(CreateReviwDto dto , string userId)
        {
            var review = _mapper.Map<Review>(dto);
            review.UserId = userId;

            await _unitOfWork.Repository<Review>().AddAsync(review);

            var saveResult = await _unitOfWork.CompleteAsync();
            if (saveResult < 1)
                throw new BadRequestException("Failed to save your review.");

            return _mapper.Map<ReviewDto>(review);
        }

        public async Task<PagedResult<ReviewDto>> GetByBookAsync(Guid bookId , PaginationParams pagination)
        {
            int skip = (pagination.PageNumber - 1) * pagination.PageSize;
            int take = pagination.PageSize;

            Expression<Func<Review, bool>> filter = r => r.BookId == bookId;

            var reviewRepo = _unitOfWork.Repository<Review>();

            var review = await reviewRepo.GetPagedResultAsync(filter, skip, take);
            int totalCount = await reviewRepo.CountAsync(filter);

            var reviewDto = _mapper.Map<IEnumerable<ReviewDto>>(review);

            return new PagedResult<ReviewDto>
            {
                Data = reviewDto.ToList(),
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize,
                TotalCount = totalCount
            };
        }

        public async Task<bool> UpdateAsync(Guid id , UpdateReviewDto dto , string userId)
        {
            var reviewRepo = _unitOfWork.Repository<Review>();
            var review = await reviewRepo.FindAsync(r => r.Id == id && r.UserId == userId);

            if (review is null)
                throw new NotFoundException("Review not found or you don't have permission to modify it.");

            review.Rating = dto.Rating;
            review.Comment = dto.Comment;

            reviewRepo.Update(review);

            var saveResult = await _unitOfWork.CompleteAsync();

            if (saveResult < 1)
                throw new BadRequestException("Failed to update your review.");
            return true;
        }
    }
}
