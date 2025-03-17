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

            var entry = _context.Entry(existingEntity);
            var entityProperties = typeof(T).GetProperties();

            foreach (var property in entityProperties)
            {
                var newValue = property.GetValue(entity);
                var existingValue = property.GetValue(existingEntity);

                // If the new value is not null, or if it's a value type and not default, update it
                if (newValue != null && (!property.PropertyType.IsValueType || !Equals(newValue, Activator.CreateInstance(property.PropertyType))))
                {
                    entry.Property(property.Name).CurrentValue = newValue;
                }
            }

            await _context.SaveChangesAsync();
            return existingEntity;
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }
    }
}