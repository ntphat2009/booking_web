using Booking.Domain.Entity;
using Booking.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastructure.Repositories.InterfaceRepository
{
    public interface IPropertyRepository
    {
        public Task<IEnumerable<Property>> GetAllAsync(int page, int pageSize, string sortBy);
        public Task<Property> GetByUrlAsync(string propertyUrl);
        public Task AddPropertyAsync(PropertyDTO property);
        public Task UpdatePropertyAsync(PropertyDTO property, string propertyUrl);
        public Task DeletePropertyAsync(string propertyUrl, string deletedBy);
    }
}
