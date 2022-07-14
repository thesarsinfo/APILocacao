using System.Collections.Generic;
using System.Threading.Tasks;
using APILocacao.Models;

namespace APILocacao.Repository.Interfaces
{
    public interface IMovieRepository : IBaseRepository
    {
        Task<IEnumerable<Movie>> GetAllMoviesAsync();

        Task<Movie> GetByIdMovieAsync(int id);

        Task<Movie> DeleteMovieByIdAsync(int id);

        Task<Movie> UpdateMovieByIdAsync(int id);

    }
}