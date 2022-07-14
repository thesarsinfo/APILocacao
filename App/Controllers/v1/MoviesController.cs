
using System;
using System.Linq;
using System.Threading.Tasks;
using APILocacao.DTO;
using APILocacao.Models;
using APILocacao.Repository.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APILocacao.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMovieRepository _repository;


        public MoviesController(IMovieRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Movie>>> Get() LUIZ ALTEROU PASSAMOS ERRONEAMENTE O PARAMETRO <IEnumerable<Movie>> QUANDO O MESMO JÀ FOI PASSADO REPOSITORY
        public async Task<ActionResult> Get()
        {
            try
            {

                var movies = await _repository.GetAllMoviesAsync();

                return movies.Any()
                     ? Ok(movies)
                     : BadRequest("Movie Not Found");

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
                Movie movie = await _repository.GetByIdMovieAsync(id);
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

                    _repository.Add(movie);
                    await _repository.SaveChangesAsync();

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
                Movie movie = await _repository.DeleteMovieByIdAsync(id);
                movie.Status = false;
                await _repository.SaveChangesAsync();
                return Ok("Movie deleted successfully");
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
                    var movie = await _repository.UpdateMovieByIdAsync(id);
                    if (movie != null)
                    {

                        movie.Name = Movie.Name ?? movie.Name;
                        movie.Director = Movie.Director ?? movie.Director;
                        movie.Synopsis = Movie.Synopsis ?? movie.Synopsis;
                        movie.Amount = Movie.Amount != 0 ? Movie.Amount : movie.Amount;


                        await _repository.SaveChangesAsync();
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
