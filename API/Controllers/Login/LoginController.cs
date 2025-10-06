using Application.UseCases.Login.Command;
using Application.UseCases.Login.Handler;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.Login;

namespace API.Controllers.Login
{
    [Route("api/User/Login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginHandler _loginHandler;

        public LoginController(ILoginHandler loginHandler)
        {
            _loginHandler = loginHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto Dto)
        {
            var command = new LoginCommand
            {
                Email = Dto.email,
                Password = Dto.password
            };

            var response = await _loginHandler.Handler(command);

            return response.IsSucess ?
                    Ok(response.Data) :
                    BadRequest(response.Message);
        }
    }
}
