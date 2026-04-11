using LibraryManagementSystemAPI.Data.Models;
using Trining_RESTApi.DTOs;

namespace Trining_RESTApi.Services.Interfaces
{
    public interface IBorrowService
    {
        Task<BorrowDto> CreateAsync(CreateBorrowDto dto , string userId);
        Task<bool> UpdateStatusAsync(UpdateBorrowStatusDto dto);
        Task<PagedResult<BorrowDto>> GetBorrowsByUserAsync(string userId , PaginationParams parameters);
    }
}
