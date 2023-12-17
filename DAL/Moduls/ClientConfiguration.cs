
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
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");
            builder.HasKey(c => c.Id);
            builder.Property(c=>c.Name)
                .HasMaxLength(20)
                .IsRequired() ;
            builder.HasOne(c=>c.HairArtist)
                .WithMany(c=>c.Clients)
                .HasForeignKey(c=>c.HairArtistId).IsRequired();
        }
    }
}
