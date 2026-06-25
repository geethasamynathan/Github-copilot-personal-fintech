using System.ComponentModel.DataAnnotations;

namespace HospitalAppointmentAPI.Dtos.Appointments
{
    public class AppointmentUpdateDto
    {
        [Required]
        public int DoctorId { get; set; }

        [Required]
        public int PatientId { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        [Required]
        public TimeSpan AppointmentTime { get; set; }

        [Required]
        [RegularExpression("^(Booked|Completed|Cancelled)$", ErrorMessage = "AppointmentStatus must be Booked, Completed, or Cancelled")]
        public string AppointmentStatus { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Symptoms { get; set; }
    }
}
