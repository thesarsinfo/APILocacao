using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APILocacao.Data;
using APILocacao.Models;
using APILocacao.Models.DTO;
using APILocacao.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APILocacao.Repository
{
    public class ClientRepository : BaseRepository, IClientRepository
    {
    
        private readonly ApplicationDbContext _context;
        public ClientRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task <IEnumerable<ClientDTO>> GetByIdClientAsync()
        {
            return await _context.Clients
            .Select(x => new ClientDTO { CPF = x.CPF, Name = x.Name})
            .ToListAsync();
        
        }

        public async Task <Client> GetByIdClientAsync(ulong id)
        {
            return await _context.Clients.Where(x => x.CPF == id).FirstOrDefaultAsync();
        }
        
    }
}