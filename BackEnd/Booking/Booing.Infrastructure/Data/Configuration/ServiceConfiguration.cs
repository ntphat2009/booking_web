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
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("Services");
            builder.HasIndex(x => x.Id);
            builder.HasOne(x => x.Property)
                .WithMany(x => x.Services)
                .HasForeignKey(x => x.PropertyID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
