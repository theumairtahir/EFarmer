using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFarmer.pk.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFarmer.pk.Areas.Admin.Controllers
{
    /// <summary>
    /// Manages admin dashboard
    /// </summary>
    [Area("Admin")]
    public class DashboardController : Controller
    {
        public DashboardController()
        {

        }
        public IActionResult Index()
        {
            ViewBag.CreateRight = "Add New";
            ViewBag.BreadCrumb = Common.Functions.CreateBreadCrumb(new Models.Shared.BreadCrumb
            {
                Link = Url.Action("Index", "Dashboard"),
                Name = "Admin"
            },
            new Models.Shared.BreadCrumb
            {
                IsActive = true,
                IsLast = true,
                Name = "Dashboard"
            });
            return View();
        }
        [HttpGet]
        public IActionResult GetAreaChart()
        {
            List<AdPostedChartModel> model = new List<AdPostedChartModel>();
            model.Add(new AdPostedChartModel
            {
                Month = new DateTime(2020, 01, 01),
                Bahawalpur = 10,
                Lahore = 20,
                Faisalabad = 15
            });
            model.Add(new AdPostedChartModel
            {
                Month = new DateTime(2020, 02, 01),
                Bahawalpur = 20,
                Lahore = 45,
                Faisalabad = 30
            });
            model.Add(new AdPostedChartModel
            {
                Month = new DateTime(2020, 03, 01),
                Bahawalpur = 43,
                Lahore = 54,
                Faisalabad = 65
            });
            model.Add(new AdPostedChartModel
            {
                Month = new DateTime(2020, 04, 01),
                Bahawalpur = 10,
                Lahore = 20,
                Faisalabad = 15
            });
            model.Add(new AdPostedChartModel
            {
                Month = new DateTime(2020, 05, 01),
                Bahawalpur = 50,
                Lahore = 70,
                Faisalabad = 45
            });
            model.Add(new AdPostedChartModel
            {
                Month = new DateTime(2020, 06, 01),
                Bahawalpur = 30,
                Lahore = 20,
                Faisalabad = 45
            });
            model.Add(new AdPostedChartModel
            {
                Month = new DateTime(2020, 07, 01),
                Bahawalpur = 20,
                Lahore = 10,
                Faisalabad = 15
            });
            return Json(model);
        }
        [HttpGet]
        public IActionResult GetTimelineBars()
        {
            List<TimelineBarChartModel> model = new List<TimelineBarChartModel>();
            model.Add(new TimelineBarChartModel
            {
                ElementId = "totalAdsPostedBar",
                Values = new List<int> { 10, 34, 20, 43, 13, 18, 35 },
                Color = "#00ffff"
            });
            model.Add(new TimelineBarChartModel
            {
                ElementId = "totalUsersBar",
                Values = new List<int> { 10, 34, 20, 43, 13, 18, 35 },
                Color = "#cc00ff"
            });
            model.Add(new TimelineBarChartModel
            {
                ElementId = "newUsersBar",
                Values = new List<int> { 10, 34, 20, 43, 13, 18, 35 },
                Color = "#ffd460"
            });
            model.Add(new TimelineBarChartModel
            {
                ElementId = "newAdsBar",
                Values = new List<int> { 10, 34, 20, 43, 13, 18, 35 },
                Color = "#34222e"
            });
            return Json(model);
        }
        [HttpGet]
        public IActionResult GetSeasonalOverview()
        {
            List<SeasonalOverviewChartModel> chartData = new List<SeasonalOverviewChartModel>();
            SeasonalOverviewViewModel model = new SeasonalOverviewViewModel();
            chartData.Add(new SeasonalOverviewChartModel
            {
                Crop = "Wheat",
                Season1 = 100,
                Season2 = 200,
                Season3 = 50,
                Season4 = 65
            });
            chartData.Add(new SeasonalOverviewChartModel
            {
                Crop = "Rice",
                Season1 = 200,
                Season2 = 100,
                Season3 = 90,
                Season4 = 10
            });
            chartData.Add(new SeasonalOverviewChartModel
            {
                Crop = "Cotton",
                Season1 = 150,
                Season2 = 90,
                Season3 = 250,
                Season4 = 110
            });
            model.ElementId = "seasonalOverviewChart";
            model.Labels = new List<ChartLabel>()
            {
                new ChartLabel
                {
                     Color="#47d0bd",
                      Label="Winter"
                }
                ,
                new ChartLabel
                {
                     Color="#ff5da2",
                      Label="Spring"
                },
               new ChartLabel
               {
                    Color="#fba834",
                     Label="Summer"
               },
               new ChartLabel
               {
                    Color="#daec8b",
                     Label="Autumn"
               }
            };
            model.Data = chartData;
            return Json(model);
        }
        [HttpGet]
        public IActionResult GetPopularityChart()
        {
            PopularityChartViewModel model = new PopularityChartViewModel();
            List<PopularityChartModel> data = new List<PopularityChartModel>();
            data.Add(new PopularityChartModel
            {
                Day = "01",
                CurrentMonth = 10,
                PrevMonth = 8
            });
            data.Add(new PopularityChartModel
            {
                Day = "02",
                CurrentMonth = 8,
                PrevMonth = 10
            });
            data.Add(new PopularityChartModel
            {
                Day = "03",
                CurrentMonth = 9,
                PrevMonth = 18
            });
            data.Add(new PopularityChartModel
            {
                Day = "04",
                CurrentMonth = 16,
                PrevMonth = 8
            });
            data.Add(new PopularityChartModel
            {
                Day = "05",
                CurrentMonth = 19,
                PrevMonth = 20
            });
            data.Add(new PopularityChartModel
            {
                Day = "06",
                CurrentMonth = 22,
                PrevMonth = 25
            });
            data.Add(new PopularityChartModel
            {
                Day = "07",
                CurrentMonth = 7,
                PrevMonth = 36
            });
            data.Add(new PopularityChartModel
            {
                Day = "08",
                CurrentMonth = 18,
                PrevMonth = 12
            });
            data.Add(new PopularityChartModel
            {
                Day = "09",
                CurrentMonth = 35,
                PrevMonth = 16
            });
            data.Add(new PopularityChartModel
            {
                Day = "10",
                CurrentMonth = 40,
                PrevMonth = 31
            });
            model.Data = data;
            model.Labels = new List<ChartLabel>()
            {
                 new ChartLabel
                 {
                      Color="#ff1f5a",
                       Label="Current Month"
                 },
                  new ChartLabel
                  {
                       Color="#1e2a78",
                        Label="Previous Month"
                  }
            };
            return Json(model);
        }
        [HttpGet]
        public IActionResult GetDashboardDetails()
        {
            DashboardViewModel model = new DashboardViewModel
            {
                IsNewAdsUp = true,
                IsNewUsersUp = false,
                NewAdsPercent = "40%",
                NewUsersPercent = "-10%",
                TotalAds = "1000",
                TotalUsers = "340",
                BuyersCount = "150",
                SellersCount = "190",
                CitiesCount = "5",
                CropsCount = "15"
            };

            return Json(model);
        }
    }
}