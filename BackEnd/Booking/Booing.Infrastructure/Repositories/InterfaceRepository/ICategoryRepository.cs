using Booking.Domain.Entity;
using Booking.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastructure.Repositories.InterfaceRepository
{
    public interface ICategoryRepository
    {
        public Task<IEnumerable<Category>> GetAllCategoryAsync(int page, int pageSize, string sortBy);
        public Task<Category> GetCategoryAsync(string cateUrl);
        public Task AddCategoryAsync(CategoryDTO category);
        public Task UpdateCategoryAsync(CategoryDTO category, string cateUrl);
        public Task DeleteCategory(string cateUrl, string deletedBy);
    }
}
