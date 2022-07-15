using System.Threading.Tasks;
using APILocacao.Models;

namespace APILocacao.Repository.Interfaces
{
    public interface IRentMovieRepository 
    {
        public Task<Movie> GetMovieAsync(int id);
        public Task<Client> GetClientAsync(ulong id); 
        public Task<int> SetAmountMovie(Movie entity); 
        public Task<int> AddRentMovie(RentMovie entity);
        public Task<RentMovie> GetRentMovie(ulong CPF);
        public Task<int> UpdateRentMovie(RentMovie entity);

    }
}