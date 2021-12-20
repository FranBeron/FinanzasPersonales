using FinanzasPersonales.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanzasPersonales.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {

        }

        public DbSet<Gasto> Gasto { get; set; }
        public DbSet<Ingreso> Ingreso { get; set; }
        public DbSet<CategoriaGasto> CategoriaGastos { get; set; }
        public DbSet<CategoriaIngreso> CategoriaIngresos { get; set; }
    }
}
