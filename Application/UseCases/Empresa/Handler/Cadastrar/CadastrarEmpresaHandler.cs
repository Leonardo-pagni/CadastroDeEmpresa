using Application.Repositories;
using Application.Services;
using Application.UseCases.Empresa.Command;
using Domain.Models;
using Domain.Models.Empresa;
using Shared.Reponses;
using System.Globalization;

namespace Application.UseCases.Empresa.Handler.Cadastrar;

public sealed class CadastrarEmpresaHandler : ICadastrarEmpresaHandler
{
    private readonly IEmpresaRepository _empresaRepository;
    private readonly ICnpjService _cnpjService;
    public CadastrarEmpresaHandler(IEmpresaRepository empresaRepository, ICnpjService cnpjService)
    {
        _empresaRepository = empresaRepository;
        _cnpjService = cnpjService;
    }

    public async Task<Response<EmpresaDto?>> Handler(CadastrarEmpresaCommand command)
    {
        try
        {
            var empresaDto = await _cnpjService.ObterDadosPorCnpj(command.Cnpj);

            var atividadesPrincipais = empresaDto.AtividadePrincipal
            .Select(a => new AtividadePrincipal(a.Codigo, a.Descricao))
            .ToList();

            var empresaEntity = new Domain.Models.Empresa.Empresa(empresaDto.NomeEmpresarial, empresaDto.NomeFantasia, empresaDto.CNPJ.Replace(".", "").Replace("/", ""), empresaDto.Situacao, DateTime.ParseExact(empresaDto.Abertura, "dd/MM/yyyy", CultureInfo.InvariantCulture), empresaDto.Tipo, empresaDto.NaturezaJuridica, atividadesPrincipais,
                new Domain.Models.Empresa.Endereco
                {
                    logradouro = empresaDto.Logradouro,
                    numero = empresaDto.Numero,
                    complemento = empresaDto.Complemento,
                    bairro = empresaDto.Bairro,
                    municipio = empresaDto.Municipio,
                    UF = empresaDto.UF,
                    cep = empresaDto.CEP
                });

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
