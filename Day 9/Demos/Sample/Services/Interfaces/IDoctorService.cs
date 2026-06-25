using HospitalAppointmentAPI.Dtos.Common;
using HospitalAppointmentAPI.Dtos.Doctors;

namespace HospitalAppointmentAPI.Services.Interfaces
{
    public interface IDoctorService
    {
        Task<ApiResponseDto<IEnumerable<DoctorResponseDto>>> GetAllAsync();
        Task<ApiResponseDto<DoctorResponseDto>> GetByIdAsync(int id);
        Task<ApiResponseDto<DoctorResponseDto>> CreateAsync(DoctorCreateDto dto);
        Task<ApiResponseDto<DoctorResponseDto>> UpdateAsync(int id, DoctorUpdateDto dto);
        Task<ApiResponseDto<bool>> DeleteAsync(int id);
    }
}
