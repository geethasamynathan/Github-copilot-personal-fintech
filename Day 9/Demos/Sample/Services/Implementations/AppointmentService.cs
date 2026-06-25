using HospitalAppointmentAPI.Dtos.Appointments;
using HospitalAppointmentAPI.Dtos.Common;
using HospitalAppointmentAPI.Models;
using HospitalAppointmentAPI.Repository.Interfaces;
using HospitalAppointmentAPI.Services.Interfaces;

namespace HospitalAppointmentAPI.Services.Implementations
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<ApiResponseDto<AppointmentResponseDto>> CreateAsync(AppointmentCreateDto dto)
        {
            var appointment = new Appointment
            {
                DoctorId = dto.DoctorId,
                PatientId = dto.PatientId,
                AppointmentDate = dto.AppointmentDate.Date,
                AppointmentTime = dto.AppointmentTime,
                AppointmentStatus = dto.AppointmentStatus,
                Symptoms = dto.Symptoms,
                CreatedDate = DateTime.UtcNow
            };

            var created = await _appointmentRepository.AddAsync(appointment);
            var response = MapToDto(created);
            return ApiResponseDto<AppointmentResponseDto>.SuccessResponse(response, "Appointment created successfully");
        }

        public async Task<ApiResponseDto<bool>> DeleteAsync(int id)
        {
            var existing = await _appointmentRepository.GetByIdAsync(id);
            if (existing == null)
            {
                return ApiResponseDto<bool>.Failure("Appointment not found");
            }

            await _appointmentRepository.DeleteAsync(existing);
            return ApiResponseDto<bool>.SuccessResponse(true, "Appointment deleted successfully");
        }

        public async Task<ApiResponseDto<PagedResponseDto<AppointmentResponseDto>>> GetPagedAsync(AppointmentFilterRequestDto filter)
        {
            if (filter.PageNumber <= 0)
            {
                return ApiResponseDto<PagedResponseDto<AppointmentResponseDto>>.Failure("PageNumber must be greater than 0");
            }

            if (filter.PageSize <= 0 || filter.PageSize > 100)
            {
                return ApiResponseDto<PagedResponseDto<AppointmentResponseDto>>.Failure("PageSize must be between 1 and 100");
            }

            var pagedResult = await _appointmentRepository.GetPagedAsync(filter);
            var response = new PagedResponseDto<AppointmentResponseDto>
            {
                PageNumber = pagedResult.PageNumber,
                PageSize = pagedResult.PageSize,
                TotalRecords = pagedResult.TotalRecords,
                TotalPages = pagedResult.TotalPages,
                Data = pagedResult.Items.Select(MapToDto)
            };

            return ApiResponseDto<PagedResponseDto<AppointmentResponseDto>>.SuccessResponse(response, "Data fetched successfully");
        }

        public async Task<ApiResponseDto<AppointmentResponseDto>> GetByIdAsync(int id)
        {
            var existing = await _appointmentRepository.GetByIdAsync(id);
            if (existing == null)
            {
                return ApiResponseDto<AppointmentResponseDto>.Failure("Appointment not found");
            }

            return ApiResponseDto<AppointmentResponseDto>.SuccessResponse(MapToDto(existing), "Data fetched successfully");
        }

        public async Task<ApiResponseDto<AppointmentResponseDto>> UpdateAsync(int id, AppointmentUpdateDto dto)
        {
            var existing = await _appointmentRepository.GetByIdAsync(id);
            if (existing == null)
            {
                return ApiResponseDto<AppointmentResponseDto>.Failure("Appointment not found");
            }

            existing.DoctorId = dto.DoctorId;
            existing.PatientId = dto.PatientId;
            existing.AppointmentDate = dto.AppointmentDate.Date;
            existing.AppointmentTime = dto.AppointmentTime;
            existing.AppointmentStatus = dto.AppointmentStatus;
            existing.Symptoms = dto.Symptoms;

            await _appointmentRepository.UpdateAsync(existing);
            return ApiResponseDto<AppointmentResponseDto>.SuccessResponse(MapToDto(existing), "Appointment updated successfully");
        }

        private static AppointmentResponseDto MapToDto(Appointment appointment)
        {
            return new AppointmentResponseDto
            {
                AppointmentId = appointment.AppointmentId,
                DoctorId = appointment.DoctorId,
                DoctorName = appointment.Doctor?.DoctorName ?? string.Empty,
                PatientId = appointment.PatientId,
                PatientName = appointment.Patient?.PatientName ?? string.Empty,
                AppointmentDate = appointment.AppointmentDate,
                AppointmentTime = appointment.AppointmentTime,
                AppointmentStatus = appointment.AppointmentStatus,
                Symptoms = appointment.Symptoms,
                CreatedDate = appointment.CreatedDate
            };
        }
    }
}
