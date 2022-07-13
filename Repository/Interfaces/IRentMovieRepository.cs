using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APILocacao.Models;

namespace APILocacao.Repository.Interfaces
{
    public interface IRentMovieRepository
    {        
        
        public Task<int> Add(RentMovie entity);  
       
          
    }
}