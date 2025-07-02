using BookingSystem.APIService.Services.Interfaces;
using BookingSystem.APIService.ViewModel;
using BookingSystem.Domain.Entity;
using BookingSystem.Infrastructure.DTOs;
using BookingSystem.Infrastructure.Repositories;
using BookingSystem.Infrastructure.Repositories.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.APIService.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _propertyRepository;

        public PropertyService(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }
        public async Task<IEnumerable<Property>> GetAllAsync(int page, int pageSize, string sortBy)
        {
            var property = await _propertyRepository.GetPropertiesAsync(page, pageSize, sortBy);
            return property;
        }
        public async Task<IEnumerable<PropertyVM>> GetByCityUrlAsync(string cityUrl, int page, int pageSize, string sortBy)
        {
            var property = await _propertyRepository.GetByCityUrlAsync(cityUrl, page, pageSize, sortBy);
            var propertiesVM = property.Select(p => new PropertyVM
            {
                Id = p.Id,
                Name = p.Name,
                PropertyUrl = p.PropertyUrl,
                Description = p.Description,
                IsDeleted = p.IsDeleted,
                Street = p.Street,
                District = p.District,
                UserId = p.UserId,
                CityName = p.City.Name,
                CityUrl = p.CityUrl,
                Rule = p.Rule,
                Tags = p.Tags,
                ImageProperty = p.ImageProperties?.FirstOrDefault(x => x.ImageType == 0)?.ImageUrl,
                AvgPrice = p.AvgPrice,
                Services = p.Services,
                CreatedAt = p.CreatedAt,
                CreatedBy = p.CreatedBy,
                UpdatedAt = p.UpdatedAt,
                UpdatedBy = p.UpdatedBy,
            }).ToList();
            return propertiesVM;
        }
        public async Task<Property> GetByUrlAsync(string propertyUrl)
        {
            return await _propertyRepository.GetByUrlAsync(propertyUrl);
        }
        public async Task AddPropertyAsync(PropertyDTO property)
        {
            await _propertyRepository.AddPropertyAsync(property);
        }
        public async Task UpdatePropertyAsync(PropertyDTO property, string propertyUrl)
        {
            await _propertyRepository.UpdatePropertyAsync(property, propertyUrl);
        }
        public async Task DeletePropertyAsync(string propertyUrl, string deletedBy)
        {
            await _propertyRepository.DeletePropertyAsync(propertyUrl, deletedBy);
        }

    }
}
