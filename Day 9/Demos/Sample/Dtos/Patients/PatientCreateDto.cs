using System.ComponentModel.DataAnnotations;

namespace HospitalAppointmentAPI.Dtos.Patients
{
    public class PatientCreateDto
    {
        [Required]
        [MaxLength(100)]
        public string PatientName { get; set; } = string.Empty;

        [EmailAddress]
        [MaxLength(100)]
        public string? Email { get; set; }

        [MaxLength(20)]
        public string? PhoneNumber { get; set; }

        [MaxLength(100)]
        public string? City { get; set; }

        public int? Age { get; set; }

        [MaxLength(20)]
        public string? Gender { get; set; }
    }
}
