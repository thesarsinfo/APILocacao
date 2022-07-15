using Microsoft.EntityFrameworkCore;
using APILocacao.Models;
using System;

namespace APILocacao.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<RentMovie> RentMovies { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbContextOptions<ApplicationDbContext> UseMySql(string connectionString, ServerVersion serverVersion)
        {
            throw new NotImplementedException();
        }
    }
}