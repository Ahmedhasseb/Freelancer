using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Moduls
{
    public class HairArtist
    {
        public int Id { get; set; }
        public string name { get; set; }

        public string ImageName { get; set; }
        public virtual ICollection<Client> Clients { get; set; } = new HashSet<Client>();
        public virtual ICollection<Gallery> Gallerys { get; set; } = new HashSet<Gallery>();
    }
}
