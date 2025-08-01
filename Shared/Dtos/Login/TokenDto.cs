using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos.Login
{
    public record TokenDto(string token, string refreshToken);
    public record RefreshTokenDto(string token);
}
