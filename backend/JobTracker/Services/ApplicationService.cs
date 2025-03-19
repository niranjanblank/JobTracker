using JobTracker.Models;
using JobTracker.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;


namespace JobTracker.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;

        public ApplicationService(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public async Task<Application?> GetApplicationByIdAsync(int id) => await _applicationRepository.GetApplicationByIdAsync(id);
        public async Task<Application> AddApplicationAsync(Application application) {
            application.CreatedAt = DateTime.UtcNow;
            return await _applicationRepository.AddAsync(application);
        }
        public async Task<bool> DeleteApplicationAsync(int id) => await _applicationRepository.DeleteAsync(id);
        public async Task<IEnumerable<Application>> GetApplicationsByUserIdAsync(int userId) => await _applicationRepository.GetApplicationsByUserIdAsync(userId);
        public async Task<Application> UpdateApplicationAsync(Application application)
        {
            var existingApplication = await _applicationRepository.GetByIdAsync(application.Id);
            if (existingApplication == null)
            {
                throw new KeyNotFoundException("Application not found");
            }

            // Update `UpdatedAt` before saving
            application.LastUpdated = DateTime.UtcNow;
            return await _applicationRepository.UpdateAsync(application, application.Id);
        }
    }
}