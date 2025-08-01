using Application.Services;
using Application.UseCases.RefreshToken.Command;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Shared.Dtos.Login;
using Shared.Reponses;

namespace Application.UseCases.RefreshToken.Handler
{
    public class RefreshTokenHandler : IRefreshTokenHandler
    {
        private readonly ITokenService _tokenService;

        public RefreshTokenHandler(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public async Task<Response<TokenDto?>> Handler(RefreshTokenCommand command)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(command.Token))
                    throw new ArgumentException("Refresh Token vazio");

                var validate = await _tokenService.ValidateToken(command.Token);

                if (!validate.isValid)
                    throw new ArgumentException("Refresh Token inválido");

                var email = validate.email;

                var userEntity = new Domain.Models.User(email);

                //gerar token novamente
                var token = _tokenService.GenerateToken(userEntity);
                var refreshToken = _tokenService.GenerateRefreshToken(userEntity);

                var tokenDto = new TokenDto(token, refreshToken);

                return new Response<TokenDto?>(data: tokenDto, code: System.Net.HttpStatusCode.OK, "");
            }
            catch (ArgumentException ex)
            {
                return new Response<TokenDto?>(data: null, code: System.Net.HttpStatusCode.Unauthorized, ex.Message);
            }
            catch (Exception ex)
            {
                return new Response<TokenDto?>(data: null, code: System.Net.HttpStatusCode.InternalServerError, "Não foi possível gerar o Token");
            }
        }
    }
}
