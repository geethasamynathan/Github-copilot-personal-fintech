namespace HospitalAppointmentAPI.Services.Interfaces
{
    public interface IJwtTokenService
    {
        string GenerateToken(int userId, string userName, IEnumerable<string> roles);
        DateTime GetExpiryDate();
    }
}
