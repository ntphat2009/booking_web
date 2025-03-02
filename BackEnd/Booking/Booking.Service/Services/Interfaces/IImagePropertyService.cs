﻿using Booking.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.ApiService.Services.Interfaces
{
    public interface IImagePropertyService
    {
        public Task AddImage(ImagePropertyDTO image);
        public Task UpdateImage(ImagePropertyDTO image, Guid imageID);
        public Task DeleteImage(string deletedBy, Guid imageID);
    }
}
