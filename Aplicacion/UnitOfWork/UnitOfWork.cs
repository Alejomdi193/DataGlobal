using Aplicacion.Repository;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly CodeContext context;
        private PeliculaRepository _peliculas;
        public UnitOfWork(CodeContext _context)
        {
            context = _context;
        }

        public IPelicula Peliculas
        {
            get
            {
                if (_peliculas == null)
                {
                    _peliculas = new PeliculaRepository(context);
                }
                return _peliculas;
            }
        }
        public void Dispose()
        {
            context.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}