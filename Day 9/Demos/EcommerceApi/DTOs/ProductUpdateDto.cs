using System.ComponentModel.DataAnnotations;

namespace EcommerceApi.DTOs
{
    public class ProductUpdateDto
    {
        [Required(ErrorMessage = "ProductName is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "ProductName must be between 3 and 100 characters.")]
        public string ProductName { get; set; } = null!;

        [StringLength(500)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "StockQuantity cannot be negative.")]
        public int StockQuantity { get; set; }

        [Required(ErrorMessage = "CategoryId is required.")]
        public int CategoryId { get; set; }
    }
}
