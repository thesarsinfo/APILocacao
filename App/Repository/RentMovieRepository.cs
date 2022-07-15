using System.Linq;
using System.Threading.Tasks;
using APILocacao.Data;
using APILocacao.Models;
using APILocacao.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APILocacao.Repository
{
    public class RentMovieRepository : BaseRepository, IRentMovieRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMovieRepository _movieRepository;
        private readonly IClientRepository _clientRepository;

        public RentMovieRepository(ApplicationDbContext context, IMovieRepository movieRepository, IClientRepository clientRepository)
        : base(context)
        {
            _context = context;
            _movieRepository = movieRepository;
            _clientRepository = clientRepository;
        }    

        public async Task<Movie> GetMovieAsync(int id) 
        {            
            return  await _movieRepository.GetByIdMovieAsync(id);                    
        }
        public async Task<Client> GetClientAsync(ulong id) 
        {            
            return  await _clientRepository.GetByIdClientAsync(id);                    
        }   
        public async Task<int> SetAmountMovie(Movie entity) 
        {            
              _context.Update(entity);   
              await _context.SaveChangesAsync();
              return 1;  
        }   
        public async Task<int> AddRentMovie(RentMovie entity) 
        {            
              _context.Add(entity);   
              await _context.SaveChangesAsync();
              return 1;  
        }  
        public async Task<RentMovie> GetRentMovie(ulong CPF)
        {
            return await _context.RentMovies
                         .Include(cli => cli.Clients)
                         .Include(mov => mov.Movies)
                         .Where(rent => rent.ReturnMovie == false)
                         .FirstOrDefaultAsync(cli => cli.Clients.CPF == CPF);                             
        }
        public async Task<int> UpdateRentMovie(RentMovie entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return 1;
        }
    }
}