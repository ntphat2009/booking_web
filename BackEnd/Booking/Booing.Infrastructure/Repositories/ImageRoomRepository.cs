using Booking.Domain.Entity;
using Booking.Infrastructure.Data;
using Booking.Infrastructure.DTOs;
using Booking.Infrastructure.Repositories.InterfaceRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Booking.Infrastructure.Repositories
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
                    CreatedAt = DateTime.Now,
                    CreatedBy = image.CreatedBy,
                    ImageName = image.ImageName,
                    IsDeleted = false,
                    RoomID = image.RoomID,
                    ImageURL = image.ImageURL,
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

        public async Task DeleteImage(string deletedBy, Guid imageID)
        {
            try
            {
                var item = await _context.ImageRooms.FirstOrDefaultAsync(x => x.Id == imageID);
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

        public async Task UpdateImage(ImageRoomDTO image, Guid imageID)
        {
            try
            {
                var item = await _context.ImageRooms.FirstOrDefaultAsync(x => x.Id == imageID);
                if (item == null)
                {
                    throw new Exception("id not found");
                }
                else
                {
                    item.ImageName = image.ImageName;
                    item.IsDeleted = false;
                    item.RoomID = image.RoomID;
                    item.ImageURL = image.ImageURL;
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
