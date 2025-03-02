using Booking.Domain.Entity;
using Booking.Infrastructure.Data;
using Booking.Infrastructure.DTOs;
using Booking.Infrastructure.Repositories.InterfaceRepository;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastructure.Repositories
{
    public class ImagePropertyRepository : IImagePropertyRepository
    {
        private readonly ILogger<ImagePropertyRepository> _logger;
        private readonly ApplicationDbContext _context;

        public ImagePropertyRepository(ILogger<ImagePropertyRepository> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _context = dbContext;
        }
        public async Task AddImage(ImagePropertyDTO image)
        {
            try
            {
                var newImage = new ImageProperty()
                {
                    CreatedAt = DateTime.Now,
                    CreatedBy = image.CreatedBy,
                    ImageName = image.ImageName,
                    IsDeleted = false,
                    PropertyID = image.PropertyID,
                    ImageURL = image.ImageURL,
                    UpdatedAt = DateTime.Now,
                };
                await _context.ImageProperties.AddAsync(newImage);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException);
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task UpdateImage(ImagePropertyDTO image, Guid imageID)
        {
            try
            {
                var item = _context.ImageProperties.FirstOrDefault(x => x.Id == imageID);
                if (item == null)
                {
                    throw new Exception("id not found");
                }
                else
                {
                    item.ImageName = image.ImageName;
                    item.IsDeleted = false;
                    item.PropertyID = image.PropertyID;
                    item.ImageURL = image.ImageURL;
                    item.UpdatedAt = DateTime.Now;
                    item.CreatedAt = DateTime.Now;
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

        public async Task DeleteImage(string deletedBy, Guid imageID)
        {
            try
            {
                var item = _context.ImageProperties.FirstOrDefault(x => x.Id == imageID);
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

    }
}
