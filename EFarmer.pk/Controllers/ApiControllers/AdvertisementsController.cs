using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using EFarmer.Models;
using EFarmer.pk.Common;
using EFarmer.pk.Models;
using EFarmer.pk.ViewModels.ApiModels;
using EFarmerPkModelLibrary.Factories;
using EFarmerPkModelLibrary.Repositories;
using ImageUploader;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFarmer.pk.Controllers.ApiControllers
{
    /// <summary>
    /// Controls the requests and responses for advertisements
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AdvertisementsController : ControllerBase
    {
        private readonly IContainer container;
        private RepositoryFactory repositoryFactory;
        private IImageHandler _imageHandler;
        /// <summary>
        /// Initializer
        /// </summary>
        public AdvertisementsController(IImageHandler imageHandler)
        {
            repositoryFactory = new ModelsFactory();
            container = repositoryFactory.Build();
            _imageHandler = imageHandler;
        }
        /// <summary>
        /// Returns a list of advertisments
        /// </summary>
        /// <returns></returns>
        [HttpGet("", Name = "GetAdvertisments")]
        [ProducesResponseType(typeof(List<Advertisement>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<Advertisement>>> Get()
        {
            try
            {
                List<Advertisement> advertisements = new List<Advertisement>();
                using (var scope = container.BeginLifetimeScope())
                {
                    using (var repository = scope.Resolve<IAdvertisementRepository>())
                    {
                        advertisements = await repository.ReadAllAsync();
                    }
                }
                return Ok(advertisements);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Returns Advertisements by a specific city
        /// </summary>
        /// <param name="cityId">Primary Key for city</param>
        /// <returns></returns>
        [HttpGet("GetAdsByCity/{cityId}", Name = "GetAdsByCity")]
        [ProducesResponseType(typeof(List<Advertisement>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<Advertisement>>> GetAdsByCity(short cityId)
        {
            try
            {
                List<Advertisement> advertisements = new List<Advertisement>();
                using (var scope = container.BeginLifetimeScope())
                {
                    using (var repository = scope.Resolve<IAdvertisementRepository>())
                    {
                        advertisements = await repository.GetAdvertisementsAsync(new City { Id = cityId });
                    }
                }
                return advertisements;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Returns Advertisements by a specific item
        /// </summary>
        /// <param name="itemId">Primary Key for Item</param>
        /// <param name="max">maximum number of record to be fetched</param>
        /// <returns></returns>
        [HttpGet("GetAdsByItem/{itemId}", Name = "GetAdsByItem")]
        [ProducesResponseType(typeof(List<Advertisement>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<Advertisement>>> GetAdsByCity(int itemId, int? max)
        {
            try
            {
                List<Advertisement> advertisements = new List<Advertisement>();
                using (var scope = container.BeginLifetimeScope())
                {
                    using (var repository = scope.Resolve<IAdvertisementRepository>())
                    {
                        advertisements = await repository.GetAdvertisementsRelatedToItemsAsync(new AgroItem { Id = itemId }, max ?? int.MaxValue);
                    }
                }
                return advertisements;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Returns Advertisements by a specific location
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="radius">Search Radius in Kilometeres</param>
        /// <returns></returns>
        [HttpGet("GetAdsByLocation/{latitude}/{longitude}", Name = "GetAdsByLocation")]
        [ProducesResponseType(typeof(List<Advertisement>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<Advertisement>> GetAdsByLocation(decimal latitude, decimal longitude, double radius)
        {
            try
            {
                List<Advertisement> advertisements = new List<Advertisement>();
                using (var scope = container.BeginLifetimeScope())
                {
                    using (var repository = scope.Resolve<IAdvertisementRepository>())
                    {
                        advertisements = repository.GetNearbyAdvertisements(null, new EFarmer.Models.Helpers.GeoLocation
                        {
                            Latitude = latitude,
                            Longitude = longitude
                        }, radius);
                    }
                }
                return advertisements;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Returns Advertisements favorite by a buyer
        /// </summary>
        /// <param name="buyerId">Primary Key for Buyer</param>
        /// <returns></returns>
        [HttpGet("GetFavoritedAds/{buyerId}", Name = "GetFavoriteAds")]
        [ProducesResponseType(typeof(List<Advertisement>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<Advertisement>>> GetFavAdsAsync(long buyerId)
        {
            try
            {
                List<Advertisement> advertisements = new List<Advertisement>();
                using (var scope = container.BeginLifetimeScope())
                {
                    using (var repository = scope.Resolve<IAdvertisementRepository>())
                    {
                        advertisements = await repository.GetFavoriteAdvertisementsAsync(new User { Id = buyerId });
                    }
                }
                return advertisements;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Returns Advertisements favorite by a buyer
        /// </summary>
        /// <param name="sellerId">Primary Key for Buyer</param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [HttpGet("GetPostedAds/{sellerId}", Name = "GetPostedAds")]
        [ProducesResponseType(typeof(List<Advertisement>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<Advertisement>>> GetPostedAdsAsync(long sellerId, DateTime? startDate, DateTime? endDate)
        {
            try
            {
                List<Advertisement> advertisements = new List<Advertisement>();
                using (var scope = container.BeginLifetimeScope())
                {
                    using (var repository = scope.Resolve<IAdvertisementRepository>())
                    {
                        advertisements = await repository.GetPostedAdvertismentsAsync(startDate ?? DateTime.MinValue, endDate ?? DateTime.MaxValue, new User { Id = sellerId });
                    }
                }
                return advertisements;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Returns an advertisement
        /// </summary>
        /// <param name="id">Primary Key</param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetAdvertisement")]
        [ProducesResponseType(typeof(Advertisement), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Advertisement> Get(long id)
        {
            try
            {
                Advertisement ad = null;
                using (var scope = container.BeginLifetimeScope())
                {
                    using (var repository = scope.Resolve<IAdvertisementRepository>())
                    {
                        ad = repository.Read(id);
                    }
                }
                return ad;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Creates a new advertisement
        /// </summary>
        /// <param name="ad">Data for Advertisement</param>
        [HttpPost("", Name = "PostAdvertisement")]
        [ProducesResponseType(typeof(Advertisement), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Advertisement> PostAdvertisement([FromBody] AdvertismentRequestModel ad)
        {
            AgroItem agroItem;
            using (var scope = container.BeginLifetimeScope())
            {
                using (var repository = scope.Resolve<IAgroItemRepository>())
                {
                    agroItem = repository.Read(ad.ItemId);
                }
                if (agroItem != null)
                {
                    var category = agroItem.Category.Name;
                    try
                    {
                        Advertisement _ad = new Advertisement
                        {
                            City = new City { Id = ad.CityId },
                            Item = new AgroItem { Id = ad.ItemId },
                            Picture = category.ToLower() == "crops" ? CommonValues.CROP_DEFAULT_PIC
                                        : category.ToLower() == "fruits" ? CommonValues.FRUIT_DEFAULT_PIC
                                        : CommonValues.VEG_DEFAULT_PIC,
                            PostedDateTime = DateTime.Now,
                            Price = ad.Price,
                            Quality = ad.Quality,
                            Quantity = ad.Quantity,
                            Seller = new User { Id = ad.Seller }
                        };
                        using (var repository = scope.Resolve<IAdvertisementRepository>())
                        {
                            _ad = repository.Read(repository.Create(_ad));
                        }
                        return _ad;
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                }
                else
                {
                    return BadRequest("Image File Could not be uploaded");
                }
            }
        }
        [HttpPost("UploadPhoto/{id}", Name = "UploadPhoto")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UploadPhotoAsync(IFormFile file, long id)
        {
            try
            {
                var fileName = await _imageHandler.UploadImage(file, "");
                using (var scope = container.BeginLifetimeScope())
                {
                    Advertisement advertisement = null;
                    using (var repository = scope.Resolve<IAdvertisementRepository>())
                    {
                        advertisement = repository.Read(id);
                        if (advertisement != null)
                        {
                            advertisement.Picture = fileName;
                            repository.Update(advertisement);
                            return Ok();
                        }
                        else
                        {
                            return BadRequest("Image File Could not be uploaded");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
