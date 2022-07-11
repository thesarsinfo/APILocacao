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
                
                RentMovie rentMovie = new RentMovie();
                var clients = await _context.RentMovies.Include(cli => cli.Clients).FirstOrDefaultAsync(clie => clie.Clients.CPF == rentMovieDTO.ClientId);
                var movies = await _context.RentMovies.Include(mov => mov).FirstOrDefaultAsync(movi => movi.Movies.Id == rentMovieDTO.MovieId);
                rentMovie.Clients =clients.Clients;
                rentMovie.Movies = movies.Movies;                
                rentMovie.FinalDeliveryDate = rentMovieDTO.FinalDeliveryDate;                
                rentMovie.TotalRent = rentMovieDTO.TotalRent;
                Response.StatusCode = 200;
                return new ObjectResult("Rent add with successful");
            }
            else
            {
                Response.StatusCode = 400;
                return new ObjectResult("O modelo enviado não está correto, verifique o dados enviados");
            }
            
        }

       
    }
}