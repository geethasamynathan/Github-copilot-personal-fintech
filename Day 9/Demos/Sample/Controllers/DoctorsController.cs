using HospitalAppointmentAPI.Dtos.Common;
using HospitalAppointmentAPI.Dtos.Doctors;
using HospitalAppointmentAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAppointmentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorsController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _doctorService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _doctorService.GetByIdAsync(id);
            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DoctorCreateDto dto)
        {
            var result = await _doctorService.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = result.Data?.DoctorId }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DoctorUpdateDto dto)
        {
            var result = await _doctorService.UpdateAsync(id, dto);
            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _doctorService.DeleteAsync(id);
            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }
    }
}
