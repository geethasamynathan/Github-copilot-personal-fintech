using HospitalAppointmentAPI.Data;
using HospitalAppointmentAPI.Models;
using HospitalAppointmentAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HospitalAppointmentAPI.Repository.Implementations
{
    public class PatientRepository : IPatientRepository
    {
        private readonly HospitalAppointmentDbContext _context;

        public PatientRepository(HospitalAppointmentDbContext context)
        {
            _context = context;
        }

        public async Task<Patient> AddAsync(Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
            return patient;
        }

        public async Task DeleteAsync(Patient patient)
        {
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Patient>> GetAllAsync()
        {
            return await _context.Patients.AsNoTracking().ToListAsync();
        }

        public async Task<Patient?> GetByIdAsync(int id)
        {
            return await _context.Patients.AsNoTracking().FirstOrDefaultAsync(p => p.PatientId == id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Patients.AnyAsync(p => p.PatientId == id);
        }

        public async Task UpdateAsync(Patient patient)
        {
            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();
        }
    }
}
