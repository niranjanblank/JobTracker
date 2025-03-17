using System.Collections.Generic;
using JobTracker.Models;
using System.Threading.Tasks;

namespace JobTracker.Services
{
    public interface IJobService
    {
        //Task<IEnumearble<Job>> GetAllJobsAsync();
        Task<Job?> GetJobByIdAsync(int id);
        Task<Job> AddJobAsync(Job job);
        Task<bool> DeleteJobAsync(int id);
        Task<IEnumerable<Job>> GetJobsByUserIdAsync(int userId);
        Task<Job> UpdateJobAsync(Job job);
    }
}