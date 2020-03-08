using Autofac;
using EFarmer.pk.Models;
using EFarmer.pk.ViewModels.AdvertisementsViewModels;
using EFarmerPkModelLibrary.Factories;
using EFarmerPkModelLibrary.Repositories;
using ImageUploader;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFarmer.pk.Controllers
{
    public class AdvertisementsController : Controller
    {
        private readonly IImageHandler _imageHandler;
        private readonly IContainer container;
        private RepositoryFactory repositoryFactory;
        public AdvertisementsController(IImageHandler imageHandler)
        {
            repositoryFactory = new ModelsFactory();
            container = repositoryFactory.Build();
            _imageHandler = imageHandler;
        }
        public IActionResult Details(int id)
        {
            AdDetailsViewModel model = new AdDetailsViewModel
            {
                Category = "Crops",
                CategoryId = 1,
                CityId = 1,
                CityLocation = new EFarmer.Models.Helpers.GeoLocation { Latitude = 31.518934m, Longitude = 74.394765m },
                Id = 1,
                Location = "Lahore",
                Picture = Common.CommonValues.UPLOADED_PICS_PATH + Common.CommonValues.CROP_DEFAULT_PIC,
                PostedDate = DateTime.Now.ToString("dd MMMM yy"),
                Price = Common.CommonValues.CURRENCY_SYMBOL + " " + 1000,
                Quality = 3,
                Quantity = 100,
                SellerMobileNumber = "0300-1234567",
                Title = "Lorem Ipsum",
                _UserInfo = new UserInfoViewModel
                {
                    DatePosted = DateTime.Now.ToString("dd MMMM yy"),
                    Id = 1,
                    Name = "Umair Tahir",
                    Picture = ""
                }
            };
            return View(model);
        }
        public IActionResult GetAdsByCategory(short id)
        {
            return View();
        }
        public IActionResult GetAdvertisementsByCity(short id)
        {
            return View();
        }
        public IActionResult GetFeaturedAds()
        {
            List<FeaturedAdViewModel> model = new List<FeaturedAdViewModel>();
            for (int i = 0; i < 5; i++)
            {
                model.Add(new FeaturedAdViewModel
                {
                    Category = "Crops",
                    CategoryId = 1,
                    Id = 1,
                    IsNegotiable = false,
                    Location = "Lahore",
                    Picture = Common.CommonValues.UPLOADED_PICS_PATH + Common.CommonValues.CROP_DEFAULT_PIC,
                    Price = Common.CommonValues.CURRENCY_SYMBOL + 10000,
                    Span = "15 min ago",
                    Title = "Lorem Ipsum"
                });
            }
            return PartialView("_FeaturedAds", model);
        }
        public IActionResult GetRecentAds()
        {
            List<RecentAdsViewModel> model = new List<RecentAdsViewModel>();
            for (int i = 0; i < 5; i++)
            {
                model.Add(new RecentAdsViewModel
                {
                    CityId = 1,
                    Title = "Lorem Ipsum",
                    Id = 1,
                    Location = "Lahore",
                    Picture = Common.CommonValues.UPLOADED_PICS_PATH + Common.CommonValues.VEG_DEFAULT_PIC,
                    Price = Common.CommonValues.CURRENCY_SYMBOL + "10000"
                });
            }
            return PartialView("_RecentAds", model);
        }
        public IActionResult PostAd()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostAd(PostAdViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                var fileName = await _imageHandler.UploadImage(model.Files.First(), "");
                using (var scope = container.BeginLifetimeScope())
                {
                    using (var adRepository = scope.Resolve<IAdvertisementRepository>())
                    {
                        adRepository.Create(new EFarmer.Models.Advertisement
                        {
                            City = new EFarmer.Models.City { Id = model.CityId },
                            Item = new EFarmer.Models.AgroItem { Id = model.ItemId },
                            Picture = fileName,
                            PostedDateTime = DateTime.Now,
                            Price = model.Price,
                            Quality = model.Quality,
                            Quantity = model.Quantity,
                            Seller = new EFarmer.Models.User
                            {
                                Address = model.SellerAddress,
                                ContactNumber = new EFarmer.Models.Helpers.ContactNumberFormat(model.SellerCountryCode, model.SellerComapanyCode, model.SellerNumber),
                                IsSeller = true,
                                Location = Common.CommonValues.DEFAULT_LOCATION,
                                City = new EFarmer.Models.City { Id = model.SellerCity },
                                Name = new EFarmer.Models.Helpers.NameFormat { FirstName = model.SellerFirstName, LastName = model.SellerLastName }
                            }
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index", "Home");
        }
    }
}