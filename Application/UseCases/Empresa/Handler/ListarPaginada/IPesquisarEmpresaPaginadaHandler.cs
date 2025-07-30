using Application.UseCases.Empresa.Queries;
using Shared.Reponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Empresa.Handler.ListarPaginada
{
    public interface IPesquisarEmpresaPaginadaHandler
    {
        Task<ResponsePaginada<List<EmpresaDto>>> Handler(PesquisarEmpresaPaginadaQuerie querie);
    }
}
