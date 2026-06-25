namespace EcommerceApi.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

        // Foreign key
        public int CategoryId { get; set; }

        // Navigation
        public Category Category { get; set; } = null!;
    }
}
