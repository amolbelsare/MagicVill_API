using AutoMapper;
using MagicVill_VillAPI.Models;
using MagicVill_VillAPI.Models.Dto;

namespace MagicVill_VillAPI
{
    public class MappingConfig: Profile
    {
        public MappingConfig()
        {
            //Single Mapping
            CreateMap<Villa, VillaDTO>();
            CreateMap<VillaDTO, Villa>();
            //Reverse mapping
            CreateMap<Villa, VillaCreateDTO>().ReverseMap();
            CreateMap<Villa, VillaUpdateDTO>().ReverseMap();


           //Reverse mapping for VillaNumber
            CreateMap<VillaNumber, VillaNumberDTO>().ReverseMap();
            CreateMap<VillaNumber, VillaNumberCreateDTO>().ReverseMap();
            CreateMap<VillaNumber, VillaNumberUpdateDTO>().ReverseMap();
        }
    }
}
