using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.User.Command
{
    public class CadastrarUserCommand
    {
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Password {  get; set; }
    }
}
