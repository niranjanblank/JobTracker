using Microsoft.AspNetCore.Mvc;
using JobTracker.Models;
using JobTracker.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;
        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Application>> GetApplication(int id)
        {
            var application = await _applicationService.GetApplicationByIdAsync(id);
            if (application == null) return NotFound();
            return Ok(application);
        }
        [HttpPost]
        public async Task<ActionResult<Application>> AddApplication([FromBody] Application application)
        {
            var newApplication = await _applicationService.AddApplicationAsync(application);
            return CreatedAtAction(nameof(GetApplication), new { id = newApplication.Id }, newApplication);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplication(int id)
        {
            var success = await _applicationService.DeleteApplicationAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<Application>>> GetApplicationsByUserId(int userId)
        {
            var applications = await _applicationService.GetApplicationsByUserIdAsync(userId);
            return Ok(applications);
        }
        [HttpPut]
        public async Task<ActionResult<Application>> UpdateApplication([FromBody] Application application)
        {
            var updatedApplication = await _applicationService.UpdateApplicationAsync(application);
            return Ok(updatedApplication);
        }
    }
}