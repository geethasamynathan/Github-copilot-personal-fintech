using HospitalAppointmentAPI.Models;

namespace HospitalAppointmentAPI.Repository.Interfaces
{
    public interface IAuthRepository
    {
        Task<User?> GetByUserNameAsync(string userName);
        Task<IEnumerable<string>> GetRolesAsync(int userId);
    }
}
