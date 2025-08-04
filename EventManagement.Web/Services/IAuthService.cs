using EventManagement.Web.Models;
using EventManagement.Web.ViewModels;

namespace EventManagement.Web.Services
{
    public interface IAuthService
    {
        Task<bool> RegisterAsync(RegisterViewModel model);
        Task<User?> LoginAsync(LoginViewModel model);
        Task<User?> GetUserByIdAsync(int id);
        Task<User?> GetUserByEmailAsync(string email);
        Task<bool> UpdateUserAsync(User user);
        bool VerifyPassword(string password, string hash, string salt);
        (string hash, string salt) HashPassword(string password);
    }
} 