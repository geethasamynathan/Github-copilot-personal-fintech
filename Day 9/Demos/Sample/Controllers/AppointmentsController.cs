using HospitalAppointmentAPI.Dtos.Appointments;
using HospitalAppointmentAPI.Dtos.Common;
using HospitalAppointmentAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAppointmentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentsController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Doctor,Receptionist,Patient")]
        public async Task<IActionResult> GetAll([FromQuery] AppointmentFilterRequestDto filter)
        {
            var result = await _appointmentService.GetPagedAsync(filter);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Doctor,Receptionist,Patient")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _appointmentService.GetByIdAsync(id);
            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Receptionist")]
        public async Task<IActionResult> Create([FromBody] AppointmentCreateDto dto)
        {
            var result = await _appointmentService.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = result.Data?.AppointmentId }, result);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Receptionist")]
        public async Task<IActionResult> Update(int id, [FromBody] AppointmentUpdateDto dto)
        {
            var result = await _appointmentService.UpdateAsync(id, dto);
            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _appointmentService.DeleteAsync(id);
            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }
    }
}
