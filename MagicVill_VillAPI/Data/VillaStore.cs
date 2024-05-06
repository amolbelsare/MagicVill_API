using MagicVill_VillAPI.Models.Dto;

namespace MagicVill_VillAPI.Data
{
    public static class VillaStore
    {
        public static List<VillaDTO> VillaList = new List<VillaDTO>
        {
            new VillaDTO {Id=1,Name="Pool View", Occupancy=4, Sqft=1000},
            new VillaDTO {Id=2,Name= "Beach View", Occupancy= 3, Sqft=5000}
        };
    }
}
