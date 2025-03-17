using Microsoft.AspNetCore.Mvc;
using JobTracker.Models;
using JobTracker.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobTracker.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class JobController: ControllerBase
    {
        private readonly IJobService _jobService;
        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Job>> GetJob(int id)
        {
            var job = await _jobService.GetJobByIdAsync(id);
            if (job == null) return NotFound();
            return Ok(job);
        }
        [HttpPost]
        public async Task<ActionResult<Job>> AddJob([FromBody] Job job)
        {
            var newJob = await _jobService.AddJobAsync(job);
            return CreatedAtAction(nameof(GetJob), new { id = newJob.Id }, newJob);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJob(int id)
        {
            var success = await _jobService.DeleteJobAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<Job>>> GetJobsByUserId(int userId)
        {
            var jobs = await _jobService.GetJobsByUserIdAsync(userId);
            return Ok(jobs);
        }
        //[HttpGet("company/{companyId}")]
        //public async Task<ActionResult<IEnumerable<Job>>> GetJobsByCompanyId(int companyId)
        //{
        //    var jobs = await _jobService.GetJobsByCompanyIdAsync(companyId);
        //    return Ok(jobs);
        //}
        [HttpPut]
        public async Task<ActionResult<Job>> UpdateJob([FromBody] Job job)
        {
            var updatedJob = await _jobService.UpdateJobAsync(job);
            return Ok(updatedJob);
        }
    }
}