using Api.Dtos;
using AutoMapper;
using Dominio.Entidades;

namespace Api.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Pelicula, PeliculaDto>().ReverseMap();
        }
    }
}