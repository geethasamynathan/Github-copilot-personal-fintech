using HospitalAppointmentAPI.Dtos.Common;
using HospitalAppointmentAPI.Dtos.Doctors;
using HospitalAppointmentAPI.Models;
using HospitalAppointmentAPI.Repository.Interfaces;
using HospitalAppointmentAPI.Services.Interfaces;

namespace HospitalAppointmentAPI.Services.Implementations
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<ApiResponseDto<DoctorResponseDto>> CreateAsync(DoctorCreateDto dto)
        {
            var doctor = new Doctor
            {
                DoctorName = dto.DoctorName,
                Specialization = dto.Specialization,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                City = dto.City,
                IsActive = dto.IsActive,
                CreatedDate = DateTime.UtcNow
            };

            var created = await _doctorRepository.AddAsync(doctor);
            return ApiResponseDto<DoctorResponseDto>.SuccessResponse(MapToDto(created), "Doctor created successfully");
        }

        public async Task<ApiResponseDto<bool>> DeleteAsync(int id)
        {
            var existing = await _doctorRepository.GetByIdAsync(id);
            if (existing == null)
            {
                return ApiResponseDto<bool>.Failure("Doctor not found");
            }

            await _doctorRepository.DeleteAsync(existing);
            return ApiResponseDto<bool>.SuccessResponse(true, "Doctor deleted successfully");
        }

        public async Task<ApiResponseDto<IEnumerable<DoctorResponseDto>>> GetAllAsync()
        {
            var doctors = await _doctorRepository.GetAllAsync();
            return ApiResponseDto<IEnumerable<DoctorResponseDto>>.SuccessResponse(doctors.Select(MapToDto), "Data fetched successfully");
        }

        public async Task<ApiResponseDto<DoctorResponseDto>> GetByIdAsync(int id)
        {
            var existing = await _doctorRepository.GetByIdAsync(id);
            if (existing == null)
            {
                return ApiResponseDto<DoctorResponseDto>.Failure("Doctor not found");
            }

            return ApiResponseDto<DoctorResponseDto>.SuccessResponse(MapToDto(existing), "Data fetched successfully");
        }

        public async Task<ApiResponseDto<DoctorResponseDto>> UpdateAsync(int id, DoctorUpdateDto dto)
        {
            var existing = await _doctorRepository.GetByIdAsync(id);
            if (existing == null)
            {
                return ApiResponseDto<DoctorResponseDto>.Failure("Doctor not found");
            }

            existing.DoctorName = dto.DoctorName;
            existing.Specialization = dto.Specialization;
            existing.Email = dto.Email;
            existing.PhoneNumber = dto.PhoneNumber;
            existing.City = dto.City;
            existing.IsActive = dto.IsActive;

            await _doctorRepository.UpdateAsync(existing);
            return ApiResponseDto<DoctorResponseDto>.SuccessResponse(MapToDto(existing), "Doctor updated successfully");
        }

        private static DoctorResponseDto MapToDto(Doctor doctor)
        {
            return new DoctorResponseDto
            {
                DoctorId = doctor.DoctorId,
                DoctorName = doctor.DoctorName,
                Specialization = doctor.Specialization,
                Email = doctor.Email,
                PhoneNumber = doctor.PhoneNumber,
                City = doctor.City,
                IsActive = doctor.IsActive,
                CreatedDate = doctor.CreatedDate
            };
        }
    }
}
