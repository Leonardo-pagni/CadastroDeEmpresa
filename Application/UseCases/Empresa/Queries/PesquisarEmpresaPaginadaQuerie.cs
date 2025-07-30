using Domain;

namespace Application.UseCases.Empresa.Queries
{
    public class PesquisarEmpresaPaginadaQuerie
    {
        public int page { get; set; } = Configuration.DefaultPageNumber;
        public int pageSize { get; set; } = Configuration.DefaultPageNumber;
    }
}
