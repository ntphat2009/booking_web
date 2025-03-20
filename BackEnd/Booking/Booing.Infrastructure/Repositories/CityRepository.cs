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
    public class CityRepository : ICityRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CategoryRepository> _logger;

        public CityRepository(ApplicationDbContext context, ILogger<CategoryRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IEnumerable<City>> GetAllCityAsync(int page, int pageSize, string sortBy, string? keyWord)
        {
            IQueryable<City> queryable = _context.Citys
                .AsNoTracking()
                .Where(x => !x.IsDeleted)
                .Include(c => c.Category)
                .Include(c => c.Properties);
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
                    queryable.OrderByDescending(x => x.Name);
                    break;
            }
            if (keyWord != null)
            {
                queryable.Where(x => x.CityUrl == keyWord);
            }
            var cityList = await queryable
                                .Skip(pageSize * (page - 1))
                                .Take(pageSize)
                                .ToListAsync();
            return cityList ?? [];
        }

        public async Task<City> GetCityByNameAsync(string cityUrl)
        {
            var city = await _context.Citys
                            .Where(x => !x.IsDeleted)
                            .Include(c => c.Category)
                            .Include(c => c.Properties)
                            .FirstOrDefaultAsync(c => c.CityUrl == cityUrl);
            return city ?? new City();
        }

        public async Task AddCityAsync(CityDTO city)
        {
            try
            {
                var newCity = new City()
                {
                    Banner = city.Banner,
                    CategoryId = city.CategoryId,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CreatedBy = city.CreatedBy,
                    UpdatedBy = city.CreatedBy,
                    IsDeleted = false,
                    Name = city.Name,
                    CityUrl = ToUrl(city.Name + DateTime.Now.TimeOfDay),
                };
                await _context.Citys.AddAsync(newCity);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Add city success");
            }
            catch (Exception ex)
            {
                _logger.LogError("Error to add city {}", ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateCityAsync(CityDTO city, string cityUrl)
        {
            try
            {
                var item = await _context.Citys.FirstOrDefaultAsync(c => c.CityUrl == cityUrl);
                if (item == null)
                {
                    throw new KeyNotFoundException("city Url not found");
                }
                else
                {
                    item.Name = city.Name;
                    item.CityUrl = ToUrl(city.Name + DateTime.Now.TimeOfDay);
                    item.UpdatedAt = DateTime.Now;
                    item.UpdatedBy = city.UpdatedBy;
                    item.Banner = city.Banner;
                    item.CategoryId = city.CategoryId;
                    item.IsDeleted = city.IsDeleted;
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException);
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteCityAsync(string cityUrl, string deletedBy)
        {
            try
            {
                var item = await _context.Citys.FirstOrDefaultAsync(c => c.CityUrl == cityUrl);
                if (item == null)
                {
                    throw new KeyNotFoundException("city Url not found");
                }
                else
                {
                    item.IsDeleted = true;
                    item.UpdatedAt = DateTime.Now;
                    item.UpdatedBy = deletedBy;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException);
                throw new Exception(ex.Message);
            }
        }
    }
}
