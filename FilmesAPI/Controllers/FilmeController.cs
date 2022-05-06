using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private readonly FilmeContext _context;
        private readonly IMapper _autoMapper;

        public FilmeController(FilmeContext context, IMapper autoMapper)
        {
            this._context = context;
            this._autoMapper = autoMapper;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarFilmePorId(int id)
        {
            var filme = _context.Filmes.Find(id);

            if (filme != null)
            {
                ReadFilmeDto filmeDto = _autoMapper.Map<ReadFilmeDto>(filme);

                return Ok(filme);
            }

            return NotFound();
        }

        [HttpGet]
        public IEnumerable<ReadFilmeDto> RecuperarFilmes()
        {
            return _context.Filmes.Select(filme => _autoMapper.Map<ReadFilmeDto>(filme));
        }

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
        {
            Filme filme = _autoMapper.Map<Filme>(filmeDto);

            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarFilmePorId), new { Id = filme.Id }, filme);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            var filmeDb = _context.Filmes.Find(id);

            if (filmeDb == null)
                return NotFound();

            _autoMapper.Map(filmeDto, filmeDb);

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult AtualizarFilme(int id)
        {
            var filmeDb = _context.Filmes.Find(id);

            if (filmeDb == null)
                return NotFound();

            _context.Filmes.Remove(filmeDb);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
