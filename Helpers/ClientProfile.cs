using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APILocacao.Models;
using APILocacao.Models.DTO;
using AutoMapper;

namespace APILocacao.Helpers
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Client, ClientDetailsDTO>();

            CreateMap<ClientAddDTO, Client>();

            CreateMap<ClientupdateDTO, Client>()
            .ForAllMembers(opts => opts.Condition((srcMember) => srcMember != null));
        }
    }
}