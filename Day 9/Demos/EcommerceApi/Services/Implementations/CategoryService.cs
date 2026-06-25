using EcommerceApi.DTOs;
using EcommerceApi.Models;
using EcommerceApi.Repositories.Interfaces;
using EcommerceApi.Services.Interfaces;

namespace EcommerceApi.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoryResponseDto>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return categories.Select(MapToResponseDto);
        }

        public async Task<CategoryResponseDto?> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            return category == null ? null : MapToResponseDto(category);
        }

        public async Task<CategoryResponseDto> CreateCategoryAsync(CategoryCreateDto createDto)
        {
            var category = new Category
            {
                CategoryName = createDto.CategoryName,
                Description = createDto.Description
            };

            var createdCategory = await _categoryRepository.CreateAsync(category);
            return MapToResponseDto(createdCategory);
        }

        public async Task<CategoryResponseDto> UpdateCategoryAsync(int id, CategoryUpdateDto updateDto)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
                throw new KeyNotFoundException($"Category with ID {id} not found.");

            category.CategoryName = updateDto.CategoryName;
            category.Description = updateDto.Description;

            var updatedCategory = await _categoryRepository.UpdateAsync(category);
            return MapToResponseDto(updatedCategory);
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            return await _categoryRepository.DeleteAsync(id);
        }

        private static CategoryResponseDto MapToResponseDto(Category category)
        {
            return new CategoryResponseDto
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                Description = category.Description
            };
        }
    }
}
