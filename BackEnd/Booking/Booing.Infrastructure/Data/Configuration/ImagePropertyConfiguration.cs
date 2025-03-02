﻿using Booking.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastructure.Data.Configuration
{
    public class ImagePropertyConfiguration : IEntityTypeConfiguration<ImageProperty>
    {
        public void Configure(EntityTypeBuilder<ImageProperty> builder)
        {
            builder.ToTable("ImagePropertíe");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Property)
                .WithMany(x => x.ImageProperties)
                .HasForeignKey(x => x.PropertyID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
