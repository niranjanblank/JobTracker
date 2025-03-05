using Microsoft.EntityFrameworkCore;
using JobTracker.Data;
using JobTracker.Models;
using System.Threading.Tasks;

namespace JobTracker.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly JobDbContext _context;

        public UserRepository(JobDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}