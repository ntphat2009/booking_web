using Booking.Domain.Entity;
using Booking.Infrastructure.Data;
using Booking.Infrastructure.DTOs;
using Booking.Infrastructure.Repositories.InterfaceRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Booking.Common.Utilities.FormatUtilities;
using System.Data;


namespace Booking.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<CategoryRepository> _logger;

        public CategoryRepository(ApplicationDbContext dbContext, ILogger<CategoryRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public async Task<IEnumerable<Category>> GetAllCategoryAsync(int page, int pageSize, string sortBy)
        {
            try
            {
                IQueryable<Category> query = _dbContext.Categories
               .AsNoTracking()
               .Where(c => !c.IsDeleted)
               .Include(c => c.Cities);
                query = sortBy.ToLower() switch
                {
                    "desc" => query.OrderByDescending(c => c.Name),
                    "asc" => query.OrderBy(c => c.Name),
                    "date_desc" => query.OrderByDescending(d => d.CreatedAt),
                    "date_asc" => query.OrderBy(d => d.CreatedAt),
                    _ => query.OrderByDescending(c => c.Name),
                };
                var categoryList = await query
                      .Skip(pageSize * (page - 1))
                      .Take(pageSize)
                      .ToListAsync();
                return categoryList ?? [];
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while get category");
                return [];
            }
        }


        public async Task<Category> GetCategoryAsync(string cateUrl)
        {
            if (string.IsNullOrWhiteSpace(cateUrl))
            {
                _logger.LogWarning("Category Name is null");
                return new Category();
            }
            try
            {
                var category = await _dbContext.Categories.AsNoTracking().Where(x => !x.IsDeleted).FirstOrDefaultAsync(x => x.CategoryUrl == cateUrl);
                return category ?? new Category();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error to get {}", cateUrl);
                throw;
            }
        }

        public async Task AddCategoryAsync(CategoryDTO category)
        {
            try
            {
                var newCategory = new Category
                {
                    Name = category.Name,
                    CategoryUrl = ToUrl(category.Name + DateTime.Now.TimeOfDay),
                    Image = category.Image,
                    Description = category.Description,
                    Icon = category.Icon,
                    CreatedAt = DateTime.Now,
                    IsDeleted = false,
                    CreatedBy = category.CreatedBy,
                    UpdatedAt = DateTime.Now,
                    UpdatedBy = category.CreatedBy,
                };
                await _dbContext.Categories.AddAsync(newCategory);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error to add");
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteCategory(string cateUrl, string deletedBy)
        {
            if (string.IsNullOrWhiteSpace(cateUrl))
            {
                _logger.LogWarning("Category Name is null or empty deletion cancled");
                return;
            }
            try
            {
                var category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.CategoryUrl == cateUrl);
                if (category == null)
                {
                    _logger.LogError("{a} not found", cateUrl);
                    throw new KeyNotFoundException($"{cateUrl} not found");
                }
                category.IsDeleted = true;
                category.UpdatedBy = deletedBy;
                category.UpdatedAt = DateTime.Now;
                await _dbContext.SaveChangesAsync();
                _logger.LogInformation("Delete {a} success", cateUrl);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while Delete category {a}", cateUrl);
            }
        }

        public async Task UpdateCategoryAsync(CategoryDTO category, string cateUrl)
        {
            try
            {
                var query = _dbContext.Categories.FirstOrDefault(cate => cate.CategoryUrl == cateUrl);
                if (query == null)
                {
                    _logger.LogError("{} is null", cateUrl);
                    throw new KeyNotFoundException($"{cateUrl} not found");
                }
                else
                {
                    query.Description = category.Description;
                    query.Name = category.Name;
                    query.CategoryUrl = ToUrl(category.Name + DateTime.Now.TimeOfDay);
                    query.UpdatedBy = category.UpdatedBy;
                    query.UpdatedAt = DateTime.Now;
                    query.Icon = category.Icon;
                    query.IsDeleted = category.IsDeleted;
                    query.Image = category.Image;
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error to update {}", cateUrl);
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
