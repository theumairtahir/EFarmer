using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Autofac;
using EFarmer.Models;
using EFarmer.pk.Models;
using EFarmer.pk.ViewModels.ApiModels;
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
        private readonly RepositoryFactory repositoryFactory;
        /// <summary>
        /// Initializer
        /// </summary>
        public CitiesController()
        {
            repositoryFactory = new ModelsFactory();
            container = repositoryFactory.Build();
        }
        /// <summary>
        /// Returns a list of cities
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Returns a city searched by primary key
        /// </summary>
        /// <param name="id">Primary Key</param>
        /// <returns></returns>
        // GET: api/Cities/5
        [HttpGet("{id}", Name = "GetCity")]
        [ProducesResponseType(typeof(City), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Get(short id)
        {
            try
            {
                City city = null;
                using (var scope = container.BeginLifetimeScope())
                {
                    using (var repository = scope.Resolve<ICityRepository>())
                    {
                        city = repository.Read(id);
                    }
                }
                return Ok(city);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Creates a new city
        /// </summary>
        /// <param name="city">Data for City</param>
        [HttpPost("", Name = "PostCity")]
        [ProducesResponseType(typeof(City), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<City> Post([FromBody] CityApiModel city)
        {
            try
            {
                City _city = new City
                {
                    GeoLocation = city.Location,
                    Name = city.Name
                };
                using (var scope = container.BeginLifetimeScope())
                {
                    using (var repository = scope.Resolve<ICityRepository>())
                    {
                        _city = repository.Read(repository.Create(_city));
                    }
                }
                return _city;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Updates the city
        /// </summary>
        /// <param name="city">City to be updated</param>
        // PUT: api/Users/5
        [HttpPut("Update", Name = "UpdateCity")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put([FromBody] CityApiModel city)
        {
            try
            {
                City _city = new City
                {
                    GeoLocation = city.Location,
                    Name = city.Name,
                    Id = city.Id
                };
                using (var scope = container.BeginLifetimeScope())
                {
                    using (var repository = scope.Resolve<ICityRepository>())
                    {
                        repository.Update(_city);
                    }
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Deletes this city
        /// </summary>
        /// <param name="id">Primary Key</param>
        // DELETE: api/Delete/5
        [HttpDelete("Delete/{id}", Name = "DeleteCity")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<bool> Delete(short id)
        {
            try
            {
                bool flag = false;
                using (var scope = container.BeginLifetimeScope())
                {
                    using (var repository = container.Resolve<ICityRepository>())
                    {
                        flag = repository.Delete(id);
                    }
                }
                return flag;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
