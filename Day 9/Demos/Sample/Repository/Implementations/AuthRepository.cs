using HospitalAppointmentAPI.Data;
using HospitalAppointmentAPI.Models;
using HospitalAppointmentAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HospitalAppointmentAPI.Repository.Implementations
{
    public class AuthRepository : IAuthRepository
    {
        private readonly HospitalAppointmentDbContext _context;

        public AuthRepository(HospitalAppointmentDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByUserNameAsync(string userName)
        {
            return await _context.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.UserName == userName && u.IsActive);
        }

        public async Task<IEnumerable<string>> GetRolesAsync(int userId)
        {
            return await _context.UserRoles
                .Where(ur => ur.UserId == userId)
                .Include(ur => ur.Role)
                .Select(ur => ur.Role != null ? ur.Role.RoleName : string.Empty)
                .Where(roleName => !string.IsNullOrEmpty(roleName))
                .ToListAsync();
        }
    }
}
