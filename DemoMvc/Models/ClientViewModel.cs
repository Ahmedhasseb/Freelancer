using DAL.Moduls;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace DemoMvc.Models 
{
    public class ClientViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is Requierd")]
        [MaxLength(20,ErrorMessage ="Name is max lenght 20 char")]
        [MinLength(2, ErrorMessage = "Name is min lenght 2 char")]
        public string Name { get; set; }
        public IFormFile Image { get; set; }
        [Required(ErrorMessage = "The image is Requierd")]
        public string ImageName { get; set; }
        [Required(ErrorMessage = "The HairArtist is Requierd")]
        public int HairArtistId { get; set; }
        public virtual HairArtist HairArtist { get; set; }
    }
}
