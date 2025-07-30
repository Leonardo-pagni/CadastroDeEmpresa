using Application.Repositories;
using Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Cadastrar(User user)
        {
           await _appDbContext.Users.AddAsync(user);
           await _appDbContext.SaveChangesAsync();
        }
    }
}
