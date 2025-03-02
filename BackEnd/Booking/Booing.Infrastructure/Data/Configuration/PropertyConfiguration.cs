using Booking.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastructure.Data.Configuration
{
    public class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.ToTable("Properties");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Name)
                .IsUnique();
            builder.HasIndex(x => x.PropertyUrl)
                .IsUnique();
            builder.HasOne(x => x.City)
                .WithMany(x => x.Properties)
                .HasForeignKey(x => x.CityID)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(p => p.AvgPrice)
                .HasPrecision(18, 4);
        }
    }
}
