using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using APILocacao.Models;
using APILocacao.Repository.Interfaces;
using AutoMapper;
using System.Threading.Tasks;
using APILocacao.Models.DTO;
using Microsoft.AspNetCore.Http;

namespace APILocacao.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _repository;
        private readonly IMapper _mapper;

        public ClientController(IClientRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {

                var clients = await _repository.GetAllByIdClientAsync();

                return clients.Any()
                     ? Ok(clients)
                     : BadRequest("Client Not Found");

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "There was a problem handling your request");
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(ulong id)
        {
            try
            {
                var clients = await _repository.GetByIdClientAsync(id);



                //mapeando o objeto
                var clientReturn = _mapper.Map<ClientDTO>(clients);


                return clientReturn != null
                        ? Ok(clients)
                        : BadRequest("Not found client");
            }
            catch (System.Exception)
            {

                Response.StatusCode = 400;
                return new ObjectResult("Not found client");
            }

        }

        [HttpPost]

        public async Task<IActionResult> Post(ClientDTO client)
        {
            if (client == null) return BadRequest("Dados inválidos");

            var clientAdd = _mapper.Map<Client>(client);

            _repository.Add(clientAdd);

            return await _repository.SaveChangesAsync()
            ? Ok("Client Created")
            : BadRequest("Error created client");
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> Put(ulong id, ClientupdateDTO client)
        {
            if (id <= 0) return BadRequest("client not informed");
            var clientdatabase = await _repository.GetByIdClientAsync(id);

            var clietntUpdate = _mapper.Map(client, clientdatabase);

            _repository.Update(clietntUpdate);

            return await _repository.SaveChangesAsync()
        ? Ok("Updated client")
        : BadRequest("Error updating client");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(ulong id)
        {
            try
            {
                Client client = await _repository.DeleteClientByIdAsync(id);
                client.Status = false;
                await _repository.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {
                Response.StatusCode = 404;
                return new ObjectResult("");

            }
        }

    }
}