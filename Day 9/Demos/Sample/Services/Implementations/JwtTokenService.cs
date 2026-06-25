using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HospitalAppointmentAPI.Common;
using HospitalAppointmentAPI.Models;
using HospitalAppointmentAPI.Services.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace HospitalAppointmentAPI.Services.Implementations
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly JwtSettings _settings;
        private DateTime _expiryDate;

        public JwtTokenService(IOptions<JwtSettings> settings)
        {
            _settings = settings.Value;
            _expiryDate = DateTime.UtcNow.AddMinutes(_settings.ExpiryMinutes);
        }

        public string GenerateToken(int userId, string userName, IEnumerable<string> roles)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, userName),
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.NameIdentifier, userId.ToString())
            };

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _settings.Issuer,
                audience: _settings.Audience,
                claims: claims,
                expires: _expiryDate,
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public DateTime GetExpiryDate()
        {
            return _expiryDate;
        }
    }
}
