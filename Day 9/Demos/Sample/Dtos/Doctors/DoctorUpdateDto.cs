using System.ComponentModel.DataAnnotations;

namespace HospitalAppointmentAPI.Dtos.Doctors
{
    public class DoctorUpdateDto
    {
        [Required]
        [MaxLength(100)]
        public string DoctorName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Specialization { get; set; } = string.Empty;

        [EmailAddress]
        [MaxLength(100)]
        public string? Email { get; set; }

        [MaxLength(20)]
        public string? PhoneNumber { get; set; }

        [MaxLength(100)]
        public string? City { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
