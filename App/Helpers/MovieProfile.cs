using AutoMapper;
using APILocacao.Models;
using APILocacao.DTO;

namespace APILocacao.Helpers
{
    public class MovieProfile : Profile
    {

        public MovieProfile()
        {

            CreateMap<MovieDTO, Movie>();
            CreateMap<MovieUpdateDTO, Movie>();
            CreateMap<MovieDTO, Movie>().ForAllMembers(opts => opts.Condition((srcMember) => srcMember != null));

        }

    }
}