using System;
using System.Collections.Generic;

namespace EcommerceApi.Models
{
    public enum OrderStatus
    {
        Pending,
        Processing,
        Completed,
        Cancelled
    }

    public class Order
    {
        public int OrderId { get; set; }

        // Foreign key
        public int CustomerId { get; set; }

        // Navigation
        public Customer Customer { get; set; } = null!;

        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public decimal TotalAmount { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
