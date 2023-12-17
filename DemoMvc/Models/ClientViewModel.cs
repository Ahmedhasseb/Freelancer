using DAL.Moduls;
using Microsoft.AspNetCore.Http;

namespace DemoMvc.Models 
{
    public class ClientViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile Image { get; set; }
        public string ImageName { get; set; }
        public int HairArtistId { get; set; }
        public virtual HairArtist HairArtist { get; set; }
    }
}
