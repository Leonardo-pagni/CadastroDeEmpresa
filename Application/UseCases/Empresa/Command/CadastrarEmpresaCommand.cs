namespace Application.UseCases.Empresa.Command
{
    public class CadastrarEmpresaCommand
    {
        public string Cnpj { get; set; }

        public CadastrarEmpresaCommand(string cnpj)
        {
            Cnpj = cnpj;
        }
    }
}
