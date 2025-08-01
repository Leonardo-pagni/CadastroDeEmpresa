namespace Domain.Models
{
    public class Empresa
    {
        private Empresa() { }
        public Empresa(string nomeEmpresarial, string nomeFantasia, string cnpj, string situacao, DateTime abertura, string tipo, string naturezaJuridica, List<AtividadePrincipal> atividadePrincipal, Endereco endereco, User user)
        {
            if (cnpj.Length != 14)
            {
                throw new ArgumentException("CNPJ INVÁLIDO! Tamanho diferente de 14 caracteres!");
            }

            NomeEmpresarial = nomeEmpresarial;
            NomeFantasia = nomeFantasia;
            CNPJ = cnpj;
            Situacao = situacao;
            Abertura = abertura;
            Tipo = tipo;
            NaturezaJuridica = naturezaJuridica;
            AtividadePrincipal = atividadePrincipal;
            Endereco = endereco;
            User = user;
        }


        public int Id { get; set; }
        public string NomeEmpresarial { get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
        public string Situacao { get; set; }
        public DateTime Abertura { get; set; }
        public string Tipo { get; set; }
        public string NaturezaJuridica { get; set; }
        public List<AtividadePrincipal> AtividadePrincipal { get; set; }
        public Endereco Endereco { get; set; }
        public User User { get; set; }

    }
}
