using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using EFarmer.pk.Models;
using EFarmer.pk.ViewModels.HomeViewModels;
using EFarmerPkModelLibrary.Factories;
using EFarmerPkModelLibrary.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EFarmer.pk.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IContainer container;
        private readonly RepositoryFactory repositoryFactory;
        public ProductsController()
        {
            repositoryFactory = new ModelsFactory();
            container = repositoryFactory.Build();
        }
        [Route("/Products/Crops")]
        public IActionResult ViewCrops()
        {
            return View();
        }
        public async Task<IActionResult> GetCrops()
        {
            List<AdViewModel> ads = new List<AdViewModel>();
            using (var scope = container.BeginLifetimeScope())
            {
                short categoryId = 0;
                using (var categoryRepo = scope.Resolve<ICategoryRepository>())
                {
                    foreach (var item in await categoryRepo.ReadAllAsync())
                    {
                        if (item.Name.ToLower().Contains("crops"))
                        {
                            categoryId = item.Id;
                        }
                    }
                }
                using (var adsRepository = scope.Resolve<IAdvertisementRepository>())
                {
                    foreach (var item in await adsRepository.GetAdvertisementsByCategoryAsync(new EFarmer.Models.Category { Id = categoryId }, 1, 6))
                    {
                        var defaultPic = Common.CommonValues.UPLOADED_PICS_PATH;
                        defaultPic += Common.CommonValues.CROP_DEFAULT_PIC;
                        ads.Add(new AdViewModel
                        {
                            Category = item.Item.Category.Name,
                            CategoryId = item.Item.Category.Id,
                            Id = item.Id,
                            Location = item.City.Name,
                            Picture = (string.IsNullOrEmpty(item.Picture)
                                 || string.IsNullOrWhiteSpace(item.Picture))
                                 ? defaultPic
                                 : Common.CommonValues.UPLOADED_PICS_PATH + item.Picture,
                            Price = Common.CommonValues.CURRENCY_SYMBOL + " " + decimal.Round(item.Price, 2),
                            Rating = item.Quality,
                            Span = Common.CommonFunctions.GetPassedTimeSpanFromNow(item.PostedDateTime),
                            Title = Common.CommonFunctions.GetAdTitle(item.Seller.Name.ToString(), item.Item.Name, item.City.Name)
                        });
                    }
                }
            }
            return PartialView("_AdsListingPartial", ads);
        }
        public async Task<IActionResult> LoadCrops(int count, int lastIndex)
        {
            int startRow = lastIndex + 1;
            int endRow = startRow + count;
            List<AdViewModel> ads = new List<AdViewModel>();
            using (var scope = container.BeginLifetimeScope())
            {
                short categoryId = 0;
                using (var categoryRepo = scope.Resolve<ICategoryRepository>())
                {
                    foreach (var item in await categoryRepo.ReadAllAsync())
                    {
                        if (item.Name.ToLower().Contains("crops"))
                        {
                            categoryId = item.Id;
                        }
                    }
                }
                using (var adsRepository = scope.Resolve<IAdvertisementRepository>())
                {
                    foreach (var item in await adsRepository.GetAdvertisementsByCategoryAsync(new EFarmer.Models.Category { Id = categoryId }, startRow, endRow))
                    {
                        var defaultPic = Common.CommonValues.UPLOADED_PICS_PATH;
                        defaultPic += Common.CommonValues.CROP_DEFAULT_PIC;
                        ads.Add(new AdViewModel
                        {
                            Category = item.Item.Category.Name,
                            CategoryId = item.Item.Category.Id,
                            Id = item.Id,
                            Location = item.City.Name,
                            Picture = (string.IsNullOrEmpty(item.Picture)
                                 || string.IsNullOrWhiteSpace(item.Picture))
                                 ? defaultPic
                                 : Common.CommonValues.UPLOADED_PICS_PATH + item.Picture,
                            Price = Common.CommonValues.CURRENCY_SYMBOL + " " + decimal.Round(item.Price, 2),
                            Rating = item.Quality,
                            Span = Common.CommonFunctions.GetPassedTimeSpanFromNow(item.PostedDateTime),
                            Title = Common.CommonFunctions.GetAdTitle(item.Seller.Name.ToString(), item.Item.Name, item.City.Name)
                        });
                    }
                }
            }
            return PartialView("_AdsListingPartial", ads);
        }
        [Route("/Products/Fruits")]
        public IActionResult ViewFruits()
        {
            return View();
        }
        public async Task<IActionResult> GetFruits()
        {
            List<AdViewModel> ads = new List<AdViewModel>();
            using (var scope = container.BeginLifetimeScope())
            {
                short categoryId = 0;
                using (var categoryRepo = scope.Resolve<ICategoryRepository>())
                {
                    foreach (var item in await categoryRepo.ReadAllAsync())
                    {
                        if (item.Name.ToLower().Contains("fruits"))
                        {
                            categoryId = item.Id;
                        }
                    }
                }
                using (var adsRepository = scope.Resolve<IAdvertisementRepository>())
                {
                    foreach (var item in await adsRepository.GetAdvertisementsByCategoryAsync(new EFarmer.Models.Category { Id = categoryId }, 1, 6))
                    {
                        var defaultPic = Common.CommonValues.UPLOADED_PICS_PATH;
                        defaultPic += Common.CommonValues.FRUIT_DEFAULT_PIC;
                        ads.Add(new AdViewModel
                        {
                            Category = item.Item.Category.Name,
                            CategoryId = item.Item.Category.Id,
                            Id = item.Id,
                            Location = item.City.Name,
                            Picture = (string.IsNullOrEmpty(item.Picture)
                                 || string.IsNullOrWhiteSpace(item.Picture))
                                 ? defaultPic
                                 : Common.CommonValues.UPLOADED_PICS_PATH + item.Picture,
                            Price = Common.CommonValues.CURRENCY_SYMBOL + " " + decimal.Round(item.Price, 2),
                            Rating = item.Quality,
                            Span = Common.CommonFunctions.GetPassedTimeSpanFromNow(item.PostedDateTime),
                            Title = Common.CommonFunctions.GetAdTitle(item.Seller.Name.ToString(), item.Item.Name, item.City.Name)
                        });
                    }
                }
            }
            return PartialView("_AdsListingPartial", ads);
        }
        public async Task<IActionResult> LoadFruits(int count, int lastIndex)
        {
            int startRow = lastIndex + 1;
            int endRow = startRow + count;
            List<AdViewModel> ads = new List<AdViewModel>();
            using (var scope = container.BeginLifetimeScope())
            {
                short categoryId = 0;
                using (var categoryRepo = scope.Resolve<ICategoryRepository>())
                {
                    foreach (var item in await categoryRepo.ReadAllAsync())
                    {
                        if (item.Name.ToLower().Contains("fruits"))
                        {
                            categoryId = item.Id;
                        }
                    }
                }
                using (var adsRepository = scope.Resolve<IAdvertisementRepository>())
                {
                    foreach (var item in await adsRepository.GetAdvertisementsByCategoryAsync(new EFarmer.Models.Category { Id = categoryId }, startRow, endRow))
                    {
                        var defaultPic = Common.CommonValues.UPLOADED_PICS_PATH;
                        defaultPic += Common.CommonValues.FRUIT_DEFAULT_PIC;
                        ads.Add(new AdViewModel
                        {
                            Category = item.Item.Category.Name,
                            CategoryId = item.Item.Category.Id,
                            Id = item.Id,
                            Location = item.City.Name,
                            Picture = (string.IsNullOrEmpty(item.Picture)
                                 || string.IsNullOrWhiteSpace(item.Picture))
                                 ? defaultPic
                                 : Common.CommonValues.UPLOADED_PICS_PATH + item.Picture,
                            Price = Common.CommonValues.CURRENCY_SYMBOL + " " + decimal.Round(item.Price, 2),
                            Rating = item.Quality,
                            Span = Common.CommonFunctions.GetPassedTimeSpanFromNow(item.PostedDateTime),
                            Title = Common.CommonFunctions.GetAdTitle(item.Seller.Name.ToString(), item.Item.Name, item.City.Name)
                        });
                    }
                }
            }
            return PartialView("_AdsListingPartial", ads);

        }
        [Route("/Products/Vegetabes")]
        public IActionResult ViewVegetables()
        {
            return View();
        }
        public async Task<IActionResult> GetVegetables()
        {
            List<AdViewModel> ads = new List<AdViewModel>();
            using (var scope = container.BeginLifetimeScope())
            {
                short categoryId = 0;
                using (var categoryRepo = scope.Resolve<ICategoryRepository>())
                {
                    foreach (var item in await categoryRepo.ReadAllAsync())
                    {
                        if (item.Name.ToLower().Contains("vegetables"))
                        {
                            categoryId = item.Id;
                        }
                    }
                }
                using (var adsRepository = scope.Resolve<IAdvertisementRepository>())
                {
                    foreach (var item in await adsRepository.GetAdvertisementsByCategoryAsync(new EFarmer.Models.Category { Id = categoryId }, 1, 6))
                    {
                        var defaultPic = Common.CommonValues.UPLOADED_PICS_PATH;
                        defaultPic += Common.CommonValues.VEG_DEFAULT_PIC;
                        ads.Add(new AdViewModel
                        {
                            Category = item.Item.Category.Name,
                            CategoryId = item.Item.Category.Id,
                            Id = item.Id,
                            Location = item.City.Name,
                            Picture = (string.IsNullOrEmpty(item.Picture)
                                 || string.IsNullOrWhiteSpace(item.Picture))
                                 ? defaultPic
                                 : Common.CommonValues.UPLOADED_PICS_PATH + item.Picture,
                            Price = Common.CommonValues.CURRENCY_SYMBOL + " " + decimal.Round(item.Price, 2),
                            Rating = item.Quality,
                            Span = Common.CommonFunctions.GetPassedTimeSpanFromNow(item.PostedDateTime),
                            Title = Common.CommonFunctions.GetAdTitle(item.Seller.Name.ToString(), item.Item.Name, item.City.Name)
                        });
                    }
                }
            }
            return PartialView("_AdsListingPartial", ads);
        }
        public async Task<IActionResult> LoadVegetables(int count, int lastIndex)
        {
            int startRow = lastIndex + 1;
            int endRow = startRow + count;
            List<AdViewModel> ads = new List<AdViewModel>();
            using (var scope = container.BeginLifetimeScope())
            {
                short categoryId = 0;
                using (var categoryRepo = scope.Resolve<ICategoryRepository>())
                {
                    foreach (var item in await categoryRepo.ReadAllAsync())
                    {
                        if (item.Name.ToLower().Contains("vegetables"))
                        {
                            categoryId = item.Id;
                        }
                    }
                }
                using (var adsRepository = scope.Resolve<IAdvertisementRepository>())
                {
                    foreach (var item in await adsRepository.GetAdvertisementsByCategoryAsync(new EFarmer.Models.Category { Id = categoryId }, startRow, endRow))
                    {
                        var defaultPic = Common.CommonValues.UPLOADED_PICS_PATH;
                        defaultPic += Common.CommonValues.VEG_DEFAULT_PIC;
                        ads.Add(new AdViewModel
                        {
                            Category = item.Item.Category.Name,
                            CategoryId = item.Item.Category.Id,
                            Id = item.Id,
                            Location = item.City.Name,
                            Picture = (string.IsNullOrEmpty(item.Picture)
                                 || string.IsNullOrWhiteSpace(item.Picture))
                                 ? defaultPic
                                 : Common.CommonValues.UPLOADED_PICS_PATH + item.Picture,
                            Price = Common.CommonValues.CURRENCY_SYMBOL + " " + decimal.Round(item.Price, 2),
                            Rating = item.Quality,
                            Span = Common.CommonFunctions.GetPassedTimeSpanFromNow(item.PostedDateTime),
                            Title = Common.CommonFunctions.GetAdTitle(item.Seller.Name.ToString(), item.Item.Name, item.City.Name)
                        });
                    }
                }
            }
            return PartialView("_AdsListingPartial", ads);
        }
        [Route("/Product/Pesticides")]
        public IActionResult ViewPesticides() => View();
        public async Task<IActionResult> GetPesticides()
        {
            List<AdViewModel> ads = new List<AdViewModel>();
            using (var scope = container.BeginLifetimeScope())
            {
                short categoryId = 0;
                using (var categoryRepo = scope.Resolve<ICategoryRepository>())
                {
                    foreach (var item in await categoryRepo.ReadAllAsync())
                    {
                        if (item.Name.ToLower().Contains("pesticides"))
                        {
                            categoryId = item.Id;
                        }
                    }
                }
                using (var adsRepository = scope.Resolve<IAdvertisementRepository>())
                {
                    foreach (var item in await adsRepository.GetAdvertisementsByCategoryAsync(new EFarmer.Models.Category { Id = categoryId }, 1, 6))
                    {
                        var defaultPic = Common.CommonValues.UPLOADED_PICS_PATH;
                        defaultPic += Common.CommonValues.PEST_DEFAULT_PIC;
                        ads.Add(new AdViewModel
                        {
                            Category = item.Item.Category.Name,
                            CategoryId = item.Item.Category.Id,
                            Id = item.Id,
                            Location = item.City.Name,
                            Picture = (string.IsNullOrEmpty(item.Picture)
                                 || string.IsNullOrWhiteSpace(item.Picture))
                                 ? defaultPic
                                 : Common.CommonValues.UPLOADED_PICS_PATH + item.Picture,
                            Price = Common.CommonValues.CURRENCY_SYMBOL + " " + decimal.Round(item.Price, 2),
                            Rating = item.Quality,
                            Span = Common.CommonFunctions.GetPassedTimeSpanFromNow(item.PostedDateTime),
                            Title = Common.CommonFunctions.GetAdTitle(item.Seller.Name.ToString(), item.Item.Name, item.City.Name)
                        });
                    }
                }
            }
            return PartialView("_AdsListingPartial", ads);
        }
        public async Task<IActionResult> LoadPesticides(int count, int lastIndex)
        {
            int startRow = lastIndex + 1;
            int endRow = startRow + count;
            List<AdViewModel> ads = new List<AdViewModel>();
            using (var scope = container.BeginLifetimeScope())
            {
                short categoryId = 0;
                using (var categoryRepo = scope.Resolve<ICategoryRepository>())
                {
                    foreach (var item in await categoryRepo.ReadAllAsync())
                    {
                        if (item.Name.ToLower().Contains("pesticides"))
                        {
                            categoryId = item.Id;
                        }
                    }
                }
                using (var adsRepository = scope.Resolve<IAdvertisementRepository>())
                {
                    foreach (var item in await adsRepository.GetAdvertisementsByCategoryAsync(new EFarmer.Models.Category { Id = categoryId }, startRow, endRow))
                    {
                        var defaultPic = Common.CommonValues.UPLOADED_PICS_PATH;
                        defaultPic += Common.CommonValues.PEST_DEFAULT_PIC;
                        ads.Add(new AdViewModel
                        {
                            Category = item.Item.Category.Name,
                            CategoryId = item.Item.Category.Id,
                            Id = item.Id,
                            Location = item.City.Name,
                            Picture = (string.IsNullOrEmpty(item.Picture)
                                 || string.IsNullOrWhiteSpace(item.Picture))
                                 ? defaultPic
                                 : Common.CommonValues.UPLOADED_PICS_PATH + item.Picture,
                            Price = Common.CommonValues.CURRENCY_SYMBOL + " " + decimal.Round(item.Price, 2),
                            Rating = item.Quality,
                            Span = Common.CommonFunctions.GetPassedTimeSpanFromNow(item.PostedDateTime),
                            Title = Common.CommonFunctions.GetAdTitle(item.Seller.Name.ToString(), item.Item.Name, item.City.Name)
                        });
                    }
                }
            }
            return PartialView("_AdsListingPartial", ads);
        }
        [Route("/Products/Fertilizers")]
        public IActionResult ViewFertilizers() => View();
        public async Task<IActionResult> GetFertilizers()
        {
            List<AdViewModel> ads = new List<AdViewModel>();
            using (var scope = container.BeginLifetimeScope())
            {
                short categoryId = 0;
                using (var categoryRepo = scope.Resolve<ICategoryRepository>())
                {
                    foreach (var item in await categoryRepo.ReadAllAsync())
                    {
                        if (item.Name.ToLower().Contains("fertilizers"))
                        {
                            categoryId = item.Id;
                        }
                    }
                }
                using (var adsRepository = scope.Resolve<IAdvertisementRepository>())
                {
                    foreach (var item in await adsRepository.GetAdvertisementsByCategoryAsync(new EFarmer.Models.Category { Id = categoryId }, 1, 6))
                    {
                        var defaultPic = Common.CommonValues.UPLOADED_PICS_PATH;
                        defaultPic += Common.CommonValues.FERTILIZER_DEFAULT_PIC;
                        ads.Add(new AdViewModel
                        {
                            Category = item.Item.Category.Name,
                            CategoryId = item.Item.Category.Id,
                            Id = item.Id,
                            Location = item.City.Name,
                            Picture = (string.IsNullOrEmpty(item.Picture)
                                 || string.IsNullOrWhiteSpace(item.Picture))
                                 ? defaultPic
                                 : Common.CommonValues.UPLOADED_PICS_PATH + item.Picture,
                            Price = Common.CommonValues.CURRENCY_SYMBOL + " " + decimal.Round(item.Price, 2),
                            Rating = item.Quality,
                            Span = Common.CommonFunctions.GetPassedTimeSpanFromNow(item.PostedDateTime),
                            Title = Common.CommonFunctions.GetAdTitle(item.Seller.Name.ToString(), item.Item.Name, item.City.Name)
                        });
                    }
                }
            }
            return PartialView("_AdsListingPartial", ads);
        }
        public async Task<IActionResult> LoadFertilizers(int count, int lastIndex)
        {
            int startRow = lastIndex + 1;
            int endRow = startRow + count;
            List<AdViewModel> ads = new List<AdViewModel>();
            using (var scope = container.BeginLifetimeScope())
            {
                short categoryId = 0;
                using (var categoryRepo = scope.Resolve<ICategoryRepository>())
                {
                    foreach (var item in await categoryRepo.ReadAllAsync())
                    {
                        if (item.Name.ToLower().Contains("fertilizers"))
                        {
                            categoryId = item.Id;
                        }
                    }
                }
                using (var adsRepository = scope.Resolve<IAdvertisementRepository>())
                {
                    foreach (var item in await adsRepository.GetAdvertisementsByCategoryAsync(new EFarmer.Models.Category { Id = categoryId }, startRow, endRow))
                    {
                        var defaultPic = Common.CommonValues.UPLOADED_PICS_PATH;
                        defaultPic += Common.CommonValues.FERTILIZER_DEFAULT_PIC;
                        ads.Add(new AdViewModel
                        {
                            Category = item.Item.Category.Name,
                            CategoryId = item.Item.Category.Id,
                            Id = item.Id,
                            Location = item.City.Name,
                            Picture = (string.IsNullOrEmpty(item.Picture)
                                 || string.IsNullOrWhiteSpace(item.Picture))
                                 ? defaultPic
                                 : Common.CommonValues.UPLOADED_PICS_PATH + item.Picture,
                            Price = Common.CommonValues.CURRENCY_SYMBOL + " " + decimal.Round(item.Price, 2),
                            Rating = item.Quality,
                            Span = Common.CommonFunctions.GetPassedTimeSpanFromNow(item.PostedDateTime),
                            Title = Common.CommonFunctions.GetAdTitle(item.Seller.Name.ToString(), item.Item.Name, item.City.Name)
                        });
                    }
                }
            }
            return PartialView("_AdsListingPartial", ads);
        }
        [Route("/Products/Seeds/Crops")]
        public IActionResult ViewCropsSeeds()
        {
            return View();
        }
        public async Task<IActionResult> GetCropsSeeds()
        {
            List<AdViewModel> ads = new List<AdViewModel>();
            using (var scope = container.BeginLifetimeScope())
            {
                short categoryId = 0;
                using (var categoryRepo = scope.Resolve<ICategoryRepository>())
                {
                    foreach (var item in await categoryRepo.ReadAllAsync())
                    {
                        if (item.Name.ToLower().Contains("crop seeds"))
                        {
                            categoryId = item.Id;
                        }
                    }
                }
                using (var adsRepository = scope.Resolve<IAdvertisementRepository>())
                {
                    foreach (var item in await adsRepository.GetAdvertisementsByCategoryAsync(new EFarmer.Models.Category { Id = categoryId }, 1, 6))
                    {
                        var defaultPic = Common.CommonValues.UPLOADED_PICS_PATH;
                        defaultPic += Common.CommonValues.SEEDS_DEFAULT_PIC;
                        ads.Add(new AdViewModel
                        {
                            Category = item.Item.Category.Name,
                            CategoryId = item.Item.Category.Id,
                            Id = item.Id,
                            Location = item.City.Name,
                            Picture = (string.IsNullOrEmpty(item.Picture)
                                 || string.IsNullOrWhiteSpace(item.Picture))
                                 ? defaultPic
                                 : Common.CommonValues.UPLOADED_PICS_PATH + item.Picture,
                            Price = Common.CommonValues.CURRENCY_SYMBOL + " " + decimal.Round(item.Price, 2),
                            Rating = item.Quality,
                            Span = Common.CommonFunctions.GetPassedTimeSpanFromNow(item.PostedDateTime),
                            Title = Common.CommonFunctions.GetAdTitle(item.Seller.Name.ToString(), item.Item.Name, item.City.Name)
                        });
                    }
                }
            }
            return PartialView("_AdsListingPartial", ads);
        }
        public async Task<IActionResult> LoadCropsSeeds(int count, int lastIndex)
        {
            int startRow = lastIndex + 1;
            int endRow = startRow + count;
            List<AdViewModel> ads = new List<AdViewModel>();
            using (var scope = container.BeginLifetimeScope())
            {
                short categoryId = 0;
                using (var categoryRepo = scope.Resolve<ICategoryRepository>())
                {
                    foreach (var item in await categoryRepo.ReadAllAsync())
                    {
                        if (item.Name.ToLower().Contains("crop seeds"))
                        {
                            categoryId = item.Id;
                        }
                    }
                }
                using (var adsRepository = scope.Resolve<IAdvertisementRepository>())
                {
                    foreach (var item in await adsRepository.GetAdvertisementsByCategoryAsync(new EFarmer.Models.Category { Id = categoryId }, startRow, endRow))
                    {
                        var defaultPic = Common.CommonValues.UPLOADED_PICS_PATH;
                        defaultPic += Common.CommonValues.SEEDS_DEFAULT_PIC;
                        ads.Add(new AdViewModel
                        {
                            Category = item.Item.Category.Name,
                            CategoryId = item.Item.Category.Id,
                            Id = item.Id,
                            Location = item.City.Name,
                            Picture = (string.IsNullOrEmpty(item.Picture)
                                 || string.IsNullOrWhiteSpace(item.Picture))
                                 ? defaultPic
                                 : Common.CommonValues.UPLOADED_PICS_PATH + item.Picture,
                            Price = Common.CommonValues.CURRENCY_SYMBOL + " " + decimal.Round(item.Price, 2),
                            Rating = item.Quality,
                            Span = Common.CommonFunctions.GetPassedTimeSpanFromNow(item.PostedDateTime),
                            Title = Common.CommonFunctions.GetAdTitle(item.Seller.Name.ToString(), item.Item.Name, item.City.Name)
                        });
                    }
                }
            }
            return PartialView("_AdsListingPartial", ads);
        }
        [Route("/Products/Seeds/Fruits")]
        public IActionResult ViewFruitsSeeds()
        {
            return View();
        }
        public async Task<IActionResult> GetFruitsSeeds()
        {
            List<AdViewModel> ads = new List<AdViewModel>();
            using (var scope = container.BeginLifetimeScope())
            {
                short categoryId = 0;
                using (var categoryRepo = scope.Resolve<ICategoryRepository>())
                {
                    foreach (var item in await categoryRepo.ReadAllAsync())
                    {
                        if (item.Name.ToLower().Contains("fruit seeds"))
                        {
                            categoryId = item.Id;
                        }
                    }
                }
                using (var adsRepository = scope.Resolve<IAdvertisementRepository>())
                {
                    foreach (var item in await adsRepository.GetAdvertisementsByCategoryAsync(new EFarmer.Models.Category { Id = categoryId }, 1, 6))
                    {
                        var defaultPic = Common.CommonValues.UPLOADED_PICS_PATH;
                        defaultPic += Common.CommonValues.SEEDS_DEFAULT_PIC;
                        ads.Add(new AdViewModel
                        {
                            Category = item.Item.Category.Name,
                            CategoryId = item.Item.Category.Id,
                            Id = item.Id,
                            Location = item.City.Name,
                            Picture = (string.IsNullOrEmpty(item.Picture)
                                 || string.IsNullOrWhiteSpace(item.Picture))
                                 ? defaultPic
                                 : Common.CommonValues.UPLOADED_PICS_PATH + item.Picture,
                            Price = Common.CommonValues.CURRENCY_SYMBOL + " " + decimal.Round(item.Price, 2),
                            Rating = item.Quality,
                            Span = Common.CommonFunctions.GetPassedTimeSpanFromNow(item.PostedDateTime),
                            Title = Common.CommonFunctions.GetAdTitle(item.Seller.Name.ToString(), item.Item.Name, item.City.Name)
                        });
                    }
                }
            }
            return PartialView("_AdsListingPartial", ads);
        }
        public async Task<IActionResult> LoadFruitsSeeds(int count, int lastIndex)
        {
            int startRow = lastIndex + 1;
            int endRow = startRow + count;
            List<AdViewModel> ads = new List<AdViewModel>();
            using (var scope = container.BeginLifetimeScope())
            {
                short categoryId = 0;
                using (var categoryRepo = scope.Resolve<ICategoryRepository>())
                {
                    foreach (var item in await categoryRepo.ReadAllAsync())
                    {
                        if (item.Name.ToLower().Contains("fruit seeds"))
                        {
                            categoryId = item.Id;
                        }
                    }
                }
                using (var adsRepository = scope.Resolve<IAdvertisementRepository>())
                {
                    foreach (var item in await adsRepository.GetAdvertisementsByCategoryAsync(new EFarmer.Models.Category { Id = categoryId }, startRow, endRow))
                    {
                        var defaultPic = Common.CommonValues.UPLOADED_PICS_PATH;
                        defaultPic += Common.CommonValues.SEEDS_DEFAULT_PIC;
                        ads.Add(new AdViewModel
                        {
                            Category = item.Item.Category.Name,
                            CategoryId = item.Item.Category.Id,
                            Id = item.Id,
                            Location = item.City.Name,
                            Picture = (string.IsNullOrEmpty(item.Picture)
                                 || string.IsNullOrWhiteSpace(item.Picture))
                                 ? defaultPic
                                 : Common.CommonValues.UPLOADED_PICS_PATH + item.Picture,
                            Price = Common.CommonValues.CURRENCY_SYMBOL + " " + decimal.Round(item.Price, 2),
                            Rating = item.Quality,
                            Span = Common.CommonFunctions.GetPassedTimeSpanFromNow(item.PostedDateTime),
                            Title = Common.CommonFunctions.GetAdTitle(item.Seller.Name.ToString(), item.Item.Name, item.City.Name)
                        });
                    }
                }
            }
            return PartialView("_AdsListingPartial", ads);
        }
        [Route("/Products/Seeds/Vegetables")]
        public IActionResult ViewVegetablesSeeds()
        {
            return View();
        }
        public async Task<IActionResult> GetVegetablesSeeds()
        {
            List<AdViewModel> ads = new List<AdViewModel>();
            using (var scope = container.BeginLifetimeScope())
            {
                short categoryId = 0;
                using (var categoryRepo = scope.Resolve<ICategoryRepository>())
                {
                    foreach (var item in await categoryRepo.ReadAllAsync())
                    {
                        if (item.Name.ToLower().Contains("vegetable seeds"))
                        {
                            categoryId = item.Id;
                        }
                    }
                }
                using (var adsRepository = scope.Resolve<IAdvertisementRepository>())
                {
                    foreach (var item in await adsRepository.GetAdvertisementsByCategoryAsync(new EFarmer.Models.Category { Id = categoryId }, 1, 6))
                    {
                        var defaultPic = Common.CommonValues.UPLOADED_PICS_PATH;
                        defaultPic += Common.CommonValues.SEEDS_DEFAULT_PIC;
                        ads.Add(new AdViewModel
                        {
                            Category = item.Item.Category.Name,
                            CategoryId = item.Item.Category.Id,
                            Id = item.Id,
                            Location = item.City.Name,
                            Picture = (string.IsNullOrEmpty(item.Picture)
                                 || string.IsNullOrWhiteSpace(item.Picture))
                                 ? defaultPic
                                 : Common.CommonValues.UPLOADED_PICS_PATH + item.Picture,
                            Price = Common.CommonValues.CURRENCY_SYMBOL + " " + decimal.Round(item.Price, 2),
                            Rating = item.Quality,
                            Span = Common.CommonFunctions.GetPassedTimeSpanFromNow(item.PostedDateTime),
                            Title = Common.CommonFunctions.GetAdTitle(item.Seller.Name.ToString(), item.Item.Name, item.City.Name)
                        });
                    }
                }
            }
            return PartialView("_AdsListingPartial", ads);
        }
        public async Task<IActionResult> LoadVegetablesSeeds(int count, int lastIndex)
        {
            int startRow = lastIndex + 1;
            int endRow = startRow + count;
            List<AdViewModel> ads = new List<AdViewModel>();
            using (var scope = container.BeginLifetimeScope())
            {
                short categoryId = 0;
                using (var categoryRepo = scope.Resolve<ICategoryRepository>())
                {
                    foreach (var item in await categoryRepo.ReadAllAsync())
                    {
                        if (item.Name.ToLower().Contains("vegetable seeds"))
                        {
                            categoryId = item.Id;
                        }
                    }
                }
                using (var adsRepository = scope.Resolve<IAdvertisementRepository>())
                {
                    foreach (var item in await adsRepository.GetAdvertisementsByCategoryAsync(new EFarmer.Models.Category { Id = categoryId }, startRow, endRow))
                    {
                        var defaultPic = Common.CommonValues.UPLOADED_PICS_PATH;
                        defaultPic += Common.CommonValues.SEEDS_DEFAULT_PIC;
                        ads.Add(new AdViewModel
                        {
                            Category = item.Item.Category.Name,
                            CategoryId = item.Item.Category.Id,
                            Id = item.Id,
                            Location = item.City.Name,
                            Picture = (string.IsNullOrEmpty(item.Picture)
                                 || string.IsNullOrWhiteSpace(item.Picture))
                                 ? defaultPic
                                 : Common.CommonValues.UPLOADED_PICS_PATH + item.Picture,
                            Price = Common.CommonValues.CURRENCY_SYMBOL + " " + decimal.Round(item.Price, 2),
                            Rating = item.Quality,
                            Span = Common.CommonFunctions.GetPassedTimeSpanFromNow(item.PostedDateTime),
                            Title = Common.CommonFunctions.GetAdTitle(item.Seller.Name.ToString(), item.Item.Name, item.City.Name)
                        });
                    }
                }
            }
            return PartialView("_AdsListingPartial", ads);
        }
    }
}