using Domain.Models;

namespace Application.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
        string GenerateRefreshToken(User user);
        Task<(bool isValid, string? email)> ValidateToken(string token);
    }
}
