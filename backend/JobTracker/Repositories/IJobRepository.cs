using JobTracker.Models;
using System.Threading.Tasks;

namespace JobTracker.Repositories
{
     public interface IJobRepository: IGenericRepository<Job>
    {
        Task<IEnumerable<Job>> GetJobsByUserIdAsync(int userId);
    }
}