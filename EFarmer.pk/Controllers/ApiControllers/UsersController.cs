using Autofac;
using EFarmer.Models;
using EFarmer.Models.Helpers;
using EFarmer.pk.ApiModels;
using EFarmer.pk.Models;
using EFarmerPkModelLibrary.Factories;
using EFarmerPkModelLibrary.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFarmer.pk.Controllers.ApiControllers
{
    /// <summary>
    /// Controls the requests and responses for users
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsersController : ControllerBase
    {
        private readonly IContainer container;
        private RepositoryFactory repositoryFactory;
        /// <summary>
        /// Initializer
        /// </summary>
        public UsersController()
        {
            repositoryFactory = new ModelsFactory();
            container = repositoryFactory.Build();
        }
        /// <summary>
        /// Returns a list of users related to a city
        /// </summary>
        /// <returns></returns>
        [HttpGet("{cityId}", Name = "GetUsersByCity")]
        [ProducesResponseType(typeof(List<User>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<User>>> GetUsersByCity(short cityId)
        {
            try
            {
                List<User> users = new List<User>();
                using (var scope = container.BeginLifetimeScope())
                {
                    using (var userFactory = scope.Resolve<IUserRepository>())
                    {
                        users = await userFactory.GetUsersAsync(new City { Id = cityId });
                    }
                }
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Returns a list of users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<User>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<User>>> Get(short cityId)
        {
            try
            {
                List<User> users = new List<User>();
                using (var scope = container.BeginLifetimeScope())
                {
                    using (var userFactory = scope.Resolve<IUserRepository>())
                    {
                        users = await userFactory.ReadAllAsync();
                    }
                }
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Returns a list of registered buyers
        /// </summary>
        /// <returns></returns>
        [HttpGet("Buyers", Name = "GetBuyers")]
        [ProducesResponseType(typeof(List<User>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<User>>> GetBuyers()
        {
            try
            {
                List<User> buyers = new List<User>();
                using (var scope = container.BeginLifetimeScope())
                {
                    using (var userFactory = scope.Resolve<IUserRepository>())
                    {
                        buyers = await userFactory.GetBuyersAsync();
                    }
                }
                return Ok(buyers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Returns a list of sellers in the system
        /// </summary>
        /// <returns></returns>
        [HttpGet("Sellers", Name = "GetSellers")]
        [ProducesResponseType(typeof(List<User>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<User>>> GetSellers()
        {
            try
            {
                List<User> sellers = new List<User>();
                using (var scope = container.BeginLifetimeScope())
                {
                    using (var userFactory = scope.Resolve<IUserRepository>())
                    {
                        sellers = await userFactory.GetSellersAsync();
                    }
                }
                return Ok(sellers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Returns a user
        /// </summary>
        /// <param name="id">Primary Key</param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetUser")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<User> Get(long id)
        {
            try
            {
                User user = null;
                using (var scope = container.BeginLifetimeScope())
                {
                    using (var userRepository = scope.Resolve<IUserRepository>())
                    {
                        user = userRepository.Read(id);
                    }
                }
                return user;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Returns a user by its contact number
        /// </summary>
        /// <param name="countryCode"></param>
        /// <param name="companyCode"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        [HttpGet("GetByContactNumber", Name = "GetUserByContactNumber")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<User> GetByContactNumber(string countryCode, string companyCode, string phone)
        {
            ContactNumberFormat contactNumber = new ContactNumberFormat(countryCode, companyCode, phone);
            try
            {
                User user = null;
                using (var scope = container.BeginLifetimeScope())
                {
                    using (var userRepository = scope.Resolve<IUserRepository>())
                    {
                        user = userRepository.GetUser(new ContactNumberFormat(contactNumber.CountryCode, contactNumber.CompanyCode, contactNumber.PhoneNumber));
                    }
                }
                return user;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="user">Data for User</param>
        [HttpPost("", Name = "PostUser")]
        [ProducesResponseType(typeof(User), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<User> PostUser([FromBody] UserRequestModel user)
        {
            try
            {
                User _user = new User
                {
                    Address = user.Address,
                    City = new City
                    {
                        Id = user.CityId
                    },
                    ContactNumber = new ContactNumberFormat(user.CountryCode, user.CompanyCode, user.Phone),
                    Location = user.Location,
                    Name = user.Name
                };
                using (var scope = container.BeginLifetimeScope())
                {
                    using (var repository = scope.Resolve<IUserRepository>())
                    {
                        _user = repository.Read(repository.Create(_user));
                    }
                }
                return _user;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Updates the user
        /// </summary>
        /// <param name="user">User to be updated</param>
        // PUT: api/Users/5
        [HttpPut("Update", Name = "UpdateUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put([FromBody] UserRequestModel user)
        {
            try
            {
                User _user = new User
                {
                    Address = user.Address,
                    Name = user.Name,
                    Location = user.Location,
                    City = new City
                    {
                        Id = user.CityId
                    },
                    Id = user.Id,
                    ContactNumber = new EFarmer.Models.Helpers.ContactNumberFormat(user.CountryCode, user.CompanyCode, user.Phone)
                };
                using (var scope = container.BeginLifetimeScope())
                {
                    using (var repository = scope.Resolve<IUserRepository>())
                    {
                        repository.Update(_user);
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
        /// Deletes this user
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("Delete/{id}", Name = "DeleteUser")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<bool> Delete(long id)
        {
            try
            {
                bool flag = false;
                using (var scope = container.BeginLifetimeScope())
                {
                    using (var repository = container.Resolve<IUserRepository>())
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
        /// <summary>
        /// Makes user a buyer
        /// </summary>
        /// <param name="id">Primary Key</param>
        /// <returns></returns>
        [HttpGet("MakeBuyer/{id}", Name = "MakeBuyer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult MakeBuyer(long id)
        {
            try
            {
                using (var scope = container.BeginLifetimeScope())
                {
                    using (var repository = scope.Resolve<IUserRepository>())
                    {
                        repository.MakeBuyer(new User { Id = id });
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
        /// Makes user a seller
        /// </summary>
        /// <param name="id">Primary Key</param>
        /// <returns></returns>
        [HttpGet("MakeSeller/{id}", Name = "MakeSeller")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult MakeSeller(long id)
        {
            try
            {
                using (var scope = container.BeginLifetimeScope())
                {
                    using (var repository = scope.Resolve<IUserRepository>())
                    {
                        repository.MakeSeller(new User { Id = id });

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
        /// Buyer adds seller to favorites list
        /// </summary>
        /// <param name="buyerId"></param>
        /// <param name="sellerId"></param>
        /// <returns></returns>
        [HttpGet("AddToFav/{buyerId}/{sellerId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult AddToFavorites(long buyerId, long sellerId)
        {
            try
            {
                using (var scope = container.BeginLifetimeScope())
                {
                    using (var repository = scope.Resolve<IUserRepository>())
                    {
                        repository.AddToFavoritesAsync(new User { Id = sellerId }, new User { Id = buyerId });
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
        /// Returns a list of Sellers favourited by the buyer
        /// </summary>
        /// <param name="buyerId">Primary Key for buyer</param>
        /// <returns></returns>
        [HttpGet("FavoriteSellers/{buyerId}", Name = "GetFavoriteSellers")]
        [ProducesResponseType(typeof(List<User>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<User>>> GetFavoriteSellersAsync(long buyerId)
        {
            try
            {
                var lstUsers = new List<User>();
                using (var scope = container.BeginLifetimeScope())
                {
                    using (var repository = scope.Resolve<IUserRepository>())
                    {
                        lstUsers = await repository.GetFavoriteBuyersAsync(new User { Id = buyerId });

                    }
                }
                return lstUsers;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Returns a list of Sellers favourited by the buyer
        /// </summary>
        /// <param name="id">Primary Key</param>
        /// <param name="location">New Location</param>
        /// <returns></returns>
        [HttpPost("UpdateLocation/{id}", Name = "UpdateLocation")]
        [ProducesResponseType(typeof(List<User>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<User>> UpdateLocation(long id, [FromBody]GeoLocation location)
        {
            try
            {
                var lstUsers = new List<User>();
                using (var scope = container.BeginLifetimeScope())
                {
                    using (var repository = scope.Resolve<IUserRepository>())
                    {
                        repository.UpdateLocation(new User { Id = id }, location);
                    }
                }
                return lstUsers;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

