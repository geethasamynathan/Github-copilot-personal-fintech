using HospitalAppointmentAPI.Dtos.Auth;
using HospitalAppointmentAPI.Dtos.Common;
using HospitalAppointmentAPI.Repository.Interfaces;
using HospitalAppointmentAPI.Services.Interfaces;

namespace HospitalAppointmentAPI.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IJwtTokenService _jwtTokenService;

        public AuthService(IAuthRepository authRepository, IJwtTokenService jwtTokenService)
        {
            _authRepository = authRepository;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<ApiResponseDto<LoginResponseDto>> LoginAsync(LoginRequestDto dto)
        {
            var user = await _authRepository.GetByUserNameAsync(dto.UserName);
            if (user == null)
            {
                return ApiResponseDto<LoginResponseDto>.Failure("Invalid username or password");
            }

            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
            {
                return ApiResponseDto<LoginResponseDto>.Failure("Invalid username or password");
            }

            var roles = await _authRepository.GetRolesAsync(user.UserId);
            var token = _jwtTokenService.GenerateToken(user.UserId, user.UserName, roles);
            var expiresAt = _jwtTokenService.GetExpiryDate();

            var response = new LoginResponseDto
            {
                UserId = user.UserId,
                FullName = user.FullName,
                UserName = user.UserName,
                Email = user.Email,
                Roles = roles.ToList(),
                Token = token,
                ExpiresAt = expiresAt
            };

            return ApiResponseDto<LoginResponseDto>.SuccessResponse(response, "Login successful");
        }
    }
}
