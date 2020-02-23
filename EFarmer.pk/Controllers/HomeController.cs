using Autofac;
using EFarmer.Models;
using EFarmer.pk.Models;
using EFarmer.ViewModels;
using EFarmerPkModelLibrary.Repositories;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Diagnostics;

namespace EFarmer.pk.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContainer _container;
        private readonly IStringLocalizer<HomeController> _localizer;
        public HomeController(IStringLocalizer<HomeController> localizer)
        {
            _container = new ModelsFactory().Build();
            _localizer = localizer;
        }
        public IActionResult Index(string culture)
        {
            culture = (culture == null) ? "en" : culture;
            if (Request.Cookies[CookieRequestCultureProvider.DefaultCookieName] != null
                && !Request.Cookies[CookieRequestCultureProvider.DefaultCookieName].Contains(CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture))))
            {
                Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                        CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                        new Microsoft.AspNetCore.Http.CookieOptions { Expires = DateTimeOffset.UtcNow.AddMonths(1) });
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
    }
}
