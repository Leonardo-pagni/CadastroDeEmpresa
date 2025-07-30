using Application.UseCases.Empresa.Handler.ListarPaginada;
using Application.UseCases.Empresa.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace API.Controllers.Empresa
{
    [ApiController]
    [Route("api/Empresa/PesquisaEmpresa")]
    public class PesquisaPaginadaEmpresaController : ControllerBase
    {
        private readonly IPesquisarEmpresaPaginadaHandler _pesquisarEmpresaPaginada;

        public PesquisaPaginadaEmpresaController(IPesquisarEmpresaPaginadaHandler handler)
        {
            _pesquisarEmpresaPaginada = handler;
        }


        [HttpGet]
        public async Task<IActionResult> PesquisarEmpresaPaginada([FromQuery]int? pageSize, [FromQuery] int? page)
        {

            var querie = new PesquisarEmpresaPaginadaQuerie
            {
                page = page ?? 1, 
                pageSize = pageSize ?? 25
            };

            var response = await _pesquisarEmpresaPaginada.Handler(querie);

            return response.IsSucess ? Ok(response) : BadRequest(response);
        }
    }
}
