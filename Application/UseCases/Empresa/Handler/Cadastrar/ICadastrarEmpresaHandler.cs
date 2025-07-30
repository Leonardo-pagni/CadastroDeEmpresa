using Application.UseCases.Empresa.Command;
using Shared.Reponses;

namespace Application.UseCases.Empresa.Handler.Cadastrar
{
    public interface ICadastrarEmpresaHandler
    {
        Task<Response<EmpresaDto?>> Handler(CadastrarEmpresaCommand command);
    }
}
