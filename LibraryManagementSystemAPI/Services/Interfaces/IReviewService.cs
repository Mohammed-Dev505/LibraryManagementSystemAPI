using Trining_RESTApi.DTOs;

namespace Trining_RESTApi.Services.Interfaces
{
    public interface IReviewService
    {
        Task<ReviewDto> CreateAsync(CreateReviwDto dto , string userId);
        Task<bool> UpdateAsync(UpdateReviewDto dto);
        Task<IEnumerable<ReviewDto>> GetByBookAsync(int bookId);
    }
}
