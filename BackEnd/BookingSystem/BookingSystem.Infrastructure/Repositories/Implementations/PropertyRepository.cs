using BookingSystem.Domain.Entity;
using BookingSystem.Infrastructure.Data;
using BookingSystem.Infrastructure.DTOs;
using BookingSystem.Infrastructure.Repositories.GenericRepository;
using BookingSystem.Infrastructure.Repositories.InterfaceRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static BookingSystem.Common.Utilities.FormatUtilities;
namespace BookingSystem.Infrastructure.Repositories.Implementations
{
    public class PropertyRepository : BaseRepository<Property>, IPropertyRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<PropertyRepository> _logger;

        public PropertyRepository(ApplicationDbContext dbContext, ILogger<PropertyRepository> logger) : base(dbContext)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public async Task<IEnumerable<Property>> GetPropertiesAsync(int page, int pageSize, string sortBy)
        {
            var sortExpression = GetSortExpression(sortBy);
            return await GetsAsync(
                page: page,
                pageSize: pageSize,
                sortBy: sortExpression,
                filter: p => !p.IsDeleted,
                includes: [p => p.Rooms, p => p.ImageProperties, p => p.City]) ?? [];
        }
        public async Task<IEnumerable<Property>> GetByCityUrlAsync(string cityUrl, int page, int pageSize, string sortBy)
        {
            IQueryable<Property> queryable = _dbContext.Properties
                                     .AsNoTracking()
                                     .Include(x => x.City)
                                     .Where(x => !x.IsDeleted && x.CityUrl == cityUrl)
                                     .Include(x => x.ImageProperties)
                                     ;
            switch (sortBy.ToLower())
            {
                case "desc":
                    queryable = queryable.OrderByDescending(x => x.Name);
                    break;
                case "asc":
                    queryable = queryable.OrderBy(x => x.Name);
                    break;
                case "date_desc":
                    queryable = queryable.OrderByDescending(x => x.UpdatedAt);
                    break;
                case "date_asc":
                    queryable = queryable.OrderBy(x => x.UpdatedAt);
                    break;
                default:
                    queryable = queryable.OrderByDescending(x => x.UpdatedAt);
                    break;
            }
            IEnumerable<Property> propertyList = await queryable
                                .Skip(pageSize * (page - 1))
                                .Take(pageSize)
                                .ToListAsync();
            return propertyList ?? [];
        }

        public async Task<Property> GetByUrlAsync(string propertyUrl)
        {
            return await GetAsync(
                predicate: p => p.PropertyUrl == propertyUrl,
                filter: p => !p.IsDeleted,
                includes: [p => p.Rooms, p => p.City, p => p.User, p => p.ImageProperties]
                ) ?? new Property();
        }

        public async Task AddPropertyAsync(PropertyDTO property)
        {
            try
            {
                var newProperty = new Property()
                {
                    Id = Guid.NewGuid().ToString(),
                    PropertyUrl = ToUrl(property.Name + DateTime.Now.TimeOfDay),
                    Name = property.Name,
                    AvgPrice = property.AvgPrice,
                    IsDeleted = false,
                    CityUrl = property.CityUrl,
                    CityId = property.CityId,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    District = property.District,
                    CreatedBy = property.CreatedBy,
                    Rule = property.Rule,
                    Street = property.Street,
                    UserId = property.UserId,
                    Description = property.Description,
                };
                await AddAsync(newProperty);
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
                    item.Description = property.Description;
                    item.District = property.District;
                    item.Street = property.Street;
                    item.UpdatedBy = property.UpdatedBy;
                    item.UpdatedAt = DateTime.Now;
                    item.AvgPrice = property.AvgPrice;
                    item.CityUrl = property.CityUrl;
                    item.Rule = property.Rule;
                    await UpdateAsync(item);
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
                    await DeleteAsync(item);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException);
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        protected override Expression<Func<Property, object>>? GetSortExpression(string sortBy)
        {
            return sortBy.ToLower() switch
            {
                "updateat" => p => p.UpdatedAt,
                "name" => p => p.Name,
                _ => p => p.UpdatedAt
            };
        }
    }
}
