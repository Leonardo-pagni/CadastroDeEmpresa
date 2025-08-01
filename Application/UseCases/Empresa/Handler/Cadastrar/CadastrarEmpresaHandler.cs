using Application.Repositories;
using Application.Services;
using Application.UseCases.Empresa.Command;
using Domain.Models;
using Shared.Reponses;
using System.Globalization;

namespace Application.UseCases.Empresa.Handler.Cadastrar;

public sealed class CadastrarEmpresaHandler : ICadastrarEmpresaHandler
{
    private readonly IEmpresaRepository _empresaRepository;
    private readonly ICnpjService _cnpjService;
    private readonly IUserRepository _userRepository;
    public CadastrarEmpresaHandler(IEmpresaRepository empresaRepository, ICnpjService cnpjService, IUserRepository userRepository)
    {
        _empresaRepository = empresaRepository;
        _cnpjService = cnpjService;
        _userRepository = userRepository;
    }

    public async Task<Response<EmpresaDto?>> Handler(CadastrarEmpresaCommand command)
    {
        try
        {
            var empresaDto = await _cnpjService.ObterDadosPorCnpj(command.Cnpj);

            var atividadesPrincipais = empresaDto.AtividadePrincipal
            .Select(a => new AtividadePrincipal(a.Codigo, a.Descricao))
            .ToList();

            var userEntity = await _userRepository.GetUserByEmail();

            var empresaEntity = new Domain.Models.Empresa(empresaDto.NomeEmpresarial, empresaDto.NomeFantasia, empresaDto.CNPJ.Replace(".", "").Replace("/", "").Replace("-",""), empresaDto.Situacao, DateTime.ParseExact(empresaDto.Abertura, "dd/MM/yyyy", CultureInfo.InvariantCulture), empresaDto.Tipo, empresaDto.NaturezaJuridica, atividadesPrincipais,
                new Domain.Models.Endereco
                {
                    Logradouro = empresaDto.Logradouro,
                    Numero = empresaDto.Numero,
                    Complemento = empresaDto.Complemento,
                    Bairro = empresaDto.Bairro,
                    Municipio = empresaDto.Municipio,
                    UF = empresaDto.UF,
                    CEP = empresaDto.CEP
                }, userEntity);

            await _empresaRepository.Cadastrar(empresaEntity);

            return new Response<EmpresaDto?>(data: empresaDto, code: System.Net.HttpStatusCode.Created, "Empresa cadastrada com sucesso!");
        }
        catch (ArgumentException ex)
        {
            return new Response<EmpresaDto?>(data: null, code: System.Net.HttpStatusCode.BadRequest, ex.Message);
        }
        catch (Exception ex)
        {
            return new Response<EmpresaDto?>(data: null, code: System.Net.HttpStatusCode.InternalServerError, "Não foi possível criar a empresa!");
        }
    }
}
