using HospitalAppointmentAPI.Dtos.Appointments;
using HospitalAppointmentAPI.Dtos.Common;

namespace HospitalAppointmentAPI.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<ApiResponseDto<PagedResponseDto<AppointmentResponseDto>>> GetPagedAsync(AppointmentFilterRequestDto filter);
        Task<ApiResponseDto<AppointmentResponseDto>> GetByIdAsync(int id);
        Task<ApiResponseDto<AppointmentResponseDto>> CreateAsync(AppointmentCreateDto dto);
        Task<ApiResponseDto<AppointmentResponseDto>> UpdateAsync(int id, AppointmentUpdateDto dto);
        Task<ApiResponseDto<bool>> DeleteAsync(int id);
    }
}
