using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class PeliculaConfiguration : IEntityTypeConfiguration<Pelicula>
    {
        public void Configure(EntityTypeBuilder<Pelicula> builder)
        {
            builder.ToTable("Pelicula");

            builder.HasKey(p => p.Id);

            builder.HasIndex(e => e.Id).IsUnique();

            builder.Property(e=>e.Id)
                .HasColumnName("Id")
                .HasColumnType("int");

            builder.Property(e => e.Titulo)
                .HasColumnName("Titulo")
                .HasColumnType("varchar")
                .HasMaxLength(80);
            
            builder.Property(e=>e.Director)
            .HasColumnName("Director")
                .HasColumnType("varchar")
                .HasMaxLength(80);

            builder.Property(e => e.Anio)
                .HasColumnName("Ano")
                .HasColumnType("int");

            builder.Property(e=> e.Genero)
                .HasColumnName("Genero")
                .HasColumnType("varchar")
                .HasMaxLength(80);   
        }
    }
}