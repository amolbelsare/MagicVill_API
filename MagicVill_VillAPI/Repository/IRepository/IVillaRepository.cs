using MagicVill_VillAPI.Models;
using MagicVill_VillAPI.Models.Dto;
using System.Linq.Expressions;

namespace MagicVill_VillAPI.Repository.IRepository
{
    public interface IVillaRepository
    {
        Task<List<Villa>> GetAllAsync(Expression<Func<Villa, bool>> filter = null);
        Task <Villa> GetAsync(Expression<Func<Villa, bool>> filter=null, bool traked= true);
        Task CreateAsync(Villa entity);
        Task UpdateAsync(Villa entity);
        Task RevmoveAsync(Villa entity);
        Task SaveAsync();
    }
}
