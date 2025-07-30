using Domain.Models.Empresa;

namespace Application.Repositories
{
    public interface IEmpresaRepository
    {
        Task Cadastrar(Empresa empresa);
        Task<List<Empresa>> PesquisarPaginada(int page, int pageSize);
    }
}

