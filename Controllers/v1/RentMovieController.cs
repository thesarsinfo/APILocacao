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
        [HttpPost]
        public async Task<IActionResult> AddRent([FromBody] RentMovieDTO rentMovieDTO)
        {
            if (ModelState.IsValid)
            {
                var movie = await _context.Movies
                                .Where(mov => mov.Status == false)
                                .FirstOrDefaultAsync(mov => mov.Id == rentMovieDTO.MovieId);
                if(movie.Amount > 0)
                {
                    movie.Amount -= 1;
                    _context.Movies.Update(movie);
                    _context.SaveChanges();
                    RentMovie rentMovie = new RentMovie();
                    var clients = await _context.RentMovies.Include(cli => cli.Clients).FirstOrDefaultAsync(clie => clie.Clients.CPF == rentMovieDTO.ClientId);
                    var movies = await _context.RentMovies.Include(mov => mov).FirstOrDefaultAsync(mov => mov.Movies.Id == rentMovieDTO.MovieId);
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
                    return new ObjectResult("This movie is rented, please choose another movie");
                }                
            }
            else
            {
                Response.StatusCode = 400;
                return new ObjectResult("O modelo enviado não está correto, verifique o dados enviados");
            }            
        }  
        [HttpPut]
        public async Task<IActionResult> MovieReturn([FromBody] ulong cpf)
        {
            RentMovie rentMovie = new();
            var client = await _context.RentMovies
                        .Include(cli => cli.Clients)
                        .Include(mov => mov.Movies)
                        .Where(rent => rent.ReturnMovie == false)
                        .FirstOrDefaultAsync(cli => cli.Clients.CPF == cpf);                        
            if (client == null)
            {
                Response.StatusCode = 200;
                return new ObjectResult("The client has no one movie rented");
            }
            var today =  DateTime.Today;
            int finalDeliveryWarning = (int) today.Subtract(client.FinalDeliveryDate).TotalDays;
            if (finalDeliveryWarning > 0)
            {
                _logger.LogInformation("Cliente has a movie delayed " + client.Movies.Name);
                client.TotalRent = client.TotalRent * finalDeliveryWarning;                
            }
            client.ReturnMovie = true;
            _context.Update(client);
            await _context.SaveChangesAsync();  
           
            Movie movie = await _context.Movies.FirstOrDefaultAsync(mov => mov.Id == client.Movies.Id);          
            movie.Amount += 1;
            _context.Update(movie);
            await _context.SaveChangesAsync();
            return new ObjectResult("The has return with successfull");
        }

    }
}