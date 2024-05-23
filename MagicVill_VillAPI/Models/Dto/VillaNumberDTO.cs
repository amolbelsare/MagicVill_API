using System.ComponentModel.DataAnnotations;

namespace MagicVill_VillAPI.Models.Dto
{
    public class VillaNumberDTO
    {
        [Required]
        public int? VillaNo { get; set; }
        public string SpecialDetails { get; set; }
    }
}
