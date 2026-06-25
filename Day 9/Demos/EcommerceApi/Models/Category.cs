using System.Collections.Generic;

namespace EcommerceApi.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public string? Description { get; set; }

        // Navigation
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
