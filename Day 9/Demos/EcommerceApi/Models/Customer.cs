using System.Collections.Generic;

namespace EcommerceApi.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? MobileNumber { get; set; }
        public string? Address { get; set; }

        // Navigation
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
