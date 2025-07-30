using Application.Repositories;
using Application.UseCases.Empresa.Queries;
using Shared.Reponses;
using System.Net;

namespace Application.UseCases.Empresa.Handler.ListarPaginada
{
    public class PesquisarEmpresaPaginadaHandler : IPesquisarEmpresaPaginadaHandler
    {
        private readonly IEmpresaRepository _repository;

        public PesquisarEmpresaPaginadaHandler(IEmpresaRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponsePaginada<List<EmpresaDto>>> Handler(PesquisarEmpresaPaginadaQuerie querie)
        {
            try
            {
                var list = await _repository.PesquisarPaginada(querie.page, querie.pageSize);

                var empresas = list.Select(e => new EmpresaDto(
                    e.NomeEmpresarial,
                    e.NomeFantasia,
                    e.CNPJ,
                    e.Situacao,
                    e.Abertura.ToString("dd/MM/yyyy"),
                    e.Tipo,
                    e.NaturezaJuridica,
                    e.AtividadePrincipal.Select(a => new AtividadeDto(a.Codigo, a.Texto)).ToList(),
                    e.Endereco.logradouro,
                    e.Endereco.numero,
                    e.Endereco.complemento,
                    e.Endereco.bairro,
                    e.Endereco.municipio,
                    e.Endereco.UF,
                    e.Endereco.cep
                )).ToList();

                var count = empresas.Count;

                return empresas is null ? new ResponsePaginada<List<EmpresaDto>>(data: null, count, querie.page, querie.pageSize) :
                     new ResponsePaginada<List<EmpresaDto>>(data: empresas, count, querie.page, querie.pageSize);
            }
            catch 
            {
                return new ResponsePaginada<List<EmpresaDto>>(data: null, HttpStatusCode.InternalServerError, "Empresas não localizadas.");
            }
        }
    }
}
