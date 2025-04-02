using CadastroDeFuncionariosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroDeFuncionariosAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<FuncionarioModel> Funcionarios { get; set; }
        public DbSet<FilhoModel> Filhos { get; set; }
    }
}
