using JobTracker.Models;
using JobTracker.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobTracker.Services
{
    public class JobService: IJobService
    {
        private readonly IJobRepository _jobRepository;
        public JobService(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        //public async Task<IEnumerable<Job>> GetAllJobsAsync() => await _jobRepository.GetAllAsync();
        public async Task<IEnumerable<Job>> GetJobsByUserIdAsync(int userId) => await _jobRepository.GetJobsByUserIdAsync(userId);
        public async Task<Job?> GetJobByIdAsync(int id) => await _jobRepository.GetByIdAsync(id);
        public async Task<Job> AddJobAsync(Job job) => await _jobRepository.AddAsync(job);
        public async Task<bool> DeleteJobAsync(int id) => await _jobRepository.DeleteAsync(id);

        public async Task<Job> UpdateJobAsync(Job job)
        {
            // check if the job exists
            var existingJob = await _jobRepository.GetByIdAsync(job.Id);
            if (existingJob == null)
            {
                throw new KeyNotFoundException("Job not found");
            }

            // make sure to add company_id and user_id while updating
            job.CompanyId = existingJob.CompanyId;
            job.UserId = existingJob.UserId;

            return await _jobRepository.UpdateAsync(job, job.Id);
        }
    }
}