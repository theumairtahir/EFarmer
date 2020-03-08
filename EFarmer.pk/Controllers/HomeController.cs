using Autofac;
using EFarmer.Models;
using EFarmer.pk.Models;
using EFarmer.pk.ViewModels.HomeViewModels;
using EFarmer.ViewModels;
using EFarmerPkModelLibrary.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace EFarmer.pk.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContainer _container;
        private readonly IStringLocalizer<HomeController> _localizer;
        readonly IHostingEnvironment environment;
        public HomeController(IStringLocalizer<HomeController> localizer, IHostingEnvironment environment)
        {
            _container = new ModelsFactory().Build();
            _localizer = localizer;
            this.environment = environment;
        }
        public IActionResult Index(string culture)
        {
            var cookie = Request.Cookies[CookieRequestCultureProvider.DefaultCookieName];
            if (cookie == null)
            {
                culture = culture ?? "en";
                Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                        CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                        new Microsoft.AspNetCore.Http.CookieOptions { Expires = DateTimeOffset.UtcNow.AddMonths(1) });
            }
            else
            {
                culture = culture ?? CookieRequestCultureProvider.ParseCookieValue(cookie).Cultures[0].Value;
                if (!cookie.Contains(CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture))))
                {
                    Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                        CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                        new Microsoft.AspNetCore.Http.CookieOptions { Expires = DateTimeOffset.UtcNow.AddMonths(1) });
                }
            }
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async System.Threading.Tasks.Task<IActionResult> GetAgroItemsByCategory(short id)
        {
            string options = "<option label=" + _localizer["Select_an_Item"] + "></option>";
            using (var scope = _container.BeginLifetimeScope())
            {
                using (var itemsRepository = scope.Resolve<IAgroItemRepository>())
                {
                    foreach (var item in await itemsRepository.GetAgroItemsByCategoryAsync(new Category { Id = id }))
                    {
                        options += "<option value='" + item.Id + "'>" + _localizer[item.Name].Value + "</option>";
                    }
                }
            }
            return Content(options);
        }
        public async System.Threading.Tasks.Task<IActionResult> _IndexAdsPartial()
        {
            List<AdViewModel> ads = new List<AdViewModel>();
            using (var scope = _container.BeginLifetimeScope())
            {
                using (var adsRepository = scope.Resolve<IAdvertisementRepository>())
                {
                    foreach (var item in await adsRepository.ReadRowsAsync(1, 6))
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
        public async System.Threading.Tasks.Task<IActionResult> _LoadAdPartial(int count, int lastIndex)
        {
            int startRow = lastIndex + 1;
            int endRow = startRow + count;
            List<AdViewModel> ads = new List<AdViewModel>();
            using (var scope = _container.BeginLifetimeScope())
            {
                using (var adsRepository = scope.Resolve<IAdvertisementRepository>())
                {
                    foreach (var item in await adsRepository.ReadRowsAsync(startRow, endRow))
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
