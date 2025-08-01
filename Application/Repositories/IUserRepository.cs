using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IUserRepository
    {
        Task VerificaExistente(string email);
        Task Cadastrar(User user);
        Task VerificarLogin(User user);
        Task<User> GetUserByEmail();
    }
}
