using MagicVill_VillAPI.Models;

namespace MagicVill_VillAPI.Repository.IRepository
{
    public interface IVillaNumbeRepository :IRepository<VillaNumber>
    {
        Task <VillaNumber> UpdateAsync(VillaNumber entity);
    }
}
