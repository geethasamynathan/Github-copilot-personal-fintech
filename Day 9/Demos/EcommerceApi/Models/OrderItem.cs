namespace EcommerceApi.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }

        // Foreign keys
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        // Navigation
        public Order Order { get; set; } = null!;
        public Product Product { get; set; } = null!;

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal { get; set; }
    }
}
