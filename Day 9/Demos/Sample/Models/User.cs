namespace HospitalAppointmentAPI.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string? Email { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; }

        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
