using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using APILocacao.Data;
using APILocacao.Models;

namespace APILocacao.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ClientController(ApplicationDbContext context)
        {
            _context = context;

        }
        [HttpGet("{id}")]
        public IActionResult Get(ulong id)
        {

            try
            {
                var client = _context.Clients.First(p => p.CPF == id);
                //Colocar HATEOS
                return Ok(client);
            }
            catch (Exception)
            {
                Response.StatusCode = 404;
                return new ObjectResult("");
            }
        }



        [HttpPost]
        public IActionResult Post([FromBody] Client Tclient)
        {


            /*Validação*/
        //Colocar HATEOS


            Client c = new Client();
            c.CPF = Tclient.CPF;
            c.Name = Tclient.Name;
            c.Lastname = Tclient.Lastname;
            c.Telephone = Tclient.Telephone;
            c.Address = Tclient.Address;
            c.DateOfBirth = Tclient.DateOfBirth;
            c.Status = Tclient.Status;
            
            _context.Clients.Add(c);
            _context.SaveChanges();

            Response.StatusCode = 201;
            return new ObjectResult("");

        }
    }
}