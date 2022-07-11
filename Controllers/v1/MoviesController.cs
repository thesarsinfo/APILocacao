using System;
using System.Collections.Generic;
using System.Linq;
using APILocacao.Data;
using APILocacao.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APILocacao.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Movie>> Get()
        {
            try
            {
                var movies = _context.Movies.AsNoTracking().ToList();
                if (movies is null)
                {
                    return NotFound("Movie not found");
                }
                return movies;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "There was a problem handling your request");
            }

        }


    }
}