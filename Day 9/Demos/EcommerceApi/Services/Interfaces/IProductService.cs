using EcommerceApi.DTOs;

namespace EcommerceApi.Services.Interfaces
{
    public interface IProductService
    {
        /// <summary>
        /// Retrieves all products asynchronously.
        /// </summary>
        /// <returns>A collection of ProductResponseDto objects.</returns>
        Task<IEnumerable<ProductResponseDto>> GetAllProductsAsync();

        /// <summary>
        /// Retrieves a product by its ID asynchronously.
        /// </summary>
        /// <param name="id">The product ID.</param>
        /// <returns>A ProductResponseDto object if found; null otherwise.</returns>
        Task<ProductResponseDto?> GetProductByIdAsync(int id);

        /// <summary>
        /// Creates a new product asynchronously.
        /// </summary>
        /// <param name="createDto">The product creation data.</param>
        /// <returns>The created ProductResponseDto object.</returns>
        Task<ProductResponseDto> CreateProductAsync(ProductCreateDto createDto);

        /// <summary>
        /// Updates an existing product asynchronously.
        /// </summary>
        /// <param name="id">The product ID to update.</param>
        /// <param name="updateDto">The product update data.</param>
        /// <returns>The updated ProductResponseDto object.</returns>
        Task<ProductResponseDto> UpdateProductAsync(int id, ProductUpdateDto updateDto);

        /// <summary>
        /// Deletes a product by its ID asynchronously.
        /// </summary>
        /// <param name="id">The product ID to delete.</param>
        /// <returns>True if the product was deleted successfully; false otherwise.</returns>
        Task<bool> DeleteProductAsync(int id);
    }
}
