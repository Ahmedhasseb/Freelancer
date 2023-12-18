using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace DemoMvc.Models
{
    public class HairArtistViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is Requierd")]
        [MaxLength(20, ErrorMessage = "Name is max lenght 20 char")]
        [MinLength(2, ErrorMessage = "Name is min lenght 2 char")]
        public string name { get; set; }
        [Required(ErrorMessage = "Image is Requierd")]
        public IFormFile Image { get; set; }
        
        public string ImageName { get; set; }
    }
}
