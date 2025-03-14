using Microsoft.EntityFrameworkCore;
using JobTracker.Data;
using System.Linq.Expressions;

namespace JobTracker.Repositories
{
    public class GenericRepository<T>: IGenericRepository<T> where T: class
    {
        private readonly JobDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(JobDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                return false;
            }

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<T> UpdateAsync(T entity, object key)
        {
            var existingEntity = await _dbSet.FindAsync(key);
            if (existingEntity == null)
            {
                throw new KeyNotFoundException("Entity not found");
            }

            // Apply only the non-null values from `entity` to `existingEntity`
            // int are non-nullable by default, if there exists a nullable int, we need to check that in service
            _context.Entry(existingEntity).CurrentValues.SetValues(entity);

            await _context.SaveChangesAsync();
            return existingEntity;
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }
    }
}