namespace HospitalAppointmentAPI.Dtos.Appointments
{
    public class AppointmentResponseDto
    {
        public int AppointmentId { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; } = string.Empty;
        public int PatientId { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public string AppointmentStatus { get; set; } = string.Empty;
        public string? Symptoms { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
