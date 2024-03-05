using System.Reflection;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Persistencia
{
    public class CodeContext : DbContext
    {
        public CodeContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Pelicula> Peliculas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}