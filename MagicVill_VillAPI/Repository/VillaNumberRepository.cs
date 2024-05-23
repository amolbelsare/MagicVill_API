
using MagicVill_VillAPI.Data;
using MagicVill_VillAPI.Models;
using MagicVill_VillAPI.Repository.IRepository;

namespace MagicVill_VillAPI.Repository
{
    public class VillaNumberRepository :Repository<VillaNumber> , IVillaNumbeRepository
    {
        private readonly ApplicationDbContext _db;
        public VillaNumberRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<VillaNumber> UpdateAsync(VillaNumber entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _db.VillaNumbers.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
