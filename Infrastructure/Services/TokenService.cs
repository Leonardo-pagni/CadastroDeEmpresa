using Application.Services;
using Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;

        public TokenService(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateRefreshToken(User user)
        {
            var JwtSettings = _config.GetSection("JwtSettings");

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSettings["SecretKey"] ?? string.Empty)); //deixei fixo no appSettings.Development, porém sei que não é o caso commitar essa informação!

            var claims = new List<Claim>()
            {
                new(JwtRegisteredClaimNames.Sub, user.Email),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };


            var pempoExpiracaoInMinutes = JwtSettings.GetValue<int>("RefreshExpirationTimeInMinutes");

            //Montagem Token
            var token = new JwtSecurityToken(
                issuer: JwtSettings.GetValue<string>("Issuer"),//quem emite o token
                audience: JwtSettings.GetValue<string>("Audience"),//quem consome
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(pempoExpiracaoInMinutes),
                signingCredentials: new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateToken(User user)
        {
            var JwtSettings = _config.GetSection("JwtSettings");

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSettings["SecretKey"] ?? string.Empty)); //deixei fixo no appSettings.Development, porém sei que não é o caso commitar essa informação!

            var claims = new List<Claim>()
            {
                new(JwtRegisteredClaimNames.Sub, user.Email),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };


            var pempoExpiracaoInMinutes = JwtSettings.GetValue<int>("ExpirationTimeInMinutes");

            //Montagem Token
            var token = new JwtSecurityToken(
                issuer: JwtSettings.GetValue<string>("Issuer"),//quem emite o token
                audience: JwtSettings.GetValue<string>("Audience"),//quem consome
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(pempoExpiracaoInMinutes),
                signingCredentials: new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<(bool isValid, string? email)> ValidateToken(string token)
        {
            var validTokenResult = await new JwtSecurityTokenHandler().ValidateTokenAsync(token, TokenHelper.TokenParameter(_config));

            if (!validTokenResult.IsValid)
                throw new ArgumentException("Token inválido");

            var email = validTokenResult.Claims.FirstOrDefault(c => c.Key == ClaimTypes.NameIdentifier).Value as string;

            return (true, email);
        }
    }
}
