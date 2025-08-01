using Application.UseCases.Login.Command;
using Shared.Dtos.Login;
using Shared.Reponses;

namespace Application.UseCases.Login.Handler
{
    public interface ILoginHandler
    {
        Task<Response<TokenDto?>> Handler(LoginCommand command);
    }
}
