using System;
using System.Linq;
using System.Threading.Tasks;
using APILocacao.Data;
using APILocacao.DTO;
using APILocacao.Models;
using APILocacao.Repository;
using APILocacao.Repository.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace APILocacao.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]

    public class RentMovieController : ControllerBase
    {        
        private readonly IRentMovieRepository _rentMovieRepository;

        public RentMovieController(IRentMovieRepository rentMovieRepository)
        {
            _rentMovieRepository = rentMovieRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddRent(RentMovieDTO rentMovieDTO)
        {
            if (ModelState.IsValid)
            {
                var clientId = await _rentMovieRepository.GetClientAsync(rentMovieDTO.ClientId);               
                var movieId = await _rentMovieRepository.GetMovieAsync(rentMovieDTO.MovieId);
                if (clientId == null || movieId == null)
                {                   
                    return NotFound("The client or movie does not exist in the database");
                } 
                if (movieId.Amount <= 0)
                {                    
                    return new ObjectResult("The chosen movie has already been rented ");
                }                                    
                RentMovie rentMovie = new RentMovie();                                  
                rentMovie.Clients = clientId;
                rentMovie.Movies = movieId;                
                rentMovie.FinalDeliveryDate = rentMovieDTO.FinalDeliveryDate;                
                rentMovie.TotalRent = rentMovieDTO.TotalRent;
                //business rule
                rentMovie.ReturnMovie = false;
                movieId.Amount -= 1;
                var responseMovie = await _rentMovieRepository.SetAmountMovie(movieId);              
                var responseDatabase = await _rentMovieRepository.AddRentMovie(rentMovie);             
                Response.StatusCode = 201;
                return new ObjectResult("The movie rental was successful");                      
            }
            else
            {
                Response.StatusCode = 400;
                return new ObjectResult("There was an error in the data submission model. Please correct the data");
            }           
<<<<<<< HEAD
=======
<<<<<<< HEAD
         }  
        // [HttpPut("{cpf}")]
        // public async Task<IActionResult> MovieReturn(ulong cpf)
        // {
        //     RentMovie rentMovie = new();
        //     var client = await _context.RentMovies
        //                  .Include(cli => cli.Clients)
        //                  .Include(mov => mov.Movies)
        //                  .Where(rent => rent.ReturnMovie == false)
        //                  .FirstOrDefaultAsync(cli => cli.Clients.CPF == cpf);                        
        //     if (client == null)
        //     {
        //         Response.StatusCode = 200;
        //         return new ObjectResult("The client has no one movie rented");
        //     }
        //     var today =  DateTime.Today;
        //     int finalDeliveryWarning = (int) today.Subtract(client.FinalDeliveryDate).TotalDays;
        //     if (finalDeliveryWarning > 0)
        //     {
        //         _logger.LogInformation("Cliente has a movie delayed " + client.Movies.Name);
        //         client.TotalRent = client.TotalRent * finalDeliveryWarning;                
        //     }
        //     client.ReturnMovie = true;
        //     _context.Update(client);
        //     await _context.SaveChangesAsync();  
           
        //     Movie movie = await _context.Movies.FirstOrDefaultAsync(mov => mov.Id == client.Movies.Id);          
        //     movie.Amount += 1;
        //     _context.Update(movie);
        //     await _context.SaveChangesAsync();
        //     return new ObjectResult("The has return with successfull");
        // }
=======
>>>>>>> 23325289f7ea69e9c34f53c23a999e5bd93e1315
        }  
        [HttpPut("{cpf}")]
        public async Task<IActionResult> MovieReturn(ulong cpf)
        {
            RentMovie rentMovie = new();
<<<<<<< HEAD
            var client = await _rentMovieRepository.GetRentMovie(cpf);         
=======
            var client = await _rentMovieRepository.GetRentMovie(cpf);
            // var client = await _context.RentMovies
            //              .Include(cli => cli.Clients)
            //              .Include(mov => mov.Movies)
            //              .Where(rent => rent.ReturnMovie == false)
            //              .FirstOrDefaultAsync(cli => cli.Clients.CPF == cpf);                        
>>>>>>> 23325289f7ea69e9c34f53c23a999e5bd93e1315
            if (client == null)
            {                
                return Ok("The client has no one movie rented");
            }
            
            var finalDeliveryWarning =(int)DateTime.Now.Subtract(client.FinalDeliveryDate).TotalDays;
            if (finalDeliveryWarning > 0)
            {                
                client.TotalRent = client.TotalRent * finalDeliveryWarning;                
            }
            client.ReturnMovie = true;
            await _rentMovieRepository.UpdateRentMovie(client);     
            var movie = await _rentMovieRepository.GetMovieAsync(client.Movies.Id);      
<<<<<<< HEAD
            //business rule
            movie.Amount += 1;       
            await _rentMovieRepository.SetAmountMovie(movie);
            return Ok("The movie has return with successfull");
        }
=======
            movie.Amount += 1;
            // Movie movie = await _context.Movies.FirstOrDefaultAsync(mov => mov.Id == client.Movies.Id);          
            await _rentMovieRepository.SetAmountMovie(movie);
            // _context.Update(movie);
            // await _context.SaveChangesAsync();
            return Ok("The movie has return with successfull");
        }
>>>>>>> 008ed2a1b8ae9b3f1ade4d9fcd74740b7b376e57
>>>>>>> 23325289f7ea69e9c34f53c23a999e5bd93e1315
    }
}