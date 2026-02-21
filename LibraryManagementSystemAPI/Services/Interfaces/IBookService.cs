using Trining_RESTApi.DTOs;

namespace Trining_RESTApi.Services.Interfaces
{
    public interface IBookService
    {
        Task<BookDto> CreateAsync(CreateBookDto dto);
        Task<IEnumerable<BookDto>> GetAllAsync();
        Task<BookDto> GetByIdAsync(int id);
        Task<bool> UpdateAsync(UpdateBookDto dto);
        Task<bool> DeleteBookAsync(int id);
    }
}
