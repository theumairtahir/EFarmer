using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFarmer.pk.ViewModels.HomeViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EFarmer.pk.Controllers
{
    public class ProductsController : Controller
    {
        [Route("/Products/Crops")]
        public IActionResult ViewCrops()
        {
            return View();
        }
        public IActionResult GetCrops()
        {
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
            return PartialView("_AdsListingPartial", ads);
        }
        public IActionResult LoadCrops(int count, int lastIndex)
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
            return PartialView("_AdsListingPartial", ads);
        }
    }
}