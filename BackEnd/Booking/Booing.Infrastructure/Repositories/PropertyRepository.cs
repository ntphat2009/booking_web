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
using static Booking.Common.Utilities.FormatUtilities;
namespace Booking.Infrastructure.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<PropertyRepository> _logger;

        public PropertyRepository(ApplicationDbContext dbContext, ILogger<PropertyRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public async Task<IEnumerable<Property>> GetAllAsync(int page, int pageSize, string sortBy)
        {
            IQueryable<Property> queryable = _dbContext.Properties
                                     .AsNoTracking()
                                     .Where(x => !x.IsDeleted)
                                     .Include(x => x.ImageProperties)
                                     .Include(x => x.City);
            switch (sortBy.ToLower())
            {
                case "desc":
                    queryable.OrderByDescending(x => x.Name);
                    break;
                case "asc":
                    queryable.OrderBy(x => x.Name);
                    break;
                case "date_desc":
                    queryable.OrderByDescending(x => x.UpdatedAt);
                    break;
                case "date_asc":
                    queryable.OrderBy(x => x.UpdatedAt);
                    break;
                default:
                    queryable.OrderByDescending(x => x.UpdatedAt);
                    break;
            }
            var propertyList = await queryable
                                .Skip(pageSize * (page - 1))
                                .Take(pageSize)
                                .ToListAsync();
            return propertyList ?? [];
        }

        public async Task<Property> GetByUrlAsync(string propertyUrl)
        {
            var item = await _dbContext.Properties
           .Where(x => !x.IsDeleted)
           .Include(x => x.ImageProperties)
           .Include(x => x.City)
           .FirstOrDefaultAsync(x => x.PropertyUrl == propertyUrl);
            return item ?? new Property();
        }

        public async Task AddPropertyAsync(PropertyDTO property)
        {
            try
            {
                var newProperty = new Property()
                {
                    PropertyUrl = ToUrl(property.Name + DateTime.Now.TimeOfDay),
                    Name = property.Name,
                    AvgPrice = property.AvgPrice,
                    IsDeleted = false,
                    CityID = property.CityID,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    District = property.District,
                    CreatedBy = property.CreatedBy,
                    Rule = property.Rule,
                    Street = property.Street,
                };
                await _dbContext.Properties.AddAsync(newProperty);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException);
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task UpdatePropertyAsync(PropertyDTO property, string propertyUrl)
        {
            try
            {
                var item = await _dbContext.Properties.FirstOrDefaultAsync(x => x.PropertyUrl == propertyUrl);
                if (item == null)
                {
                    throw new KeyNotFoundException($"{propertyUrl} not found");
                }
                else
                {
                    item.PropertyUrl = ToUrl(property.Name + DateTime.Now.TimeOfDay);
                    item.Name = property.Name;
                    item.District = property.District;
                    item.Street = property.Street;
                    item.UpdatedBy = property.UpdatedBy;
                    item.UpdatedAt = DateTime.Now;
                    item.AvgPrice = property.AvgPrice;
                    item.CityID = property.CityID;
                    item.Rule = property.Rule;
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException);
                throw new Exception(ex.Message, ex.InnerException);
            }

        }

        public async Task DeletePropertyAsync(string propertyUrl, string deletedBy)
        {
            try
            {
                var item = await _dbContext.Properties.FirstOrDefaultAsync(x => x.PropertyUrl == propertyUrl);
                if (item == null)
                {
                    throw new KeyNotFoundException($"{propertyUrl} not found");
                }
                else
                {
                    item.IsDeleted = true;
                    item.UpdatedBy = deletedBy;
                    item.UpdatedAt = DateTime.Now;
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException);
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
