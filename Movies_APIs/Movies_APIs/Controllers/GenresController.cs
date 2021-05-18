using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Movies_APIs.CustomActionFilters;
using Movies_APIs.DTOs;
using Movies_APIs.Entities;
using Movies_APIs.Entities.Contaxt;
using Movies_APIs.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies_APIs.Controllers
{


    [Route("api/genres")]
    [ApiController]
    public class GenresController: ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IRepository repository;
        private readonly ILogger<GenresController> logger;
        private readonly ApplicationDbContaxt contaxt;

        public GenresController(IMapper mapper,IRepository repository,ILogger<GenresController> logger, ApplicationDbContaxt contaxt)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.logger = logger;
            this.contaxt = contaxt;
        }



      ///  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        
        
        [HttpGet]
     
        public async Task<ActionResult<List<GenresDTO>>> Get()
        {
            var genres= await this.contaxt.Genres.ToListAsync();

            return mapper.Map<List<GenresDTO>>(genres);

        }

        [HttpGet("{id:int}",Name ="GetGenres")] /// api/genres/example?id=3
        public async Task<ActionResult<GenresDTO>> Get(int id)
        {
            var data = this.repository.GetGenrasById(id);

            if(data== null)
            {
                return NotFound();
            }

            return mapper.Map<GenresDTO>(data);
        }



        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GenresCreationDTO model)
        {
            if(ModelState.IsValid==false)
            {
                return BadRequest(ModelState);
            }
            var genre = mapper.Map<Genres>(model);
           await repository.AddGenra(genre);
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id,[FromBody] GenresCreationDTO model)
        {
            var gen = mapper.Map<Genres>(model);

            gen.Id = id;

            contaxt.Entry(gen).State = EntityState.Modified;

            await contaxt.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
           await this.repository.DeleteGenres(id);

            return NoContent();
        }

    }
}
