using HospitalAppointmentAPI.Models;

namespace HospitalAppointmentAPI.Repository.Interfaces
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetAllAsync();
        Task<Patient?> GetByIdAsync(int id);
        Task<Patient> AddAsync(Patient patient);
        Task UpdateAsync(Patient patient);
        Task DeleteAsync(Patient patient);
        Task<bool> ExistsAsync(int id);
    }
}
