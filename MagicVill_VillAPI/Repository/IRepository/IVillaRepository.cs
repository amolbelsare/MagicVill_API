using MagicVill_VillAPI.Models;
using MagicVill_VillAPI.Models.Dto;
using System.Linq.Expressions;

namespace MagicVill_VillAPI.Repository.IRepository
{
    public interface IVillaRepository
    {
        Task<List<Villa>> GetAll(Expression<Func<Villa, bool>> filter = null);
        Task <Villa> Get(Expression<Func<Villa, bool>> filter=null, bool traked= true);
        Task Create(Villa entity);
        Task Revmove(Villa entity);
        Task Save();
    }
}
