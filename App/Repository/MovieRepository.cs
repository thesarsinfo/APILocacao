using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APILocacao.Data;
using APILocacao.Models;
using APILocacao.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APILocacao.Repository
{
    public class MovieRepository : BaseRepository, IMovieRepository
    {
        private readonly ApplicationDbContext _context;
        public MovieRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            // return await _context.Movies.AsNoTracking().ToListAsync();
            return await _context.Movies.Where(value => value.Status == true).ToListAsync();


        }

        public async Task<Movie> GetByIdMovieAsync(int id)
        {
            return await _context.Movies.FirstOrDefaultAsync(movie => movie.Id == id);
        }
        public async Task<Movie> DeleteMovieByIdAsync(int id)
        {
            return await _context.Movies.FirstOrDefaultAsync(movie => movie.Id == id);

        }

        public async Task<Movie> UpdateMovieByIdAsync(int id)
        {
            return await _context.Movies.FirstOrDefaultAsync(movie => movie.Id == id);
        }
    }
}