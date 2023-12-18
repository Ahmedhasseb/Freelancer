using AutoMapper;
using DemoMvc.Models;
using DAL.Moduls;

namespace DemoMvc.Mapper
{
    public class HairArtistProfile:Profile
    {
        public HairArtistProfile()
        {
            CreateMap<HairArtistViewModel, HairArtist>().ForMember(item => item.name, opt => opt.MapFrom(item => item.name))
                .ForMember(item => item.ImageName, opt => opt.MapFrom(item => item.ImageName)).ReverseMap();     
        }
    }
}
