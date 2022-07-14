using AutoMapper;
using APILocacao.Models;
using APILocacao.DTO;

namespace APILocacao.Helpers
{
    public class RentMovieProfile : Profile
    {
        public RentMovieProfile()
        {
            CreateMap<RentMovie, RentMovieDTO>()
            .ForMember(dest => dest.ReturnMovie, opt => opt.Ignore());
            
        }
        
    }
}