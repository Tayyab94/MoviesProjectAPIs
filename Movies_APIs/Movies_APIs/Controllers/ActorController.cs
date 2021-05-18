using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies_APIs.DTOs;
using Movies_APIs.Entities.Contaxt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies_APIs.Controllers
{
    [Route("/api/actors")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly ApplicationDbContaxt context;
        private readonly IMapper mapper;

        public ActorController(ApplicationDbContaxt context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        [HttpGet]

        public async Task<ActionResult<List<ActorDTO>>>Get()
        {
            var actors = await context.Actors.ToListAsync();

            return mapper.Map<List<ActorDTO>>(actors);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ActorDTO>> Get(int id)
        {
            var actor = await context.Actors.FirstOrDefaultAsync(s => s.Id == id);

            if(actor== null)
            {
                return NotFound();
            }

            return mapper.Map<ActorDTO>(actor);
         }

        [HttpPost]

        public async Task<ActionResult>Post([FromBody]ActorCreationDTO model)
        {
            throw new  NotImplementedException();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id,[FromBody] ActorCreationDTO model)
        {
            throw new NotImplementedException();
        }



        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var actor = await context.Actors.FirstOrDefaultAsync(s => s.Id == id);

            if (actor == null)
            {
                return NotFound();
            }

             context.Actors.Remove(actor);

            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
