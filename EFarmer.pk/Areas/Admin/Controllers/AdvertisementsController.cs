using EFarmer.pk.Areas.Admin.Common;
using EFarmer.pk.Areas.Admin.Models;
using JqueryDataTables.ServerSide.AspNetCoreWeb.Extentions;
using JqueryDataTables.ServerSide.AspNetCoreWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFarmer.pk.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdvertisementsController : Controller
    {
        private const string emptyString = "";
        public IActionResult Index(string successMessage = emptyString, string errorMessage = emptyString, string warningMessage = emptyString, string infoMessage = emptyString)
        {
            ViewBag.BreadCrumb = Common.Functions.CreateBreadCrumb(new Models.Shared.BreadCrumb
            {
                Link = Url.Action("Index", "Dashboard"),
                Name = "Admin"
            },
            new Models.Shared.BreadCrumb
            {
                IsActive = true,
                IsLast = true,
                Name = "Advertisements"
            });
            ViewBag.Info = infoMessage;
            ViewBag.Success = successMessage;
            ViewBag.Error = errorMessage;
            ViewBag.Warning = warningMessage;
            return View();
        }
        [HttpPost]
        public IActionResult GetDtAdvertisements([FromBody] JqueryDataTablesParameters dataTableParams)
        {
            List<AdvertisementListingModel> data = new List<AdvertisementListingModel>();
            data.Add(new AdvertisementListingModel
            {
                Bids = 5,
                City = "Lahore",
                Id = 1,
                ItemName = "Wheat Crop",
                Picture = @"<img src=""../uploaded_images/agri_crop.jpg"" class=""img-thumbnail thumbnail""/>",
                PostedTime = "10/08/2020",
                Price = "Rs. 50,000",
                Quantity = "50 Ton",
                SellerName = "Mushtaq Ahmad"
            });
            data.Add(new AdvertisementListingModel
            {
                Bids = 8,
                City = "Hyderabad",
                Id = 2,
                ItemName = "Apples",
                Picture = @"<img src=""../uploaded_images/agri_fruit.jpg"" class=""img-thumbnail thumbnail""/>",
                PostedTime = "1/08/2020",
                Price = "Rs. 100,000",
                Quantity = "50 Ton",
                SellerName = "Wakeel Ali"
            });
            foreach (var order in dataTableParams.Order.Reverse())
            {
                if (order.Dir == DTOrderDir.ASC)
                {
                    switch (order.Column)
                    {
                        case 0:
                            data = data.OrderBy(x => x.Id).ToList();
                            break;
                        case 3:
                            data = data.OrderBy(x => x.ItemName).ToList();
                            break;
                        case 4:
                            data = data.OrderBy(x => x.Bids).ToList();
                            break;
                    }
                }
                else
                {
                    switch (order.Column)
                    {
                        case 0:
                            data = data.OrderByDescending(x => x.Id).ToList();
                            break;
                        case 3:
                            data = data.OrderByDescending(x => x.ItemName).ToList();
                            break;
                        case 4:
                            data = data.OrderByDescending(x => x.Bids).ToList();
                            break;
                    }
                }
            }
            data.ForEach(x => x.ActionButtons = RenderedActionButtons.GetActionButtonsWithBlockIcon(insightsCallback: $"AdvertisementInsights({x.Id})", blockCallback: $"BlockAdvertisement({x.Id})"));
            var searchedResult = data.Where(x => x.ItemName.ToLower()
                                                .Contains(dataTableParams.Search.Value.ToLower())
                                                || x.Price.ToLower()
                                                             .Contains(dataTableParams.Search.Value.ToLower())
                                                             || x.SellerName.ToLower()
                                                                                .Contains(dataTableParams.Search
                                                                                .Value.ToLower()));
            var result = searchedResult.Skip(dataTableParams.Start)
                                       .Take(dataTableParams.Length)
                                       .ToDataTable(dataTableParams.Draw, data.Count, searchedResult.Count());

            return Json(result);
        }
        [HttpPost]
        public IActionResult BlockItem(int id)
        {
            return Json("The Advertisement has been blocked.");
        }
        [HttpPost]
        public IActionResult GetBidChartData(int id)
        {
            List<BidChartModel> model = new List<BidChartModel>();
            model.Add(new BidChartModel
            {
                Date = DateTime.Today.AddDays(-90),
                NoOfBids = 5
            });
            model.Add(new BidChartModel
            {
                Date = DateTime.Today.AddDays(-85),
                NoOfBids = 10
            });
            model.Add(new BidChartModel
            {
                Date = DateTime.Today.AddDays(-60),
                NoOfBids = 15
            });
            model.Add(new BidChartModel
            {
                Date = DateTime.Today.AddDays(-50),
                NoOfBids = 12
            });
            model.Add(new BidChartModel
            {
                Date = DateTime.Today.AddDays(-46),
                NoOfBids = 25
            });
            model.Add(new BidChartModel
            {
                Date = DateTime.Today.AddDays(-30),
                NoOfBids = 15
            });
            model.Add(new BidChartModel
            {
                Date = DateTime.Today.AddDays(-20),
                NoOfBids = 5
            });
            model.Add(new BidChartModel
            {
                Date = DateTime.Today.AddDays(-10),
                NoOfBids = 25
            });
            model.Add(new BidChartModel
            {
                Date = DateTime.Today.AddDays(-5),
                NoOfBids = 12
            });
            model.Add(new BidChartModel
            {
                Date = DateTime.Today,
                NoOfBids = 2
            });
            return Json(model);
        }
    }
}
