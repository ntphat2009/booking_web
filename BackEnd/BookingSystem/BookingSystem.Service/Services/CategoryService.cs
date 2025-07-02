using BookingSystem.APIService.Services.Interfaces;
using BookingSystem.Domain.Entity;
using BookingSystem.Infrastructure.DTOs;
using BookingSystem.Infrastructure.Repositories.InterfaceRepository;


namespace BookingSystem.APIService.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<IEnumerable<Category>> GetAllCategoryAsync(int page, int pageSize, string sortBy)
        {
            return await _categoryRepository.GetAllCategoryAsync(page, pageSize, sortBy);
        }

        public async Task<Category> GetCategoryAsync(string cateUrl)
        {
            return await _categoryRepository.GetCategoryAsync(cateUrl);
        }

        public async Task AddCategoryAsync(CategoryDTO category)
        {
            await _categoryRepository.AddCategoryAsync(category);
        }

        public async Task UpdateCategoryAsync(CategoryDTO category, string cateUrl)
        {
            await _categoryRepository.UpdateCategoryAsync(category, cateUrl);
        }

        public async Task DeleteCategory(string cateUrl, string deletedBy)
        {
            await _categoryRepository.DeleteCategory(cateUrl, deletedBy);
        }
    }
}
