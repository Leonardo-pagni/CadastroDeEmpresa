using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.RefreshToken.Command
{
    public class RefreshTokenCommand
    {
        public string Token { get; set; }
    }
}
