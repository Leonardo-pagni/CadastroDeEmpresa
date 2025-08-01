using Application.Repositories;
using Application.UseCases.Empresa.Queries;
using Shared.Reponses;
using System.Net;

namespace Application.UseCases.Empresa.Handler.ListarPaginada
{
    public class PesquisarEmpresaPaginadaHandler : IPesquisarEmpresaPaginadaHandler
    {
        private readonly IEmpresaRepository _repository;
        private readonly IUserRepository _userRepository;

        public PesquisarEmpresaPaginadaHandler(IEmpresaRepository repository, IUserRepository userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }

        public async Task<ResponsePaginada<List<EmpresaDto>>> Handler(PesquisarEmpresaPaginadaQuerie querie)
        {
            try
            {
                var UserEntity = await _userRepository.GetUserByEmail();

                var list = await _repository.PesquisarPaginadaPorUsuario(querie.page, querie.pageSize, UserEntity.Id);

                var empresas = list.Select(e => new EmpresaDto(
                    e.NomeEmpresarial,
                    e.NomeFantasia,
                    e.CNPJ,
                    e.Situacao,
                    e.Abertura.ToString("dd/MM/yyyy"),
                    e.Tipo,
                    e.NaturezaJuridica,
                    e.AtividadePrincipal.Select(a => new AtividadeDto(a.Codigo, a.Texto)).ToList(),
                    e.Endereco.Logradouro,
                    e.Endereco.Numero,
                    e.Endereco.Complemento,
                    e.Endereco.Bairro,
                    e.Endereco.Municipio,
                    e.Endereco.UF,
                    e.Endereco.CEP
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
