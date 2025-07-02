using BookingSystem.Domain.Entity;
using BookingSystem.Infrastructure.Data;
using BookingSystem.Infrastructure.DTOs;
using BookingSystem.Infrastructure.Repositories.InterfaceRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static BookingSystem.Common.Utilities.FormatUtilities;
using System.Data;
using BookingSystem.Infrastructure.Repositories.GenericRepository;
using System.Linq.Expressions;
using System.Globalization;


namespace BookingSystem.Infrastructure.Repositories.Implementations
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<CategoryRepository> _logger;

        public CategoryRepository(ApplicationDbContext dbContext, ILogger<CategoryRepository> logger) : base(dbContext)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public async Task<IEnumerable<Category>> GetAllCategoryAsync(int page, int pageSize, string sortBy)
        {
            try
            {
                var sortExpresstion = GetSortExpression(sortBy);
                return await GetsAsync(
                    page: page,
                    pageSize: pageSize,
                    sortBy: sortExpresstion,
                    filter: c => !c.IsDeleted
                    );
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
                _logger.LogWarning($"Category Name is null category_url : {cateUrl}");
                return new Category();
            }
            try
            {
                return await GetAsync(
                    predicate: c => c.CategoryUrl == cateUrl,
                    filter: c => !c.IsDeleted) ?? new Category();
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
                await AddAsync(newCategory);
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
                await DeleteAsync(category);
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
                    await UpdateAsync(query);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error to update {}", cateUrl);
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        protected override Expression<Func<Category, object>>? GetSortExpression(string sortBy)
        {
            return sortBy.ToLower() switch
            {
                "updateat" => c => c.UpdatedAt,
                "createdat" => c => c.CreatedAt,
                "name" => c => c.Name,
                _ => c => c.UpdatedAt
            };
        }
    }
}
