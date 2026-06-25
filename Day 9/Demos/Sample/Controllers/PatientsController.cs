using HospitalAppointmentAPI.Dtos.Common;
using HospitalAppointmentAPI.Dtos.Patients;
using HospitalAppointmentAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAppointmentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _patientService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _patientService.GetByIdAsync(id);
            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PatientCreateDto dto)
        {
            var result = await _patientService.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = result.Data?.PatientId }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PatientUpdateDto dto)
        {
            var result = await _patientService.UpdateAsync(id, dto);
            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _patientService.DeleteAsync(id);
            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }
    }
}
