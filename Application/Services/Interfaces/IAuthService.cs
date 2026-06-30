

using LibraryManagementSystemAPI.Application.Models;

namespace LibraryManagementSystemAPI.Application.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthModel> RegisterAsync(RegisterModel model);
        Task<AuthModel> GetTokenAsync(TokenRequestModel model);
        Task<bool> AddRoleAsync(AddRoleModel model);
        Task<bool> RemoveRoleAsync(AddRoleModel model);
    }
}
