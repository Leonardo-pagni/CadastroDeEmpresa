using Application.UseCases.Empresa.Command;
using Application.UseCases.User.Command;
using Shared.Dtos.User;
using Shared.Reponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.User.Handler
{
    public interface ICadastrarUserHandler
    {
        Task<Response<UserDto?>> Handler(CadastrarUserCommand command);
    }
}
