using EcommerceApi.Models;

namespace EcommerceApi.Repositories.Interfaces
{
    public interface IProductRepository
    {
        /// <summary>
        /// Retrieves all products asynchronously.
        /// </summary>
        Task<IEnumerable<Product>> GetAllAsync();

        /// <summary>
        /// Retrieves a product by its ID asynchronously.
        /// </summary>
        Task<Product?> GetByIdAsync(int id);

        /// <summary>
        /// Creates a new product asynchronously.
        /// </summary>
        Task<Product> CreateAsync(Product product);

        /// <summary>
        /// Updates an existing product asynchronously.
        /// </summary>
        Task<Product> UpdateAsync(Product product);

        /// <summary>
        /// Deletes a product by its ID asynchronously.
        /// </summary>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// Checks if a product exists by its ID asynchronously.
        /// </summary>
        Task<bool> ExistsAsync(int id);
    }
}
