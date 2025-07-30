using Application.Repositories;
using Domain.Models.Empresa;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly AppDbContext _appDbContext;

        public EmpresaRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Cadastrar(Empresa empresa)
        {
            await _appDbContext.Empresa.AddAsync(empresa);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<Empresa>> PesquisarPaginada(int page, int pageSize)
        {
            return await _appDbContext.Empresa
            .AsNoTracking()
            .Include(e => e.Endereco)
            .Include(e => e.AtividadePrincipal)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        }
    }
}
