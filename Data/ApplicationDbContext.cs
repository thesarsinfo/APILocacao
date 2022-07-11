using Microsoft.EntityFrameworkCore;
using APILocacao.Models;

namespace APILocacao.Data
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<RentMovie> RentMovies{get;set;}
        public DbSet<Client> Clients{get;set;}
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}