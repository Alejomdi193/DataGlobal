using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IUnitOfWork
    {
        IPelicula Peliculas {get;}
        Task<int> SaveAsync();
    }
}