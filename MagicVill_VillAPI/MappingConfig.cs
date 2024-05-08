using AutoMapper;
using MagicVill_VillAPI.Models;
using MagicVill_VillAPI.Models.Dto;

namespace MagicVill_VillAPI
{
    public class MappingConfig: Profile
    {
        public MappingConfig()
        {
            CreateMap<Villa, VillaDTO>();
            CreateMap<VillaDTO, Villa>();

            CreateMap<Villa, VillaCreateDTO>().ReverseMap();
            CreateMap<Villa, VillaCreateDTO>().ReverseMap();

            CreateMap<Villa, VillaUpdateDTO>().ReverseMap();
            CreateMap<VillaUpdateDTO, Villa>().ReverseMap();
        }
    }
}
