using Microsoft.EntityFrameworkCore;
using JobTracker.Data;
using JobTracker.Models;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace JobTracker.Repositories
{
    public class ApplicationRepository : GenericRepository<Application>, IApplicationRepository
    {
        private readonly JobDbContext _context;
        private readonly ILogger<ApplicationRepository> _logger; // ✅ Inject ILogger
        public ApplicationRepository(JobDbContext context, ILogger<ApplicationRepository> logger) // ✅ Accept logger as a parameter
             : base(context)
        {
            _context = context;
            _logger = logger; // ✅ Assign logger to the field
        }

        public async Task<IEnumerable<Application>> GetApplicationsByUserIdAsync(int userId)
        {
            return await _context.Applications
                .Where(a => a.UserId == userId)
                .Include(a => a.Job)
                .ToListAsync();
        }

        public async Task<Application> GetApplicationByIdAsync(int id)
        {
            _logger.LogInformation("🔎 Fetching Application with ID: {Id}", id);

            var app = await _context.Applications
                .Include(a => a.Job)  // Ensure Job is included
                .FirstOrDefaultAsync(a => a.Id == id);

            if (app == null)
            {
                _logger.LogWarning("❌ Application with ID {Id} not found!", id);
                return null;
            }

            _logger.LogInformation("✅ Retrieved Application: {Id}", app.Id);
            _logger.LogInformation("Job: {JobId} - {JobTitle}", app.Job?.Id, app.Job?.Title);

            return app;
        }
    }
}