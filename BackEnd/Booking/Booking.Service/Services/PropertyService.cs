using Booking.ApiService.Services.Interfaces;
using Booking.Domain.Entity;
using Booking.Infrastructure.DTOs;
using Booking.Infrastructure.Repositories;
using Booking.Infrastructure.Repositories.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.ApiService.Services
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
            return await _propertyRepository.GetAllAsync(page, pageSize, sortBy);
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
