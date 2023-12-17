using AutoMapper;
using DemoMvc.Models;
using DAL.Moduls;

namespace DemoMvc.Mapper
{
    public class HairArtistProfile:Profile
    {
        public HairArtistProfile()
        {
            CreateMap<HairArtistViewModel, HairArtist>().ReverseMap();     
        }
    }
}
