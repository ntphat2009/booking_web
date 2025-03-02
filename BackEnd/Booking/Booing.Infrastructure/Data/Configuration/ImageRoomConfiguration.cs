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
    public class ImageRoomConfiguration : IEntityTypeConfiguration<ImageRoom>
    {
        public void Configure(EntityTypeBuilder<ImageRoom> builder)
        {
            builder.ToTable("ImageRooms");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Room)
                .WithMany(x => x.ImageRooms)
                .HasForeignKey(x => x.RoomID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
