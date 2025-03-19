using System.Collections.Generic;
using JobTracker.Models;
using System.Threading.Tasks;

namespace JobTracker.Services
{
    public interface IApplicationService
    {
        Task<Application?> GetApplicationByIdAsync(int id);
        Task<Application> AddApplicationAsync(Application application);
        Task<bool> DeleteApplicationAsync(int id);
        Task<IEnumerable<Application>> GetApplicationsByUserIdAsync(int userId);
        Task<Application> UpdateApplicationAsync(Application application);
    }
}