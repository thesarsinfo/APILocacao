using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APILocacao.Data;
using APILocacao.Models;
using APILocacao.Repository.Interfaces;

namespace APILocacao.Repository
{
    public class RentMovieRepository : IRentMovieRepository
    {
        private readonly ApplicationDbContext _context;
        public RentMovieRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Get(int CPF) 
        {
            //_context.Update(entity);
            //await _context.SaveChangesAsync();
            return 1;            
        }

        public async Task<int> Add(RentMovie entity) 
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return 1;            
        }
        public async Task<int> Update(RentMovie entity) 
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return 1;            
        }        
    }
}