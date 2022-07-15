using System.Threading.Tasks;
using APILocacao.Data;
using APILocacao.Models;
using APILocacao.Repository.Interfaces;

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
         

    }
}