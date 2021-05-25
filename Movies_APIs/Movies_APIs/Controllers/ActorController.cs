using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies_APIs.DTOs;
using Movies_APIs.Entities;
using Movies_APIs.Entities.Contaxt;
using Movies_APIs.Helpers;
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
        private readonly IFileStorageService fileStorageService;
        private readonly string containerName = "actors";

        public ActorController(ApplicationDbContaxt context, IMapper mapper, IFileStorageService fileStorageService)
        {
            this.context = context;
            this.mapper = mapper;
            this.fileStorageService = fileStorageService;
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

        public async Task<ActionResult>Post([FromForm]ActorCreationDTO model)
        {
           var actor=mapper.Map<Actor>(model);
   
            if(model.Picture!= null)
            {
                actor.Picture = await fileStorageService.SaveFile(containerName, model.Picture);
            }


            context.Actors.Add(actor);

            await context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id,[FromForm] ActorCreationDTO model)
        {
            var actor =await context.Actors.Where(s => s.Id == id).FirstOrDefaultAsync();

            if(actor == null)
            {
                return NotFound();
            }

            actor = mapper.Map(model, actor);

            if(model.Picture != null)
            {
                actor.Picture = await fileStorageService.EditFile(containerName, model.Picture, actor.Picture);
            }

            await context.SaveChangesAsync();

            return NoContent();

        }



        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var actor = await context.Actors.FirstOrDefaultAsync(s => s.Id == id);

           
            if (actor == null)
            {
                return NotFound();
            }

          await this.fileStorageService.DeleteFile(actor.Picture, containerName);

             context.Actors.Remove(actor);

            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
