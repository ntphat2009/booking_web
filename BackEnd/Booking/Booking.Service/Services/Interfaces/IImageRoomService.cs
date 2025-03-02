using Booking.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.ApiService.Services.Interfaces
{
    public interface IImageRoomService
    {
        public Task AddImage(ImageRoomDTO image);
        public Task UpdateImage(ImageRoomDTO image, Guid imageID);
        public Task DeleteImage(string deletedBy, Guid imageID);
    }
}
