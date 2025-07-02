using BookingSystem.Domain.Entity;
using BookingSystem.Infrastructure.Data;
using BookingSystem.Infrastructure.DTOs;
using BookingSystem.Infrastructure.Repositories.GenericRepository;
using BookingSystem.Infrastructure.Repositories.InterfaceRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static BookingSystem.Common.Utilities.FormatUtilities;

namespace BookingSystem.Infrastructure.Repositories.Implementations
{
    public class CityRepository : BaseRepository<City>, ICityRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CategoryRepository> _logger;

        public CityRepository(ApplicationDbContext context, ILogger<CategoryRepository> logger) : base(context)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IEnumerable<City>> GetAllCityAsync(int page, int pageSize, string sortBy, string? keyWord)
        {
            var sortExpression = GetSortExpression(sortBy);
            return await GetsAsync(
                page: page,
                pageSize: pageSize,
                sortBy: sortExpression,
                filter: c => !c.IsDeleted,
                includes: [c => c.Category, c => c.Properties]
                ) ?? [];
        }

        public async Task<City> GetCityByNameAsync(string cityUrl)
        {
            return await GetAsync(
                predicate: c => c.Name == cityUrl,
                filter: c => !c.IsDeleted,
                includes: [c => c.Category, c => c.Properties]
                ) ?? new City();
        }

        public async Task AddCityAsync(CityDTO city)
        {
            try
            {
                var newCity = new City()
                {
                    Banner = city.Banner,
                    CategoryUrl = city.CategoryUrl,
                    CategoryId = city.CategoryId,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CreatedBy = city.CreatedBy,
                    UpdatedBy = city.CreatedBy,
                    IsDeleted = false,
                    Name = city.Name,
                    CityUrl = ToUrl(city.Name + DateTime.Now.TimeOfDay),
                };
                await AddAsync(newCity);
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
                    item.CategoryUrl = city.CategoryUrl;
                    item.CategoryId = city.CategoryId;
                    item.IsDeleted = city.IsDeleted;
                    await UpdateAsync(item);
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
                    _logger.LogWarning($"city Url not found {cityUrl}");
                    throw new KeyNotFoundException($"city Url not found {cityUrl}");
                }
                else
                {
                    item.IsDeleted = true;
                    item.UpdatedAt = DateTime.Now;
                    item.UpdatedBy = deletedBy;
                    await DeleteAsync(item);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Delete city not succsess cityurl= {cityUrl}", ex);
                throw new Exception(ex.Message);
            }
        }

        protected override Expression<Func<City, object>>? GetSortExpression(string sortBy)
        {
            return sortBy.ToLower() switch
            {
                "updateat" => c => c.UpdatedAt,
                "name" => c => c.Name,
                _ => c => c.UpdatedAt
            };
        }
    }
}
