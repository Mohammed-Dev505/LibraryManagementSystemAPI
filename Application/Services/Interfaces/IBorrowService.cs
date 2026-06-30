

using LibraryManagementSystemAPI.Application.DTOs;
using LibraryManagementSystemAPI.Application.Models;

namespace LibraryManagementSystemAPI.Application.Services.Interfaces
{
    public interface IBorrowService
    {
        Task<BorrowDto> CreateAsync(CreateBorrowDto dto , string userId);
        Task<bool> UpdateStatusAsync(Guid id , UpdateBorrowStatusDto dto);
        Task<PagedResult<BorrowDto>> GetBorrowsByUserAsync(string userId , PaginationParams parameters);
    }
}
