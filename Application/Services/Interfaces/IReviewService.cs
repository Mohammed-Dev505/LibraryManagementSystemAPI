

using LibraryManagementSystemAPI.Application.DTOs;
using LibraryManagementSystemAPI.Application.Models;

namespace LibraryManagementSystemAPI.Application.Services.Interfaces
{
    public interface IReviewService
    {
        Task<ReviewDto> CreateAsync(CreateReviwDto dto , string userId);
        Task<bool> UpdateAsync(Guid id , UpdateReviewDto dto , string userId);
        Task<PagedResult<ReviewDto>> GetByBookAsync(Guid bookId , PaginationParams parameters);
    }
}
