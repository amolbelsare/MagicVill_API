using MagicVill_VillAPI.Models;
using System.Linq.Expressions;

namespace MagicVill_VillAPI.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null,
            int pageSize = 3, int pageNumber = 1);
        Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool traked = true, string? includeProperties = null);
        Task CreateAsync(T entity); 
        Task RevmoveAsync(T entity);
        Task SaveAsync();
    }
}
