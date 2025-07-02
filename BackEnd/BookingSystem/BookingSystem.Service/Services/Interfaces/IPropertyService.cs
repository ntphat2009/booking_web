using BookingSystem.APIService.ViewModel;
using BookingSystem.Domain.Entity;
using BookingSystem.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.APIService.Services.Interfaces
{
    public interface IPropertyService
    {
        public Task<IEnumerable<Property>> GetAllAsync(int page, int pageSize, string sortBy);
        public Task<IEnumerable<PropertyVM>> GetByCityUrlAsync(string cityUrl, int page, int pageSize, string sortBy);
        public Task<Property> GetByUrlAsync(string propertyUrl);
        public Task AddPropertyAsync(PropertyDTO property);
        public Task UpdatePropertyAsync(PropertyDTO property, string propertyUrl);
        public Task DeletePropertyAsync(string propertyUrl, string deletedBy);
    }
}
