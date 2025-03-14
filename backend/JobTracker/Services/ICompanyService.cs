using System.Collections.Generic;
using JobTracker.Models;
using System.Threading.Tasks;

namespace JobTracker.Services
{
    public interface ICompanyService 
    {
        // to get a single company by id
        Task<Company?> GetCompanyByIdAsync(int id);
        // add a company
        Task<Company> AddCompanyAsync(Company company);
        // delete a company
        Task<bool> DeleteCompanyAsync(int id);
        // get all companies by user id
        Task<IEnumerable<Company>> GetCompaniesByUserIdAsync(int userId);
        // update a company
        Task<Company> UpdateCompanyAsync(Company company);
    }


}