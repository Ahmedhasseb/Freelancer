using AutoMapper;
using DemoMvc.Models;
using DAL.Moduls;

namespace DemoMvc.Mapper
{
    public class ClientProfile:Profile
    {
        public ClientProfile()
        {
                CreateMap<ClientViewModel,Client>().ReverseMap();
        }
    }
}
