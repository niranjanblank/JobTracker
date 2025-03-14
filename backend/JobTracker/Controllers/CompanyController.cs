using Microsoft.AspNetCore.Mvc;
using JobTracker.Models;
using JobTracker.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController: ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        // get companies by id
        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetCompany(int id)
        {
            var company = await _companyService.GetCompanyByIdAsync(id);
            if (company == null) return NotFound();
            return Ok(company);
        }

        [HttpPost]
        public async Task<ActionResult<Company>> AddCompany([FromBody] Company company)
        {
            var newCompany = await _companyService.AddCompanyAsync(company);
            return CreatedAtAction(nameof(GetCompany), new { id = newCompany.Id }, newCompany);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var success = await _companyService.DeleteCompanyAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }

        // get companies by user id
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompaniesByUserId(int userId)
        {
            var companies = await _companyService.GetCompaniesByUserIdAsync(userId);
            return Ok(companies);
        }

        //update a company
        [HttpPut]
        public async Task<ActionResult<Company>> UpdateCompany([FromBody] Company company)
        {
            var updatedCompany = await _companyService.UpdateCompanyAsync(company);
            return Ok(updatedCompany);
        }
    }
}