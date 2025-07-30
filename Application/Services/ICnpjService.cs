namespace Application.Services
{
    public interface ICnpjService
    {
        Task<EmpresaDto> ObterDadosPorCnpj(string cnpj);
    }
}
