using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.User
{
    public class User
    {
        private User() { }  
        public User(string email, string password, string nome)
        {
            if (!email.Contains(".com") || !email.Contains("@"))
            {
                throw new ArgumentException("Email Inválido");
            }
            this.email = email;
            this.password = password.GenerateHash();
            this.nome = nome;
        }
        public int id { get; set; }
        public string email {  get; set; }
        public string password { get; set; }
        public string nome { get; set; }
    }
}
