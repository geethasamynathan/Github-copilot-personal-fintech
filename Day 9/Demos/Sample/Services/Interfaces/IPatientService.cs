using HospitalAppointmentAPI.Dtos.Common;
using HospitalAppointmentAPI.Dtos.Patients;

namespace HospitalAppointmentAPI.Services.Interfaces
{
    public interface IPatientService
    {
        Task<ApiResponseDto<IEnumerable<PatientResponseDto>>> GetAllAsync();
        Task<ApiResponseDto<PatientResponseDto>> GetByIdAsync(int id);
        Task<ApiResponseDto<PatientResponseDto>> CreateAsync(PatientCreateDto dto);
        Task<ApiResponseDto<PatientResponseDto>> UpdateAsync(int id, PatientUpdateDto dto);
        Task<ApiResponseDto<bool>> DeleteAsync(int id);
    }
}
