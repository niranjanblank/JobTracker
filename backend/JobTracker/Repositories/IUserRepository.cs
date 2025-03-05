using JobTracker.Models;
using System.Threading.Tasks;

namespace JobTracker.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> GetUserByEmailAsync(string email);
    }
}