using Microsoft.AspNetCore.Http;

namespace DemoMvc.Models
{
    public class HairArtistViewModel
    {
        public int Id { get; set; }
        public string name { get; set; }
        public IFormFile Image { get; set; }
        public string ImageName { get; set; }
    }
}
