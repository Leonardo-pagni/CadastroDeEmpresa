using Application.UseCases.User.Command;
using Application.UseCases.User.Handler;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.User;

namespace API.Controllers.User
{
    [Route("api/User/Cadastrar")]
    [ApiController]
    public class CadastrarUserController : ControllerBase
    {
        private readonly ICadastrarUserHandler _cadastrarUser;

        public CadastrarUserController(ICadastrarUserHandler cadastrarUser)
        {
            _cadastrarUser = cadastrarUser;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarUser([FromBody] UserDto dto)
        {

            var command = new CadastrarUserCommand
            {
                Email = dto.email, 
                Password = dto.password,
                Nome = dto.nome
            };

            var response = await _cadastrarUser.Handler(command);

            return response.IsSucess ?
                    Created($"/{response.Data?.email}", response.Message) :
                    BadRequest(response);
        }
    }
}
