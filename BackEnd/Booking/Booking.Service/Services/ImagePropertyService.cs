using Booking.ApiService.Services.Interfaces;
using Booking.Infrastructure.DTOs;
using Booking.Infrastructure.Repositories.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.ApiService.Services
{
    public class ImagePropertyService : IImagePropertyService
    {
        private readonly IImagePropertyRepository _imageRepository;

        public ImagePropertyService(IImagePropertyRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }
        public async Task AddImage(ImagePropertyDTO image)
        {
            await _imageRepository.AddImage(image);
        }

        public async Task DeleteImage(string deletedBy, string imageID)
        {
            await _imageRepository.DeleteImage(deletedBy, imageID);
        }

        public async Task UpdateImage(ImagePropertyDTO image, string imageID)
        {
            await _imageRepository.UpdateImage(image, imageID);
        }
    }
}
