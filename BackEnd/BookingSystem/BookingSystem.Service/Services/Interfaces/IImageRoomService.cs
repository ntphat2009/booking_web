using BookingSystem.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.APIService.Services.Interfaces
{
    public interface IImageRoomService
    {
        public Task AddImage(ImageRoomDTO image);
        public Task UpdateImage(ImageRoomDTO image, string imageID);
        public Task DeleteImage(string deletedBy, string imageID);
    }
}
