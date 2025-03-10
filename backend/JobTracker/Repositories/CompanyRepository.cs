using Microsoft.EntityFrameworkCore;
using JobTracker.Data;
using JobTracker.Models;
using System.Threading.Tasks;

namespace JobTracker.Repositories
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {


        private readonly JobDbContext _context;   
     
        public  CompanyRepository(JobDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Company>> GetCompaniesByUserIdAsync(int userId)
        {
            return await _context.Companies
                .Where(c => c.UserId == userId)
                .ToListAsync(); 
        }
    }

}