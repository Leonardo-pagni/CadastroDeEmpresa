using Application.UseCases.Login.Command;
using Application.UseCases.RefreshToken.Command;
using Application.UseCases.RefreshToken.Handler;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Shared.Dtos.Login;

namespace API.Controllers.Login
{
    [Route("api/login/refreshToken")]
    [ApiController]
    public class RefreshTokenController : ControllerBase
    {
        private readonly IRefreshTokenHandler _refreshTokenHandler;

        public RefreshTokenController(IRefreshTokenHandler refreshTokenHandler)
        {
            _refreshTokenHandler = refreshTokenHandler;
        }

        [HttpPost]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenDto token)
        {
            var command = new RefreshTokenCommand()
            {
                Token = token.token
            };

            var response = await _refreshTokenHandler.Handler(command);

            return response.IsSucess ?
                    Ok(response.Data) :
                    BadRequest(response.Message);
        }
    }
}
