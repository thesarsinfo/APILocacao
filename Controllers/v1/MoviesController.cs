
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APILocacao.Data;
using APILocacao.DTO;
using APILocacao.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APILocacao.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> Get()
        {
            try
            {
                var movies = await _context.Movies.AsNoTracking().ToListAsync();
                if (movies is null)
                {
                    return NotFound("Movie not found");
                }
                return movies;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "There was a problem handling your request");
            }

        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                Movie movie = await _context.Movies.FirstOrDefaultAsync(movie => movie.Id == id);
                if (movie is null)
                {
                    return NotFound($"Filme com o Id: {id} não encontrado...");
                }
                return Ok(movie);
            }
            catch (Exception)
            {
                Response.StatusCode = 404;
                return new ObjectResult("");

            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] MovieDTO MovieDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Movie movie = new Movie();

                    movie.Name = MovieDTO.Name;
                    movie.Director = MovieDTO.Director;
                    movie.Synopsis = MovieDTO.Synopsis;
                    movie.Amount = MovieDTO.Amount;

                    _context.Movies.Add(movie);
                    _context.SaveChanges();

                    Response.StatusCode = 201;
                    return new ObjectResult("");

                }
                else
                {
                    Response.StatusCode = 400;
                    return new ObjectResult("Dados inválidos, verifique o dados enviados");
                }

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema  ao tratar sua solicitação");
            }


        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Movie movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
                movie.Status = false;
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                Response.StatusCode = 404;
                return new ObjectResult("");

            }
        }


        [HttpPatch]
        public IActionResult Patch([FromBody] Movie Movie)
        {
            if (Movie.Id > 0)
            {
                try
                {
                    var movie = _context.Movies.FirstOrDefault(movie => movie.Id == Movie.Id);
                    if (movie != null)
                    {

                        movie.Name = Movie.Name ?? movie.Name;
                        movie.Director = Movie.Director ?? movie.Director;
                        movie.Synopsis = Movie.Synopsis ?? movie.Synopsis;
                        movie.Amount = Movie.Amount != 0 ? Movie.Amount : movie.Amount;

                        _context.SaveChanges();
                        return Ok();
                    }
                    else
                    {
                        Response.StatusCode = 400;
                        return new ObjectResult(new { msg = "Filme não encontrado" });
                    }
                }
                catch
                {
                    Response.StatusCode = 400;
                    return new ObjectResult(new { msg = "Filme não encontrado" });
                }
            }
            else
            {

                Response.StatusCode = 400;
                return new ObjectResult(new { msg = "O id do filme é inválido" });
            }
        }

    }
}
