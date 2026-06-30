

using LibraryManagementSystemAPI.Application.DTOs;
using LibraryManagementSystemAPI.Application.Models;

namespace LibraryManagementSystemAPI.Application.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<AuthorDto> CreateAuthorAsync(CreateAuthorDto dto);
        Task<PagedResult<AuthorDto>> GetAllAsync(AuthorParams pagination);
        Task<AuthorDto> GetAuthorByIdAsync(Guid id);
        Task<bool> UpdateAuthorAsync(Guid id , UpdateAuthorDto dto);
        Task<bool> DeleteAuthorAsync(Guid id);
    }
}
