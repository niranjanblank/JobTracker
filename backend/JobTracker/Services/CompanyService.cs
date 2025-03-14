using JobTracker.Models;
using JobTracker.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace JobTracker.Services
{
    public class CompanyService: ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ILogger<CompanyService> _logger;

        public CompanyService(ICompanyRepository companyRepository, ILogger<CompanyService> logger)
        {
            _companyRepository = companyRepository;
            _logger = logger;
        }

        // define the methods from the service
        public async Task<Company?> GetCompanyByIdAsync(int id) => await _companyRepository.GetByIdAsync(id);
        public async Task<Company> AddCompanyAsync(Company company) => await _companyRepository.AddAsync(company);
        public async Task<bool> DeleteCompanyAsync(int id) => await _companyRepository.DeleteAsync(id);
        public async Task<IEnumerable<Company>> GetCompaniesByUserIdAsync(int userId) => await _companyRepository.GetCompaniesByUserIdAsync(userId);
        public async Task<Company> UpdateCompanyAsync(Company company)
        {
            // Log company details before updating
            _logger.LogInformation("Updating Company: ID={Id}, Name={Name}, Location={Location}, UpdatedAt={UpdatedAt}",
                company.Id, company.Name, company.Location, company.UpdatedAt);
            var existingCompany = await _companyRepository.GetByIdAsync(company.Id);
            if (existingCompany == null)
            {
                throw new KeyNotFoundException("Company not found");
            }
            // int is non-nullable by default, if we pass null userid, it would convert it to 0 and update the company with userid 0
            // which will create an error, so we need to set the foreign key manually
            company.UserId = existingCompany.UserId;
            // Update `UpdatedAt` before saving
            company.UpdatedAt = DateTime.UtcNow;
    

            return await _companyRepository.UpdateAsync(company, company.Id);
        }
    }
}