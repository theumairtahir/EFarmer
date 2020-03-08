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
        private readonly RepositoryFactory repositoryFactory;
        public AdvertisementsController(IImageHandler imageHandler)
        {
            repositoryFactory = new ModelsFactory();
            container = repositoryFactory.Build();
            _imageHandler = imageHandler;
        }
        public IActionResult Details(long id)
        {
            AdDetailsViewModel model = new AdDetailsViewModel();
            using (var scope = container.BeginLifetimeScope())
            {
                using (var adsRepository = scope.Resolve<IAdvertisementRepository>())
                {
                    var ad = adsRepository.Read(id);
                    var defaultPic = Common.CommonValues.UPLOADED_PICS_PATH;
                    if (ad.Item.Category.Name.Contains("Crops"))
                    {
                        defaultPic += Common.CommonValues.CROP_DEFAULT_PIC;
                    }
                    else if (ad.Item.Category.Name.Contains("Fruits"))
                    {
                        defaultPic += Common.CommonValues.FRUIT_DEFAULT_PIC;
                    }
                    else if (ad.Item.Category.Name.Contains("Vegetables"))
                    {
                        defaultPic += Common.CommonValues.VEG_DEFAULT_PIC;
                    }
                    else if (ad.Item.Category.Name.Contains("Pesticides"))
                    {
                        defaultPic += Common.CommonValues.PEST_DEFAULT_PIC;
                    }
                    else if (ad.Item.Category.Name.Contains("Fertilizers"))
                    {
                        defaultPic += Common.CommonValues.FERTILIZER_DEFAULT_PIC;
                    }
                    else if (ad.Item.Name.Contains("Seeds"))
                    {
                        defaultPic += Common.CommonValues.SEEDS_DEFAULT_PIC;
                    }
                    model = new AdDetailsViewModel
                    {
                        Category = ad.Item.Category.Name,
                        CategoryId = ad.Item.Category.Id,
                        CityId = ad.City.Id,
                        CityLocation = ad.City.GeoLocation,
                        Id = ad.Id,
                        Location = ad.City.Name,
                        Picture = (string.IsNullOrEmpty(ad.Picture)
                                    || string.IsNullOrWhiteSpace(ad.Picture)) ? defaultPic
                                                                              : Common.CommonValues.UPLOADED_PICS_PATH + ad.Picture,
                        PostedDate = ad.PostedDateTime.ToString(Common.CommonValues.LONG_DATE_FORMAT),
                        Price = Common.CommonValues.CURRENCY_SYMBOL + " " + decimal.Round(ad.Price, 2),
                        Quality = ad.Quality,
                        Quantity = ad.Quantity,
                        SellerMobileNumber = ad.Seller.ContactNumber.LocalFormatedPhoneNumber,
                        Title = ad.Seller.Name.ToString() + " is selling " + ad.Item.Name + " in " + ad.City.Name,
                        _UserInfo = new UserInfoViewModel
                        {
                            DatePosted = Common.CommonFunctions.GetPassedDateSpanFromNow(ad.PostedDateTime),
                            Name = ad.Seller.Name.ToString(),
                            Id = ad.Seller.Id,
                            Picture = Common.CommonValues.PROFILE_IMAGES_PATH + Common.CommonValues.DEFAULT_PROFILE_IMAGE
                        }
                    };
                }
            }
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
        public async Task<IActionResult> GetFeaturedAds()
        {
            List<FeaturedAdViewModel> model = new List<FeaturedAdViewModel>();

            using (var scope = container.BeginLifetimeScope())
            {
                using (var adsRepository = scope.Resolve<IAdvertisementRepository>())
                {
                    foreach (var item in (await adsRepository.ReadAllAsync()).OrderByDescending(x => x.PostedDateTime).Take(5))
                    {
                        var defaultPic = Common.CommonValues.UPLOADED_PICS_PATH;
                        if (item.Item.Category.Name.Contains("Crops"))
                        {
                            defaultPic += Common.CommonValues.CROP_DEFAULT_PIC;
                        }
                        else if (item.Item.Category.Name.Contains("Fruits"))
                        {
                            defaultPic += Common.CommonValues.FRUIT_DEFAULT_PIC;
                        }
                        else if (item.Item.Category.Name.Contains("Vegetables"))
                        {
                            defaultPic += Common.CommonValues.VEG_DEFAULT_PIC;
                        }
                        else if (item.Item.Category.Name.Contains("Pesticides"))
                        {
                            defaultPic += Common.CommonValues.PEST_DEFAULT_PIC;
                        }
                        else if (item.Item.Category.Name.Contains("Fertilizers"))
                        {
                            defaultPic += Common.CommonValues.FERTILIZER_DEFAULT_PIC;
                        }
                        else if (item.Item.Name.Contains("Seeds"))
                        {
                            defaultPic += Common.CommonValues.SEEDS_DEFAULT_PIC;
                        }
                        model.Add(new FeaturedAdViewModel
                        {
                            Category = item.Item.Category.Name,
                            CategoryId = item.Item.Category.Id,
                            Id = item.Id,
                            IsNegotiable = false,
                            Location = item.City.Name,
                            Picture = (string.IsNullOrEmpty(item.Picture)
                                       || string.IsNullOrWhiteSpace(item.Picture)) ? defaultPic
                                                                                   : Common.CommonValues.UPLOADED_PICS_PATH + item.Picture,
                            Price = Common.CommonValues.CURRENCY_SYMBOL + " " + decimal.Round(item.Price, 2),
                            Span = Common.CommonFunctions.GetPassedTimeSpanFromNow(item.PostedDateTime),
                            Title = item.Seller.Name.ToString() + " is selling " + item.Item.Name + " in " + item.City.Name
                        });
                    }
                }
            }
            return PartialView("_FeaturedAds", model);
        }
        public async Task<IActionResult> GetRecentAds()
        {
            List<RecentAdsViewModel> model = new List<RecentAdsViewModel>();
            using (var scope = container.BeginLifetimeScope())
            {
                using (var adsRepository = scope.Resolve<IAdvertisementRepository>())
                {
                    foreach (var item in (await adsRepository.ReadAllAsync()).OrderByDescending(x => x.PostedDateTime).Take(5))
                    {
                        var defaultPic = Common.CommonValues.UPLOADED_PICS_PATH;
                        if (item.Item.Category.Name.Contains("Crops"))
                        {
                            defaultPic += Common.CommonValues.CROP_DEFAULT_PIC;
                        }
                        else if (item.Item.Category.Name.Contains("Fruits"))
                        {
                            defaultPic += Common.CommonValues.FRUIT_DEFAULT_PIC;
                        }
                        else if (item.Item.Category.Name.Contains("Vegetables"))
                        {
                            defaultPic += Common.CommonValues.VEG_DEFAULT_PIC;
                        }
                        else if (item.Item.Category.Name.Contains("Pesticides"))
                        {
                            defaultPic += Common.CommonValues.PEST_DEFAULT_PIC;
                        }
                        else if (item.Item.Category.Name.Contains("Fertilizers"))
                        {
                            defaultPic += Common.CommonValues.FERTILIZER_DEFAULT_PIC;
                        }
                        else if (item.Item.Name.Contains("Seeds"))
                        {
                            defaultPic += Common.CommonValues.SEEDS_DEFAULT_PIC;
                        }
                        model.Add(new RecentAdsViewModel
                        {
                            Title = item.Seller.Name.ToString() + " is selling " + item.Item.Name + " in " + item.City.Name,
                            CityId = item.City.Id,
                            Id = item.Id,
                            Location = item.City.Name,
                            Picture = (string.IsNullOrEmpty(item.Picture)
                                       || string.IsNullOrWhiteSpace(item.Picture)) ? defaultPic
                                                                                   : Common.CommonValues.UPLOADED_PICS_PATH + item.Picture,
                            Price = Common.CommonValues.CURRENCY_SYMBOL + decimal.Round(item.Price, 2)
                        });
                    }
                }
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
                ViewBag.Error = true;
                return View();
            }
            try
            {
                var fileName = string.Empty;
                if (model.Files.Count() > 0)
                {
                    fileName = await _imageHandler.UploadImage(model.Files.First(), "");
                }
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
                                City = (model.SellerCity <= 0) 
                                        ? new EFarmer.Models.City { Id = model.CityId } 
                                        : new EFarmer.Models.City { Id = model.SellerCity },
                                Name = new EFarmer.Models.Helpers.NameFormat { FirstName = model.SellerFirstName, LastName = model.SellerLastName }
                            }
                        });
                    }
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
            ViewBag.Success = true;
            return View();
        }
    }
}