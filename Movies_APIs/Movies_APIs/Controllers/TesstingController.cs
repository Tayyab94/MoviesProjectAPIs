using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Movies_APIs.CustomActionFilters;
using Movies_APIs.Entities;
using Movies_APIs.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies_APIs.Controllers
{


    [Route("api/testing")]
    [ApiController]
    public class TesstingController : ControllerBase
    {
        private readonly IRepository repository;
        private readonly ILogger<GenresController> logger;
            
        public TesstingController(IRepository repository,ILogger<GenresController> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }



      ///  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        
        
        [HttpGet]
        [HttpGet("list")] // api/genres/list
        [HttpGet("/allList")] //allList
        [ResponseCache(Duration =10)]

        // Applying Custom action Filter

        [ServiceFilter(typeof(MyActionFilter))]
        public async Task<ActionResult<List<Genres>>> Get()
        {
            return  await repository.GetAllRenres();
        }

        [HttpGet("example")] /// api/genres/example?id=3
        public Genres Get(int id)
        {

            var data = repository.GetGenrasById(id);

           // throw new ApplicationException();
            return data;
        }

        [HttpGet("{id}", Name ="NewExample")] /// api/genres/example/1
        [HttpGet("{id:int}/{para=filps}")]

        [AddHeader("Author", "Rick Anderson")]
        public IActionResult NewExample(int id,string para)
        {
            var data = repository.GetGenrasById(id);
              if(data== null)
            {
                this.logger.LogWarning($"Genres of {id} is not found");
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Genres model)
        {
            if(ModelState.IsValid== false)
            {
                return BadRequest(ModelState);
            }

            return Ok();
        }

        [HttpPut]
        public void Put()
        {

        }

        [HttpDelete]
        public void Delete()
        {
        }

    }
}
