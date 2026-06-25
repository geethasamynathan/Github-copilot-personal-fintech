namespace HospitalAppointmentAPI.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public string AppointmentStatus { get; set; } = string.Empty;
        public string? Symptoms { get; set; }
        public DateTime CreatedDate { get; set; }

        public Doctor? Doctor { get; set; }
        public Patient? Patient { get; set; }
    }
}
