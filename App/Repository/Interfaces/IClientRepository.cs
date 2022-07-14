using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APILocacao.Models;
using APILocacao.Models.DTO;
using APILocacao.Repository.Interfaces;

namespace APILocacao.Repository.Interfaces
{
    public interface IClientRepository : IBaseRepository
    {
        Task<IEnumerable<Client>> GetAllByIdClientAsync();

        Task<Client> GetByIdClientAsync(ulong id);
        Task<Client> DeleteClientByIdAsync(ulong id);
    }
}