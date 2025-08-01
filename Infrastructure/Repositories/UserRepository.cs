using Application.Repositories;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserRepository(AppDbContext appDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _appDbContext = appDbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task Cadastrar(User user)
        {
           await _appDbContext.Users.AddAsync(user);
           await _appDbContext.SaveChangesAsync();
        }

        public async Task VerificaExistente(string email)
        {
            var Email = await _appDbContext.Users.AnyAsync(u => u.Email == email);

            if (Email)
            {
                throw new ArgumentException("Email Já cadastrado!");
            }
        }

        public async Task VerificarLogin(User user)
        {
            var achou = await _appDbContext.Users.AnyAsync(u => u.Email == user.Email && u.Password == user.Password);

            if(!achou)
            {
                throw new ArgumentException("Usuário não encontrado!");
            }
        }


        public async Task<User> GetUserByEmail()
        {
            var emailUsuario = _httpContextAccessor.HttpContext.User
                                .FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var user = await _appDbContext.Users
                            .FirstOrDefaultAsync(u => u.Email == emailUsuario);

            return user;
        }
    }
}
