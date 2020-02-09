using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using EFarmer.Models;
using EFarmer.pk.Models;
using EFarmerPkModelLibrary.Factories;
using EFarmerPkModelLibrary.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFarmer.pk.Controllers.ApiControllers
{
    /// <summary>
    /// Api to manage the cities
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CitiesController : ControllerBase
    {
        private readonly IContainer container;
        private RepositoryFactory repositoryFactory;
        /// <summary>
        /// Initializer
        /// </summary>
        public CitiesController()
        {
            repositoryFactory = new ModelsFactory();
            container = repositoryFactory.Build();
        }
        // GET: api/Cities
        [HttpGet]
        [ProducesResponseType(typeof(List<City>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<City>>> Get()
        {
            try
            {
                List<City> cities = new List<City>();
                using (var scope = container.BeginLifetimeScope())
                {
                    using (var factory = scope.Resolve<ICityRepository>())
                    {
                        cities = await factory.ReadAllAsync();
                    }
                }
                return Ok(cities);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Cities/5
        [HttpGet("{id}", Name = "GetCity")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Cities
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Cities/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
