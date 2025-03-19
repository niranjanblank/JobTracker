using JobTracker.Models;
using System.Threading.Tasks;

namespace JobTracker.Repositories
{
    public interface IApplicationRepository: IGenericRepository<Application>
    {
        Task<IEnumerable<Application>> GetApplicationsByUserIdAsync(int userId);
        Task<Application> GetApplicationByIdAsync(int id);
    }
}