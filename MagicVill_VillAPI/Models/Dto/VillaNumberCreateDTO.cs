﻿using System.ComponentModel.DataAnnotations;

namespace MagicVill_VillAPI.Models.Dto
{
    public class VillaNumberCreateDTO
    {
        [Required]     
        public int? VillaNo { get; set; }
        [Required]
        public int VillaID { get; set; }
        public string SpecialDetails { get; set; }
    }
}
