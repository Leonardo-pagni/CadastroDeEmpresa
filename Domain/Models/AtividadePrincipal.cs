using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class AtividadePrincipal
    {
        public AtividadePrincipal(string codigo, string texto)
        {
            Codigo = codigo;
            Texto = texto;
        }
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Texto { get; set; }
    }
}
