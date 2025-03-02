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
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.RoomID);
            builder.HasIndex(x => x.UserID);
            builder.HasOne(x => x.Room)
                .WithMany(x => x.Books)
                .HasForeignKey(x => x.RoomID)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.User)
                .WithMany(x => x.Books)
                .HasForeignKey(x => x.UserID)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(p => p.BookingStatus)
                .HasConversion<string>()
                .HasMaxLength(50);
            builder.Property(p => p.TotalPrice)
                .HasPrecision(18, 4);
        }
    }
}
