using BookingSystem.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Infrastructure.Data.Configuration
{
    public class BookingConfiguration : IEntityTypeConfiguration<Domain.Entity.Booking>
    {
        public void Configure(EntityTypeBuilder<Domain.Entity.Booking> builder)
        {
            builder.ToTable("Bookings");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.UserId);
            builder.HasOne(x => x.Room)
                .WithMany(x => x.Bookings)
                .HasForeignKey(x => x.RoomId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.User)
                .WithMany(x => x.Bookings)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(p => p.BookingStatus)
                .HasConversion<string>()
                .HasMaxLength(50);
            builder.Property(p => p.TotalPrice)
                .HasPrecision(18, 4);
        }
    }
}
