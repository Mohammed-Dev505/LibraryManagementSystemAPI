

using LibraryManagementSystemAPI.Application.DTOs;
using LibraryManagementSystemAPI.Application.Models;

namespace LibraryManagementSystemAPI.Application.Services.Interfaces
{
    public interface IBookService
    {
        Task<BookDto> CreateAsync(CreateBookDto dto);
        Task<PagedResult<BookDto>> GetAllAsync(BookParams pagination);
        Task<BookDto> GetByIdAsync(Guid id);
        Task<bool> UpdateAsync( Guid id, UpdateBookDto dto);
        Task<bool> DeleteBookAsync(Guid id);
    }
}
