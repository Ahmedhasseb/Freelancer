using DAL.Configuration;
using DAL.Moduls;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ContextConfiguration
{
    public class Dbcontext:DbContext
    {
        public Dbcontext(DbContextOptions optins):base(optins)
        {
                
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new GalleryConfiguration());
            modelBuilder.ApplyConfiguration(new HairArtistConfiguration());

            // Other configurations...

            base.OnModelCreating(modelBuilder);
        }

    
        public DbSet<Client> Clients { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<HairArtist> HairArtists { get; set; }
    }
}
