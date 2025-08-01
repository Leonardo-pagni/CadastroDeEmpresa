using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class TokenHelper
    {
        public static TokenValidationParameters TokenParameter(IConfiguration configuration)
        {
            var tokenKey = Encoding.UTF8.GetBytes(configuration["JwtSettings:SecretKey"] ?? string.Empty);

            return new TokenValidationParameters()
            {
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                ValidateAudience = true,
                ValidAudience = configuration["JwtSettings:Audience"],
                ValidateIssuer = true,
                ValidIssuer = configuration["JwtSettings:Issuer"],
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(tokenKey)
            };
            
        }
    }
}
