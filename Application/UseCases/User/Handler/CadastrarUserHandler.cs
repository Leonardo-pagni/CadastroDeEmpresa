using Application.Repositories;
using Application.UseCases.User.Command;
using Shared.Dtos.User;
using Shared.Reponses;

namespace Application.UseCases.User.Handler
{
    public class CadastrarUserHandler : ICadastrarUserHandler
    {
        private readonly IUserRepository _userRepository;

        public CadastrarUserHandler(IUserRepository repository)
        {
            _userRepository = repository;
        }

        public async Task<Response<UserDto?>> Handler(CadastrarUserCommand command)
        {
            try
            {
                var userDto = new UserDto(command.Email, command.Password, command.Nome);

                var UserEntity = new Domain.Models.User(userDto.email, userDto.password, userDto.nome);

                await _userRepository.VerificaExistente(UserEntity.Email);

                await _userRepository.Cadastrar(UserEntity);

                return new Response<UserDto?>(data: userDto, code: System.Net.HttpStatusCode.Created, "Usuário cadastrado com sucesso!");
            }
            catch (ArgumentException ex)
            {
                return new Response<UserDto?>(data: null, code: System.Net.HttpStatusCode.BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                return new Response<UserDto?>(data: null, code: System.Net.HttpStatusCode.InternalServerError, "Não foi possível cadastrar o usuário!");
            }
        }
    }
}
