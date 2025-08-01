﻿using BookingSystem.Domain.Entity;
using BookingSystem.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Infrastructure.Repositories.InterfaceRepository
{
    public interface IImagePropertyRepository
    {
        public Task AddImage(ImagePropertyDTO image);
        public Task UpdateImage(ImagePropertyDTO image, string imageID);
        public Task DeleteImage(string deletedBy, string imageID);
    }
}
