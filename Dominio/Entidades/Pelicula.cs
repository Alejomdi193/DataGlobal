using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Pelicula : BaseEntity
    {
        public string Titulo {get; set;}
        public string Director {get; set;}
        public int Anio {get; set;}
        public string Genero {get; set;}
    }
}