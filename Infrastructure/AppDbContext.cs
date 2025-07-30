using Domain.Models.Empresa;
using Domain.Models.User;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
