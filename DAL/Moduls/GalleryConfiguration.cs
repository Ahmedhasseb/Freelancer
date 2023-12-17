
using DAL.Moduls;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configuration
{
    public class GalleryConfiguration : IEntityTypeConfiguration<Gallery>
    {
        public void Configure(EntityTypeBuilder<Gallery> builder)
        {
            builder.ToTable("Gallery");
            builder.HasKey(i => i.Id);
            builder.Property(G=>G.Decsription).IsRequired();
            builder.HasOne(c => c.HairArtist)
                .WithMany(c => c.Gallerys)
                .HasForeignKey(c => c.HairArtistId)
                .IsRequired();
        }
    }
}
