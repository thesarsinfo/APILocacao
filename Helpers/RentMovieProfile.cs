using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using APILocacao.Models;
using APILocacao.DTO;

namespace APILocacao.Helpers
{
    public class RentMovieProfile : Profile
    {
        public RentMovieProfile()
        {
            CreateMap<RentMovie, RentMovieDTO>();
        }
        
    }
}