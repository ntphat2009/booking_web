using BookingSystem.Domain.Entity;
using BookingSystem.Infrastructure.Data;
using BookingSystem.Infrastructure.DTOs;
using BookingSystem.Infrastructure.Repositories.InterfaceRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BookingSystem.Infrastructure.Repositories.Implementations
{
    public class ImageRoomRepository : IImageRoomRepository
    {
        private readonly ILogger<ImagePropertyRepository> _logger;
        private readonly ApplicationDbContext _context;

        public ImageRoomRepository(ILogger<ImagePropertyRepository> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task AddImage(ImageRoomDTO image)
        {
            try
            {
                var newImage = new ImageRoom()
                {
                    Id = Guid.NewGuid().ToString(),
                    CreatedAt = DateTime.Now,
                    CreatedBy = image.CreatedBy,
                    ImageName = image.ImageName,
                    ImageType = (MyImageType)image.ImageType,
                    IsDeleted = false,
                    RoomUrl = image.RoomUrl,
                    RoomId = image.RoomId,
                    ImageUrl = image.ImageUrl,
                    UpdatedAt = DateTime.Now,
                };
                await _context.ImageRooms.AddAsync(newImage);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException);
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task DeleteImage(string deletedBy, string imageId)
        {
            try
            {
                var item = await _context.ImageRooms.FirstOrDefaultAsync(x => x.Id == imageId);
                if (item == null)
                {
                    throw new Exception("id not found");
                }
                else
                {
                    item.IsDeleted = true;
                    item.UpdatedAt = DateTime.Now;
                    item.UpdatedBy = deletedBy;
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException);
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task UpdateImage(ImageRoomDTO image, string imageId)
        {
            try
            {
                var item = await _context.ImageRooms.FirstOrDefaultAsync(x => x.Id == imageId);
                if (item == null)
                {
                    throw new Exception("id not found");
                }
                else
                {
                    item.ImageName = image.ImageName;
                    item.ImageType = (MyImageType)image.ImageType;
                    item.IsDeleted = false;
                    item.RoomUrl = image.RoomUrl;
                    item.RoomId = image.RoomId;
                    item.ImageUrl = image.ImageUrl;
                    item.CreatedAt = DateTime.Now;
                    item.UpdatedAt = DateTime.Now;
                    item.UpdatedBy = image.UpdatedBy;
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException);
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
