using System.ComponentModel.DataAnnotations;

namespace EcommerceApi.DTOs
{
    public class CategoryUpdateDto
    {
        [Required]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "CategoryName is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "CategoryName must be between 3 and 100 characters.")]
        public string CategoryName { get; set; } = null!;

        [StringLength(500)]
        public string? Description { get; set; }
    }
}
