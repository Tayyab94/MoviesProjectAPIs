using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies_APIs.DTOs;
using Movies_APIs.Entities;
using Movies_APIs.Entities.Contaxt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesTheatherController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ApplicationDbContaxt context;

        public MoviesTheatherController(IMapper mapper, ApplicationDbContaxt context)
        {
            this.mapper = mapper;
            this.context = context;
        }


        [HttpGet]

        public async Task<ActionResult<List<MoviesTheatherDTO>>> Get()
        {
            var entities = context.MoviesTheathers.ToListAsync();

            return mapper.Map<List<MoviesTheatherDTO>>(entities);
        }

        [HttpGet("{id:int}")]

        public async Task<ActionResult<MoviesTheatherDTO>>Get(int id)
        {
            var moviesTheather =await context.MoviesTheathers.FirstOrDefaultAsync(s => s.Id == id);

            if(moviesTheather == null)
            {
                return NotFound();
            }

            return mapper.Map<MoviesTheatherDTO>(moviesTheather);
        }

        [HttpPost]
        public async Task<ActionResult> Post(MoviesTheatherCreationDTO moviesTheatherCreation)
        {
            
            var moviesTheather =mapper.Map<MoviesTheather>(moviesTheatherCreation);

            context.MoviesTheathers.Add(moviesTheather);

            await context.SaveChangesAsync();

            return NoContent();

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id,MoviesTheatherCreationDTO moviesTheatherCreation)
        {

            var moviestheaterData = await context.MoviesTheathers.FirstOrDefaultAsync(s => s.Id == id);

            if(moviestheaterData == null)
            {
                return NotFound();
            }

            moviestheaterData = mapper.Map(moviesTheatherCreation, moviestheaterData);

            context.MoviesTheathers.Update(moviestheaterData);

            await context.SaveChangesAsync();

            return NoContent();

        }



        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var moviesTheather = await context.MoviesTheathers.FirstOrDefaultAsync(s => s.Id == id);


            if (moviesTheather == null)
            {
                return NotFound();
            }

            context.MoviesTheathers.Remove(moviesTheather);

            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
