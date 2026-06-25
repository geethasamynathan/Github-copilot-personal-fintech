using EcommerceApi.DTOs;
using EcommerceApi.Models;
using EcommerceApi.Repositories.Interfaces;
using EcommerceApi.Services.Interfaces;

namespace EcommerceApi.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductResponseDto>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return products.Select(p => MapToResponseDto(p)).ToList();
        }

        public async Task<ProductResponseDto?> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                return null;

            return MapToResponseDto(product);
        }

        public async Task<ProductResponseDto> CreateProductAsync(ProductCreateDto createDto)
        {
            ValidateProductDto(createDto);

            // Map DTO to entity
            var product = new Product
            {
                ProductName = createDto.ProductName,
                Description = createDto.Description,
                Price = createDto.Price,
                StockQuantity = createDto.StockQuantity,
                CategoryId = createDto.CategoryId
            };

            var createdProduct = await _productRepository.CreateAsync(product);
            return MapToResponseDto(createdProduct);
        }

        public async Task<ProductResponseDto> UpdateProductAsync(int id, ProductUpdateDto updateDto)
        {
            ValidateProductDto(updateDto);

            var existingProduct = await _productRepository.GetByIdAsync(id);
            if (existingProduct == null)
                throw new KeyNotFoundException($"Product with ID {id} not found.");

            // Update entity with DTO values
            existingProduct.ProductName = updateDto.ProductName;
            existingProduct.Description = updateDto.Description;
            existingProduct.Price = updateDto.Price;
            existingProduct.StockQuantity = updateDto.StockQuantity;
            existingProduct.CategoryId = updateDto.CategoryId;

            var updatedProduct = await _productRepository.UpdateAsync(existingProduct);
            return MapToResponseDto(updatedProduct);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            return await _productRepository.DeleteAsync(id);
        }

        // Manual mapping from Product entity to ProductResponseDto
        private ProductResponseDto MapToResponseDto(Product product)
        {
            return new ProductResponseDto
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Description = product.Description,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                CategoryId = product.CategoryId,
                CategoryName = product.Category?.CategoryName ?? string.Empty
            };
        }

        // Validation logic for product DTOs
        private void ValidateProductDto(ProductCreateDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.ProductName))
                throw new ArgumentException("Product name is required.");

            if (dto.Price <= 0)
                throw new ArgumentException("Price must be greater than zero.");

            if (dto.StockQuantity < 0)
                throw new ArgumentException("Stock quantity cannot be negative.");

            if (dto.CategoryId <= 0)
                throw new ArgumentException("CategoryId must be greater than zero.");
        }

        // Validation logic for update DTOs (same as create for now)
        private void ValidateProductDto(ProductUpdateDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.ProductName))
                throw new ArgumentException("Product name is required.");

            if (dto.Price <= 0)
                throw new ArgumentException("Price must be greater than zero.");

            if (dto.StockQuantity < 0)
                throw new ArgumentException("Stock quantity cannot be negative.");

            if (dto.CategoryId <= 0)
                throw new ArgumentException("CategoryId must be greater than zero.");
        }
    }
}
