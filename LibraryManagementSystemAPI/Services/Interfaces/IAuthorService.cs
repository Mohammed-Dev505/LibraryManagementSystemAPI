using LibraryManagementSystemAPI.Data.Models;
using Trining_RESTApi.DTOs;

namespace Trining_RESTApi.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<AuthorDto> CreateAuthorAsync(CreateAuthorDto dto);
        Task<PagedResult<AuthorDto>> GetAllAsync(AuthorParams pagination);
        Task<AuthorDto> GetAuthorByIdAsync(int id);
        Task<bool> UpdateAuthorAsync(UpdateAuthorDto dto);
        Task<bool> DeleteAuthorAsync(int id);
    }
}
