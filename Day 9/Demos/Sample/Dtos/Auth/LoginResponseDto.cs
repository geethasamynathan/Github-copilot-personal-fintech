namespace HospitalAppointmentAPI.Dtos.Auth
{
    public class LoginResponseDto
    {
        public int UserId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string? Email { get; set; }
        public IList<string> Roles { get; set; } = new List<string>();
        public string Token { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
    }
}
