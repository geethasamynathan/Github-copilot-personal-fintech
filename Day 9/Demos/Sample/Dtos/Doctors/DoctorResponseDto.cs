namespace HospitalAppointmentAPI.Dtos.Doctors
{
    public class DoctorResponseDto
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? City { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
