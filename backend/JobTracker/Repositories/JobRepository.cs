using Microsoft.EntityFrameworkCore;
using JobTracker.Data;
using JobTracker.Models;
using System.Threading.Tasks;

namespace JobTracker.Repositories
{
    public class JobRepository : GenericRepository<Job>, IJobRepository
    {
        private readonly JobDbContext _context;
        public JobRepository(JobDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Job>> GetJobsByUserIdAsync(int userId)
        {
            return await _context.Jobs.Where(j => j.UserId == userId).ToListAsync();
        }
    }
}