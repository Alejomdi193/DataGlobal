using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class PeliculaDto
    {
        public string Titulo {get; set;}
        public string Director {get; set;}
        public int Anio {get; set;}
        public string Genero {get; set;}
    }
}