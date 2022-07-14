using System.Threading.Tasks;
using APILocacao.Models;

namespace APILocacao.Repository.Interfaces
{
    public interface IRentMovieRepository
    {        
        
        public Task<int> Add(RentMovie entity);  
       
          
    }
}