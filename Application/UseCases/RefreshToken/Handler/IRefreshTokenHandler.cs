using Application.UseCases.RefreshToken.Command;
using Shared.Dtos.Login;
using Shared.Reponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.RefreshToken.Handler
{
    public interface IRefreshTokenHandler
    {
        Task<Response<TokenDto?>> Handler(RefreshTokenCommand commnad);
    }
}
