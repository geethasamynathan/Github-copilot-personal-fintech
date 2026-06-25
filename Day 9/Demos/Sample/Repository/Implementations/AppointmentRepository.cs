using HospitalAppointmentAPI.Data;
using HospitalAppointmentAPI.Dtos.Appointments;
using HospitalAppointmentAPI.Models;
using HospitalAppointmentAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HospitalAppointmentAPI.Repository.Implementations
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly HospitalAppointmentDbContext _context;

        public AppointmentRepository(HospitalAppointmentDbContext context)
        {
            _context = context;
        }

        public async Task<Appointment> AddAsync(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();
            return appointment;
        }

        public async Task DeleteAsync(Appointment appointment)
        {
            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<Appointment>> GetPagedAsync(AppointmentFilterRequestDto filter)
        {
            var query = _context.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .AsNoTracking()
                .AsQueryable();

            if (filter.DoctorId.HasValue)
            {
                query = query.Where(a => a.DoctorId == filter.DoctorId.Value);
            }

            if (filter.PatientId.HasValue)
            {
                query = query.Where(a => a.PatientId == filter.PatientId.Value);
            }

            if (!string.IsNullOrWhiteSpace(filter.AppointmentStatus))
            {
                query = query.Where(a => a.AppointmentStatus == filter.AppointmentStatus);
            }

            if (filter.AppointmentDate.HasValue)
            {
                query = query.Where(a => a.AppointmentDate == filter.AppointmentDate.Value.Date);
            }

            var totalRecords = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalRecords / (double)filter.PageSize);

            query = filter.SortBy?.ToLower() switch
            {
                "appointmentdate" => filter.SortDirection.ToLower() == "desc"
                    ? query.OrderByDescending(a => a.AppointmentDate)
                    : query.OrderBy(a => a.AppointmentDate),
                "appointmenttime" => filter.SortDirection.ToLower() == "desc"
                    ? query.OrderByDescending(a => a.AppointmentTime)
                    : query.OrderBy(a => a.AppointmentTime),
                "appointmentstatus" => filter.SortDirection.ToLower() == "desc"
                    ? query.OrderByDescending(a => a.AppointmentStatus)
                    : query.OrderBy(a => a.AppointmentStatus),
                _ => filter.SortDirection.ToLower() == "desc"
                    ? query.OrderByDescending(a => a.AppointmentDate)
                    : query.OrderBy(a => a.AppointmentDate)
            };

            var data = await query
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();

            return new PagedResult<Appointment>
            {
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                TotalRecords = totalRecords,
                TotalPages = totalPages,
                Items = data
            };
        }

        public async Task<Appointment?> GetByIdAsync(int id)
        {
            return await _context.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.AppointmentId == id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Appointments.AnyAsync(a => a.AppointmentId == id);
        }

        public async Task UpdateAsync(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            await _context.SaveChangesAsync();
        }
    }
}
