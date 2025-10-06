using Application.UseCases.Empresa.Command;
using Application.UseCases.Empresa.Handler.Cadastrar;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Empresa
{
    [Authorize]
    [ApiController]
    [Route("api/Empresa/CadastroDeEmpresa")]
    public class CadastroEmpresaController : ControllerBase
    {
        private readonly ICadastrarEmpresaHandler _cadastrarEmpresa;
        public CadastroEmpresaController(ICadastrarEmpresaHandler cadastrarEmpresa)
        {
            _cadastrarEmpresa = cadastrarEmpresa;
        }

        [HttpPost("{cnpj}")]
        public async Task<IActionResult> CadastrarEmpresa([FromRoute] string cnpj)
        {
            var useCase = new CadastrarEmpresaCommand(cnpj);

            var response = await _cadastrarEmpresa.Handler(useCase);

            return response.IsSucess ?
                    Created($"/{response.Data?.NomeEmpresarial}", response.Message) :
                    BadRequest(response);
        }
    }
}
