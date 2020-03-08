using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFarmer.pk.ViewModels.AdvertisementsViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EFarmer.pk.Controllers
{
    public class AdvertisementsController : Controller
    {
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
            return PartialView("_FeaturedAds",model);
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
    }
}