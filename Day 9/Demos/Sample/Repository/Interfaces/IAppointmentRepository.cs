using HospitalAppointmentAPI.Dtos.Appointments;
using HospitalAppointmentAPI.Models;

namespace HospitalAppointmentAPI.Repository.Interfaces
{
    public interface IAppointmentRepository
    {
        Task<PagedResult<Appointment>> GetPagedAsync(AppointmentFilterRequestDto filter);
        Task<Appointment?> GetByIdAsync(int id);
        Task<Appointment> AddAsync(Appointment appointment);
        Task UpdateAsync(Appointment appointment);
        Task DeleteAsync(Appointment appointment);
        Task<bool> ExistsAsync(int id);
    }
}
