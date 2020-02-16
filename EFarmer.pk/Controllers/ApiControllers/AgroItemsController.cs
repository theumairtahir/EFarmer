using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using EFarmer.Models;
using EFarmer.pk.ApiModels;
using EFarmer.pk.Models;
using EFarmer.pk.ViewModels.ApiModels;
using EFarmerPkModelLibrary.Factories;
using EFarmerPkModelLibrary.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFarmer.pk.Controllers.ApiControllers
{
    /// <summary>
    /// Controls the requests and responses for Agro Items
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AgroItemsController : ControllerBase
    {
        private readonly IContainer container;
        private RepositoryFactory repositoryFactory;
        /// <summary>
        /// Initializer
        /// </summary>
        public AgroItemsController()
        {
            repositoryFactory = new ModelsFactory();
            container = repositoryFactory.Build();
        }
        /// <summary>
        /// Returns a list of agro items
        /// </summary>
        /// <returns></returns>
        [HttpGet("", Name = "GetAllItems")]
        [ProducesResponseType(typeof(List<AgroItem>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<AgroItem>>> Get()
        {
            try
            {
                List<AgroItem> agroItems = new List<AgroItem>();
                using (var scope = container.BeginLifetimeScope())
                {
                    using (var repository = scope.Resolve<IAgroItemRepository>())
                    {
                        agroItems = await repository.ReadAllAsync();
                    }
                }
                return Ok(agroItems);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Returns a list of items fav by buyer
        /// </summary>
        /// <returns></returns>
        [HttpGet("FavItems/{buyerId}", Name = "GetFavItems")]
        [ProducesResponseType(typeof(List<AgroItem>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<AgroItem>>> GetFavItems(long buyerId)
        {
            try
            {
                List<AgroItem> agroItems = new List<AgroItem>();
                using (var scope = container.BeginLifetimeScope())
                {
                    using (var repository = scope.Resolve<IAgroItemRepository>())
                    {
                        agroItems = await repository.GetInterestedItemsAsync(new User { Id = buyerId });
                    }
                }
                return Ok(agroItems);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Returns a list of agro items in a category
        /// </summary>
        /// <returns></returns>
        [HttpGet("ItemsByCategory/{categoryId}", Name = "GetItemsByCategory")]
        [ProducesResponseType(typeof(List<AgroItem>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<AgroItem>>> GetItemsByCategory(short categoryId)
        {
            try
            {
                List<AgroItem> agroItems = new List<AgroItem>();
                using (var scope = container.BeginLifetimeScope())
                {
                    using (var repository = scope.Resolve<IAgroItemRepository>())
                    {
                        agroItems = await repository.GetAgroItemsByCategoryAsync(new Category { Id = categoryId });
                    }
                }
                return Ok(agroItems);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Returns an Agro Item
        /// </summary>
        /// <param name="id">Primary Key</param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetAgroItem")]
        [ProducesResponseType(typeof(AgroItem), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<AgroItem> Get(int id)
        {
            try
            {
                AgroItem agroItem = null;
                using (var scope = container.BeginLifetimeScope())
                {
                    using (var repository = scope.Resolve<IAgroItemRepository>())
                    {
                        agroItem = repository.Read(id);
                    }
                }
                return agroItem;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Creates a new Agro Item
        /// </summary>
        /// <param name="agroItem">Data for AgroItem</param>
        [HttpPost("", Name = "PostAgroItem")]
        [ProducesResponseType(typeof(AgroItem), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<AgroItem> Post([FromBody] AgroItemRequestModel agroItem)
        {
            try
            {
                AgroItem _agroItem = new AgroItem
                {
                    Category = new Category { Id = agroItem.Category },
                    Name = agroItem.Name,
                    UrduName = agroItem.UrduName,
                    UrduWeightScale = agroItem.UrduWeightScale,
                    WeightScale = agroItem.WeightScale
                };
                using (var scope = container.BeginLifetimeScope())
                {
                    using (var repository = scope.Resolve<IAgroItemRepository>())
                    {
                        _agroItem = repository.Read(repository.Create(_agroItem));
                    }
                }
                return _agroItem;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Updates the AgroItem
        /// </summary>
        /// <param name="agroItem">Agro Item to be updated</param>
        [HttpPut("Update", Name = "UpdateAgroItem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put([FromBody] AgroItemRequestModel agroItem)
        {
            try
            {
                AgroItem _agroItem = new AgroItem
                {
                    Category = new Category { Id = agroItem.Category },
                    Name = agroItem.Name,
                    UrduName = agroItem.UrduName,
                    UrduWeightScale = agroItem.UrduWeightScale,
                    WeightScale = agroItem.WeightScale
                };
                using (var scope = container.BeginLifetimeScope())
                {
                    using (var repository = scope.Resolve<IAgroItemRepository>())
                    {
                        repository.Update(_agroItem);
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
        /// Deletes this agroItem
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("Delete/{id}", Name = "DeleteAgroItem")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<bool> Delete(int id)
        {
            try
            {
                bool flag = false;
                using (var scope = container.BeginLifetimeScope())
                {
                    using (var repository = container.Resolve<IAgroItemRepository>())
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
