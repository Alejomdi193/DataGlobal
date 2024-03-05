using Api.Dtos;
using AutoMapper;
using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
 
    public class PeliculaController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PeliculaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PeliculaDto>>> GetAll()
        {
            var peliculas = await _unitOfWork.Peliculas.GetAllAsync();
            var peliculasDto = _mapper.Map<IEnumerable<PeliculaDto>>(peliculas);
            return Ok(peliculasDto);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PeliculaDto>> GetById(int id)
        {
            var pelicula = await _unitOfWork.Peliculas.GetByIdAsync(id);
            if (pelicula == null)
            {
                return NotFound();
            }
            var peliculaDto = _mapper.Map<PeliculaDto>(pelicula);
            return Ok(peliculaDto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PeliculaDto>> Create(PeliculaDto peliculaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pelicula = _mapper.Map<Pelicula>(peliculaDto);
            _unitOfWork.Peliculas.Add(pelicula);
            await _unitOfWork.SaveAsync();

            return CreatedAtAction(nameof(GetById), new { id = pelicula.Id }, _mapper.Map<PeliculaDto>(pelicula));
        }

       

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PeliculaDto>> Put(int id, [FromBody]PeliculaDto dataDto)
        {
           if(dataDto== null)
           {
               return NotFound();
           }
           var data = _mapper.Map<Pelicula>(dataDto);
           _unitOfWork.Peliculas.Update(data);
           await _unitOfWork.SaveAsync();
           return dataDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            var pelicula = await _unitOfWork.Peliculas.GetByIdAsync(id);
            if (pelicula == null)
            {
                return NotFound();
            }

            _unitOfWork.Peliculas.Remove(pelicula);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}
