using Trining_RESTApi.DTOs;

namespace Trining_RESTApi.Services.Interfaces
{
    public interface IBorrowService
    {
        Task<BorrowDto> CreateAsync(CreateBorrowDto dto);
        Task<bool> UpdateStatusAsync(UpdateBorrowStatusDto dto);
        Task<IEnumerable<BorrowDto>> GetBorrowsByUserAsync(string userId);
    }
}
