using DAL.Moduls;
using Microsoft.AspNetCore.Http;

namespace DemoMvc.Models
{
    public class GalleryViewModel
    {
        public int Id { get; set; }

        public string Decsription { get; set; }
        public IFormFile Image { get; set; }
        public string ImageName { get; set; }
        public int HairArtistId { get; set; }
        public  HairArtist HairArtist { get; set; }

    }
}
