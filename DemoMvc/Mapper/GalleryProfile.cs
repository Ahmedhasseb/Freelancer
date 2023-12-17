using AutoMapper;
using DemoMvc.Models;

using DAL.Moduls;

namespace DemoMvc.Mapper
{
    public class GalleryProfile:Profile
    {
        public GalleryProfile()
        {
                CreateMap<GalleryViewModel,Gallery>().ReverseMap();
        }
    }
}
