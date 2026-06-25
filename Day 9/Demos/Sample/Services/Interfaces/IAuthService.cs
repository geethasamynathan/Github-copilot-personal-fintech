using HospitalAppointmentAPI.Dtos.Auth;
using HospitalAppointmentAPI.Dtos.Common;

namespace HospitalAppointmentAPI.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ApiResponseDto<LoginResponseDto>> LoginAsync(LoginRequestDto dto);
    }
}
