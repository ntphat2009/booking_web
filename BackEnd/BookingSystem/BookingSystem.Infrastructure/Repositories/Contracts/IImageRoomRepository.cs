using BookingSystem.Domain.Entity;
using BookingSystem.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Infrastructure.Repositories.InterfaceRepository
{
    public interface IImageRoomRepository
    {
        public Task AddImage(ImageRoomDTO image);
        public Task UpdateImage(ImageRoomDTO image, string imageID);
        public Task DeleteImage(string deletedBy, string imageID);
    }
}
