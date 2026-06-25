namespace HospitalAppointmentAPI.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? City { get; set; }
        public int? Age { get; set; }
        public string? Gender { get; set; }
        public DateTime CreatedDate { get; set; }

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
