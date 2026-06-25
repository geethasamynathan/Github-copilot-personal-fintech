using HospitalAppointmentAPI.Dtos.Auth;
using HospitalAppointmentAPI.Dtos.Common;
using HospitalAppointmentAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAppointmentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            var result = await _authService.LoginAsync(request);
            if (!result.Success)
            {
                return Unauthorized(ApiResponseDto<object>.Failure(result.Message));
            }

            return Ok(result);
        }
    }
}
