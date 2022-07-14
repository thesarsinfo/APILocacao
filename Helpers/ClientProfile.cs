using APILocacao.Models;
using APILocacao.Models.DTO;
using AutoMapper;

namespace APILocacao.Helpers
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Client, ClientDTO>();

            CreateMap<ClientDTO, Client>();

            CreateMap<ClientupdateDTO, Client>()
            .ForAllMembers(opts => opts.Condition((srcMember) => srcMember != null));
        }
    }
}