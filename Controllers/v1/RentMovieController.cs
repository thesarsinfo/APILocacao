using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APILocacao.Data;
using APILocacao.DTO;
using APILocacao.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace APILocacao.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RentMovieController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<RentMovieController> _logger;

        public RentMovieController(ApplicationDbContext context, ILogger<RentMovieController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> AddRent([FromBody] RentMovieDTO rentMovieDTO)
        {
            if (ModelState.IsValid)
            {
                var movie = await _context.Movies.FirstOrDefaultAsync(mov => mov.Id == rentMovieDTO.MovieId);
                if(movie.Amount > 0)
                {
                    movie.Amount = -1;
                    _context.Movies.Update(movie);
                    _context.SaveChanges();
                    RentMovie rentMovie = new RentMovie();
                    var clients = await _context.RentMovies.Include(cli => cli.Clients).FirstOrDefaultAsync(clie => clie.Clients.CPF == rentMovieDTO.ClientId);
                    var movies = await _context.RentMovies.Include(mov => mov).FirstOrDefaultAsync(movi => movi.Movies.Id == rentMovieDTO.MovieId);
                    rentMovie.Clients =clients.Clients;
                    rentMovie.Movies = movies.Movies;                
                    rentMovie.FinalDeliveryDate = rentMovieDTO.FinalDeliveryDate;                
                    rentMovie.TotalRent = rentMovieDTO.TotalRent;
                    rentMovie.ReturnMovie = false;
                    Response.StatusCode = 201;
                    return new ObjectResult("Rent add with successful");
                } 
                else
                {
                    Response.StatusCode = 200;
                    return new ObjectResult("The movie has be rented.");
                }                
            }
            else
            {
                Response.StatusCode = 400;
                return new ObjectResult("O modelo enviado não está correto, verifique o dados enviados");
            }            
        }  
        public async Task<IActionResult> MovieReturn([FromBody] ulong cpf)
        {
  
            var client = _context.RentMovies
                        .Include(cli => cli.Clients)
                        .Include(mov => mov.Movies)
                        .Where(clie => clie.Clients.CPF == cpf && clie.ReturnMovie == false);
            if (client == null)
            {
                Response.StatusCode = 200;
                return new ObjectResult("O cliente não tem nenhum filme alugado");
            }
            client.Select(cli => cli.FinalDeliveryDate <= DateTime.Today);
            
            
            return new ObjectResult("");
        }

    }
}