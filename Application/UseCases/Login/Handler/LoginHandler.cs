using Application.Repositories;
using Application.Services;
using Application.UseCases.Login.Command;
using Shared.Dtos.Login;
using Shared.Reponses;

namespace Application.UseCases.Login.Handler
{
    public class LoginHandler : ILoginHandler
    {
        private readonly IUserRepository _useRepository;
        private readonly ITokenService _tokenService;

        public LoginHandler(IUserRepository useRepository, ITokenService tokenService)
        {
            _useRepository = useRepository;
            _tokenService = tokenService;
        }

        public async Task<Response<TokenDto?>> Handler(LoginCommand command)
        {
            try
            {
                var dto = new LoginDto(command.Email, command.Password);

                var loginEntity = new Domain.Models.User(dto.email, dto.password);

                await _useRepository.VerificarLogin(loginEntity);

                var token = _tokenService.GenerateToken(loginEntity);
                var refreshToken = _tokenService.GenerateRefreshToken(loginEntity);

                var dtoToken = new TokenDto(token, refreshToken);

                return new Response<TokenDto?>(data: dtoToken, code: System.Net.HttpStatusCode.OK, "");
            }
            catch (ArgumentException ex)
            {
                return new Response<TokenDto?>(data: null, code: System.Net.HttpStatusCode.BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                return new Response<TokenDto?>(data: null, code: System.Net.HttpStatusCode.InternalServerError, "Não foi possível fazer login!");
            }
        }
    }
}
