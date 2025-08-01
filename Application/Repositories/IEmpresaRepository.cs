using Domain.Models;
using System.Globalization;

namespace Application.Repositories
{
    public interface IEmpresaRepository
    {
        Task Cadastrar(Empresa empresa);
        Task<List<Empresa>> PesquisarPaginadaPorUsuario(int page, int pageSize, int UsuarioId);
    }
}

