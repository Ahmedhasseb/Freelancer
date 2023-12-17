using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Moduls
{
    public class Gallery
    {
        public int Id { get; set; }
        public string Decsription { get; set; }
        public string ImageName { get; set; }
        public int HairArtistId { get; set; }
        public virtual HairArtist HairArtist { get; set; }
    }
}
