using System.Linq.Expressions;

namespace JobTracker.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task<bool> DeleteAsync(int id);
        Task<T> UpdateAsync(T entity, object key);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    }
}