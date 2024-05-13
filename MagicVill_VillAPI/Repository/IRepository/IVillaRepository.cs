using MagicVill_VillAPI.Models;
using MagicVill_VillAPI.Models.Dto;
using System.Linq.Expressions;

namespace MagicVill_VillAPI.Repository.IRepository
{
    public interface IVillaRepository: IRepository<Villa>
    {       
        Task <Villa> UpdateAsync(Villa entity);    
    }
}
