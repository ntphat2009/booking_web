using BookingSystem.APIService.Services.Interfaces;
using BookingSystem.Infrastructure.DTOs;
using BookingSystem.Infrastructure.Repositories.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.APIService.Services
{
    public class ImageRoomService : IImageRoomService
    {
        private readonly IImageRoomRepository _repository;

        public ImageRoomService(IImageRoomRepository repository)
        {
            _repository = repository;
        }
        public async Task AddImage(ImageRoomDTO image)
        {
            await _repository.AddImage(image);
        }

        public async Task DeleteImage(string deletedBy, string imageID)
        {
            await _repository.DeleteImage(deletedBy, imageID);
        }

        public async Task UpdateImage(ImageRoomDTO image, string imageID)
        {
            await _repository.UpdateImage(image, imageID);
        }
    }
}
