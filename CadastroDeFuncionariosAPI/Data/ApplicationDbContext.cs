using CadastroDeFuncionariosAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CadastroDeFuncionariosAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Funcionario> Funcionarios { get; set; }
    }
}
