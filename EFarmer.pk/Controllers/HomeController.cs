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
        public IActionResult _IndexAdsPartial()
        {
            //var imagePath = environment.WebRootFileProvider.GetFileInfo("uploaded_images/" + Common.CommonValues.CROP_DEFAULT_PIC)?.PhysicalPath;
            var imagePath = Common.CommonValues.CROP_DEFAULT_PIC;
            List<AdViewModel> ads = new List<AdViewModel>();
            ads.Add(new AdViewModel
            {
                Category = "Crops",
                Id = 1,
                CategoryId = 1,
                Location = "Lahore",
                Picture = imagePath,
                Price = "Rs. 10000",
                Rating = 4,
                Span = "15 mins ago",
                Title = "Lorem Ipsum"
            });
            ads.Add(new AdViewModel
            {
                Category = "Crops",
                Id = 1,
                CategoryId = 1,
                Location = "Lahore",
                Picture = imagePath,
                Price = "Rs. 10000",
                Rating = 4,
                Span = "15 mins ago",
                Title = "Lorem Ipsum"
            });
            ads.Add(new AdViewModel
            {
                Category = "Crops",
                Id = 1,
                CategoryId = 1,
                Location = "Lahore",
                Picture = imagePath,
                Price = "Rs. 10000",
                Rating = 4,
                Span = "15 mins ago",
                Title = "Lorem Ipsum"
            });
            ads.Add(new AdViewModel
            {
                Category = "Crops",
                Id = 1,
                CategoryId = 1,
                Location = "Lahore",
                Picture = imagePath,
                Price = "Rs. 10000",
                Rating = 4,
                Span = "15 mins ago",
                Title = "Lorem Ipsum"
            });
            ads.Add(new AdViewModel
            {
                Category = "Crops",
                Id = 1,
                CategoryId = 1,
                Location = "Lahore",
                Picture = imagePath,
                Price = "Rs. 10000",
                Rating = 4,
                Span = "15 mins ago",
                Title = "Lorem Ipsum"
            });
            ads.Add(new AdViewModel
            {
                Category = "Crops",
                Id = 1,
                CategoryId = 1,
                Location = "Lahore",
                Picture = imagePath,
                Price = "Rs. 10000",
                Rating = 4,
                Span = "15 mins ago",
                Title = "Lorem Ipsum"
            });
            return PartialView(ads);
        }
        public IActionResult _LoadAdPartial(int count)
        {
            var imagePath = Common.CommonValues.CROP_DEFAULT_PIC;
            List<AdViewModel> ads = new List<AdViewModel>();
            for (int i = 1; i <= count; i++)
            {
                ads.Add(new AdViewModel
                {
                    Category = "Crops",
                    Id = 1,
                    CategoryId = 1,
                    Location = "Lahore",
                    Picture = imagePath,
                    Price = "Rs. 10000",
                    Rating = 4,
                    Span = "15 mins ago",
                    Title = "Lorem Ipsum"
                });
            }
            return PartialView("_IndexAdsPartial", ads);
        }
    }
}
