
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APILocacao.Data;
using APILocacao.DTO;
using APILocacao.Models;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public MoviesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
                    return NotFound($"Movie with Id: {id} not found...");
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
        public async Task<IActionResult> Post([FromBody] MovieDTO MovieDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Movie movie = _mapper.Map<Movie>(MovieDTO);

                    await _context.Movies.AddAsync(movie);
                    await _context.SaveChangesAsync();

                    Response.StatusCode = 201;
                    return new ObjectResult("Movie successfully registered");

                }
                else
                {
                    Response.StatusCode = 400;
                    return new ObjectResult("Invalid data, check the data sent");
                }

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "There was a problem handling your request");
            }


        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Movie movie = await _context.Movies.FirstOrDefaultAsync(movie => movie.Id == id);
                movie.Status = false;
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {
                Response.StatusCode = 404;
                return new ObjectResult("");

            }
        }


        [HttpPatch("{id:int}")]
        public async Task<IActionResult> Patch(int id, MovieUpdateDTO Movie)
        {
            if (id > 0)
            {
                try
                {
                    var movie = await _context.Movies.FirstOrDefaultAsync(movie => movie.Id == id);
                    if (movie != null)
                    {

                        movie.Name = Movie.Name ?? movie.Name;
                        movie.Director = Movie.Director ?? movie.Director;
                        movie.Synopsis = Movie.Synopsis ?? movie.Synopsis;
                        movie.Amount = Movie.Amount != 0 ? Movie.Amount : movie.Amount;


                        await _context.SaveChangesAsync();
                        return Ok();
                    }
                    else
                    {
                        Response.StatusCode = 400;
                        return new ObjectResult(new { msg = "Movie not found" });
                    }
                }
                catch
                {
                    Response.StatusCode = 400;
                    return new ObjectResult(new { msg = "Movie not found" });
                }
            }
            else
            {

                Response.StatusCode = 400;
                return new ObjectResult(new { msg = "Movie not found" });
            }
        }

    }
}
