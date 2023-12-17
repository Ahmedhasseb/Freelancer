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
    public class HairArtistConfiguration : IEntityTypeConfiguration<HairArtist>
    {
        public void Configure(EntityTypeBuilder<HairArtist> builder)
        {
           
            builder.Property(x=>x.name).IsRequired().HasMaxLength(50);
        }
    }
}
