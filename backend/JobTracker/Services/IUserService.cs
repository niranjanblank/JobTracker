using System.Collections.Generic;
using JobTracker.Models;
using System.Threading.Tasks;

namespace JobTracker.Services
{
    public interface IUserService
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<User?> GetUserByIdAsync(int id);
        Task<User> AddUserAsync(User user);
        Task<bool> DeleteUserAsync(int id);
        Task<User>? GetUserByEmailAsync(string email);
    }
}