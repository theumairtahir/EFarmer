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
    /// Controls the responses for categories
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CategoriesController : ControllerBase
    {
        private readonly IContainer container;
        private RepositoryFactory repositoryFactory;
        /// <summary>
        /// Initializer
        /// </summary>
        public CategoriesController()
        {
            repositoryFactory = new ModelsFactory();
            container = repositoryFactory.Build();
        }
        /// <summary>
        /// Returns a list of categories
        /// </summary>
        /// <returns></returns>
        [HttpGet("", Name = "Get")]
        [ProducesResponseType(typeof(List<Category>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<Category>>> Get()
        {
            try
            {
                List<Category> categories = new List<Category>();
                using (var scope = container.BeginLifetimeScope())
                {
                    using (var repository = scope.Resolve<ICategoryRepository>())
                    {
                        categories = await repository.ReadAllAsync();
                    }
                }
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Returns a category
        /// </summary>
        /// <param name="id">Primary Key</param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetCategory")]
        [ProducesResponseType(typeof(Category), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Category> Get(short id)
        {
            try
            {
                Category category = null;
                using (var scope = container.BeginLifetimeScope())
                {
                    using (var repository = scope.Resolve<ICategoryRepository>())
                    {
                        category = repository.Read(id);
                    }
                }
                return category;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Creates a new Category
        /// </summary>
        /// <param name="category">Data for Category</param>
        [HttpPost("", Name = "PostCategory")]
        [ProducesResponseType(typeof(Category), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Category> Post([FromBody] CategoryResponseModel category)
        {
            try
            {
                Category _category = new Category
                {
                    Name = category.Name,
                    UrduName = category.UrduName
                };
                using (var scope = container.BeginLifetimeScope())
                {
                    using (var repository = scope.Resolve<ICategoryRepository>())
                    {
                        _category = repository.Read(repository.Create(_category));
                    }
                }
                return _category;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Updates the category
        /// </summary>
        /// <param name="category">Category to be updated</param>
        [HttpPut("Update", Name = "UpdateCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put([FromBody] CategoryResponseModel category)
        {
            try
            {
                Category _category = new Category
                {
                    Id = category.Id,
                    Name = category.Name,
                    UrduName = category.UrduName
                };
                using (var scope = container.BeginLifetimeScope())
                {
                    using (var repository = scope.Resolve<ICategoryRepository>())
                    {
                        repository.Update(_category);
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
        /// Deletes this category
        /// </summary>
        /// <param name="id">Primary Key</param>
        [HttpDelete("Delete/{id}", Name = "DeleteCategory")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<bool> Delete(short id)
        {
            try
            {
                bool flag = false;
                using (var scope = container.BeginLifetimeScope())
                {
                    using (var repository = container.Resolve<ICategoryRepository>())
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
