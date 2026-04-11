using LibraryManagementSystemAPI.Data.Models;
using Trining_RESTApi.DTOs;

namespace Trining_RESTApi.Services.Interfaces
{
    public interface IBookService
    {
        Task<BookDto> CreateAsync(CreateBookDto dto);
        Task<PagedResult<BookDto>> GetAllAsync(BookParams pagination);
        Task<BookDto> GetByIdAsync(int id);
        Task<bool> UpdateAsync(UpdateBookDto dto);
        Task<bool> DeleteBookAsync(int id);
    }
}
