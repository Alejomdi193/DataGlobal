using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;
namespace Aplicacion.Repository
{
    public class PeliculaRepository : GenericRepository<Pelicula> , IPelicula
    {
        protected readonly CodeContext _context;
        public PeliculaRepository(CodeContext context) : base(context)
        {
            _context = context;
        }
    }
}