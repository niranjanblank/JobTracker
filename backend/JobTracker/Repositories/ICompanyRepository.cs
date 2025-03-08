using JobTracker.Models;
using System.Threading.Tasks;

namespace JobTracker.Repositories
{
    public interface ICompanyRepository : IGenericRepository<Company>
    {
        Task<IEnumerable<Company>> GetCompaniesByUserIdAsync(int userId);
    } 

}