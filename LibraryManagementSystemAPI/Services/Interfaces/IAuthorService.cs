using Trining_RESTApi.DTOs;

namespace Trining_RESTApi.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<AuthorDto> CreateAuthorAsync(CreateAuthorDto dto);
        Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync();
        Task<AuthorDto> GetAuthorByIdAsync(int id);
        Task<bool> UpdateAuthorAsync(UpdateAuthorDto dto);
        Task<bool> DeleteAuthorAsync(int id);
    }
}
