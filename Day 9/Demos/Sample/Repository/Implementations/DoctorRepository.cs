using HospitalAppointmentAPI.Data;
using HospitalAppointmentAPI.Models;
using HospitalAppointmentAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HospitalAppointmentAPI.Repository.Implementations
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly HospitalAppointmentDbContext _context;

        public DoctorRepository(HospitalAppointmentDbContext context)
        {
            _context = context;
        }

        public async Task<Doctor> AddAsync(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
            return doctor;
        }

        public async Task DeleteAsync(Doctor doctor)
        {
            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Doctor>> GetAllAsync()
        {
            return await _context.Doctors.AsNoTracking().ToListAsync();
        }

        public async Task<Doctor?> GetByIdAsync(int id)
        {
            return await _context.Doctors.AsNoTracking().FirstOrDefaultAsync(d => d.DoctorId == id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Doctors.AnyAsync(d => d.DoctorId == id);
        }

        public async Task UpdateAsync(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
            await _context.SaveChangesAsync();
        }
    }
}
