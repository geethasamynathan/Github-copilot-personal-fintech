using HospitalAppointmentAPI.Dtos.Common;
using HospitalAppointmentAPI.Dtos.Patients;
using HospitalAppointmentAPI.Models;
using HospitalAppointmentAPI.Repository.Interfaces;
using HospitalAppointmentAPI.Services.Interfaces;

namespace HospitalAppointmentAPI.Services.Implementations
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<ApiResponseDto<PatientResponseDto>> CreateAsync(PatientCreateDto dto)
        {
            var patient = new Patient
            {
                PatientName = dto.PatientName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                City = dto.City,
                Age = dto.Age,
                Gender = dto.Gender,
                CreatedDate = DateTime.UtcNow
            };

            var created = await _patientRepository.AddAsync(patient);
            return ApiResponseDto<PatientResponseDto>.SuccessResponse(MapToDto(created), "Patient created successfully");
        }

        public async Task<ApiResponseDto<bool>> DeleteAsync(int id)
        {
            var existing = await _patientRepository.GetByIdAsync(id);
            if (existing == null)
            {
                return ApiResponseDto<bool>.Failure("Patient not found");
            }

            await _patientRepository.DeleteAsync(existing);
            return ApiResponseDto<bool>.SuccessResponse(true, "Patient deleted successfully");
        }

        public async Task<ApiResponseDto<IEnumerable<PatientResponseDto>>> GetAllAsync()
        {
            var patients = await _patientRepository.GetAllAsync();
            return ApiResponseDto<IEnumerable<PatientResponseDto>>.SuccessResponse(patients.Select(MapToDto), "Data fetched successfully");
        }

        public async Task<ApiResponseDto<PatientResponseDto>> GetByIdAsync(int id)
        {
            var existing = await _patientRepository.GetByIdAsync(id);
            if (existing == null)
            {
                return ApiResponseDto<PatientResponseDto>.Failure("Patient not found");
            }

            return ApiResponseDto<PatientResponseDto>.SuccessResponse(MapToDto(existing), "Data fetched successfully");
        }

        public async Task<ApiResponseDto<PatientResponseDto>> UpdateAsync(int id, PatientUpdateDto dto)
        {
            var existing = await _patientRepository.GetByIdAsync(id);
            if (existing == null)
            {
                return ApiResponseDto<PatientResponseDto>.Failure("Patient not found");
            }

            existing.PatientName = dto.PatientName;
            existing.Email = dto.Email;
            existing.PhoneNumber = dto.PhoneNumber;
            existing.City = dto.City;
            existing.Age = dto.Age;
            existing.Gender = dto.Gender;

            await _patientRepository.UpdateAsync(existing);
            return ApiResponseDto<PatientResponseDto>.SuccessResponse(MapToDto(existing), "Patient updated successfully");
        }

        private static PatientResponseDto MapToDto(Patient patient)
        {
            return new PatientResponseDto
            {
                PatientId = patient.PatientId,
                PatientName = patient.PatientName,
                Email = patient.Email,
                PhoneNumber = patient.PhoneNumber,
                City = patient.City,
                Age = patient.Age,
                Gender = patient.Gender,
                CreatedDate = patient.CreatedDate
            };
        }
    }
}
