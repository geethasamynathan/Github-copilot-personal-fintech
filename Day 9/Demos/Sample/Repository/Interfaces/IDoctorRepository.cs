using HospitalAppointmentAPI.Models;

namespace HospitalAppointmentAPI.Repository.Interfaces
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> GetAllAsync();
        Task<Doctor?> GetByIdAsync(int id);
        Task<Doctor> AddAsync(Doctor doctor);
        Task UpdateAsync(Doctor doctor);
        Task DeleteAsync(Doctor doctor);
        Task<bool> ExistsAsync(int id);
    }
}
