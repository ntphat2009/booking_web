using Booking.Domain.Entity;
using Booking.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastructure.Repositories.InterfaceRepository
{
    public interface IImageRoomRepository
    {
        public Task AddImage(ImageRoomDTO image);
        public Task UpdateImage(ImageRoomDTO image, string imageID);
        public Task DeleteImage(string deletedBy, string imageID);
    }
}
