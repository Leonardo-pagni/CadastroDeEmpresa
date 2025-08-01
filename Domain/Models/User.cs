using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
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
            else if(string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(nome))
            {
                throw new ArgumentException("Todos os dados são necessários");
            }
            Email = email;
            Password = password.GenerateHash();
            Nome = nome;
        }
        public User(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Email ou senha não informados");
            }

            Email = email;
            Password = password.GenerateHash();
        }

        public User(string email)
        {
            if (string.IsNullOrEmpty(email) )
            {
                throw new ArgumentException("Email ou senha não informados");
            }

            Email = email;
        }
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nome { get; set; }
    }
}
