using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFarmer.pk.Areas.Admin.Common;
using EFarmer.pk.Areas.Admin.Models;
using JqueryDataTables.ServerSide.AspNetCoreWeb.Extentions;
using JqueryDataTables.ServerSide.AspNetCoreWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFarmer.pk.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AgroItemsController : Controller
    {
        private const string emptyString = "";
        public IActionResult Index(string successMessage = emptyString, string errorMessage = emptyString, string warningMessage = emptyString, string infoMessage = emptyString)
        {
            ViewBag.Create = pk.Common.CommonValues.CREATE_CAPTION;
            ViewBag.BreadCrumb = Common.Functions.CreateBreadCrumb(new Models.Shared.BreadCrumb
            {
                Link = Url.Action("Index", "Dashboard"),
                Name = "Admin"
            },
            new Models.Shared.BreadCrumb
            {
                IsActive = true,
                IsLast = true,
                Name = "Agro Items"
            });
            ViewBag.Info = infoMessage;
            ViewBag.Success = successMessage;
            ViewBag.Error = errorMessage;
            ViewBag.Warning = warningMessage;
            return View();
        }
        [HttpPost]
        public IActionResult GetDtAgroItems([FromBody]JqueryDataTablesParameters dataTableParams)
        {
            List<AgroItemListingModel> data = new List<AgroItemListingModel>
            {
                new AgroItemListingModel
                {
                    Id = 1,
                    Name = "Wheat",
                    Category="Crops",
                    WeightScale="Ton"
                },
                new AgroItemListingModel
                {
                    Id = 2,
                    Name = "Rice",
                    Category="Crops",
                    WeightScale="Ton"
                },
                new AgroItemListingModel
                {
                    Id = 3,
                    Name = "Cauliflower",
                    Category="Vegetables",
                    WeightScale="Kg"
                },
                new AgroItemListingModel
                {
                    Id = 4,
                    Name = "Mango",
                    Category="Fruits",
                    WeightScale="Kg"
                },
                new AgroItemListingModel
                {
                    Id = 5,
                    Name = "Cotton",
                    Category="Crops",
                    WeightScale="Ton"
                },
                new AgroItemListingModel
                {
                    Id = 6,
                    Name = "Chemical X",
                    Category="Pesticide",
                    WeightScale="Liter"
                },
                new AgroItemListingModel
                {
                    Id = 7,
                    Name = "Chemical Y",
                    Category="Pesticide",
                    WeightScale="Liter"
                },
                new AgroItemListingModel
                {
                    Id = 8,
                    Name = "Cucumber",
                    Category="Vegetables",
                    WeightScale="Kg"
                },
                new AgroItemListingModel
                {
                    Id = 9,
                    Name = "Apple",
                    Category="Fruits",
                    WeightScale="Kg"
                },
                new AgroItemListingModel
                {
                    Id = 10,
                    Name = "Barley",
                    Category="Crops",
                    WeightScale="Ton"
                },
                new AgroItemListingModel
                {
                    Id = 11,
                    Name = "Tomato",
                    Category="Vegetables",
                    WeightScale="Kg"
                },
                new AgroItemListingModel
                {
                    Id = 12,
                    Name = "Banana",
                    Category="Fruits",
                    WeightScale="Kg"
                }
            };
            foreach (var order in dataTableParams.Order.Reverse())
            {
                if (order.Dir == DTOrderDir.ASC)
                {
                    switch (order.Column)
                    {
                        case 0:
                            data = data.OrderBy(x => x.Id).ToList();
                            break;
                        case 2:
                            data = data.OrderBy(x => x.Name).ToList();
                            break;
                        case 3:
                            data = data.OrderBy(x => x.Category).ToList();
                            break;
                        case 4:
                            data = data.OrderBy(x => x.WeightScale).ToList();
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
                        case 2:
                            data = data.OrderByDescending(x => x.Name).ToList();
                            break;
                        case 3:
                            data = data.OrderByDescending(x => x.Category).ToList();
                            break;
                        case 4:
                            data = data.OrderByDescending(x => x.WeightScale).ToList();
                            break;
                    }
                }
            }
            data.ForEach(x => x.ActionButtons = RenderedActionButtons.GetActionButtons(insightsCallback: $"ItemInsights({x.Id})", editCallback: $"EditItem({x.Id})", deleteCallback: $"DeleteItem({x.Id})"));
            var searchedResult = data.Where(x => x.Name.ToLower()
                                                .Contains(dataTableParams.Search.Value.ToLower())
                                                || x.Category.ToLower()
                                                             .Contains(dataTableParams.Search.Value.ToLower())
                                                             || x.WeightScale.ToLower()
                                                                                .Contains(dataTableParams.Search
                                                                                .Value.ToLower()));
            var result = searchedResult.Skip(dataTableParams.Start)
                                       .Take(dataTableParams.Length)
                                       .ToDataTable(dataTableParams.Draw, data.Count, searchedResult.Count());

            return Json(result);
        }
        [HttpPost]
        public IActionResult DeleteItem(int id)
        {
            return Json("Your data has been deleted");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditAgroItem(AgroItemViewModel model)
        {
            return RedirectToAction("Index", new { successMessage = EFarmer.pk.Common.CommonValues.UPDATE_MESSAGE });
        }
        [HttpPost]
        public IActionResult GetFormData(int id)
        {
            AgroItemViewModel model = new AgroItemViewModel
            {
                Id = id,
                Name = "Wheat",
                Category = 1,
                WeightScale = "Ton"
            };
            return Json(model);
        }
        [HttpPost]
        public IActionResult GetBarChartData(int id)
        {
            BarChartViewModel model = new BarChartViewModel
            {
                Ledgend = new List<BarChartModel>
            {
                new BarChartModel
                {
                    Color = "#28c7fa",
                    Label = "Sellers",
                    Data = new List<BarChartData>
                   {
                       new BarChartData
                       {
                            Category="Week 1",
                             Value=20m
                       },
                       new BarChartData
                       {
                            Category="Week 2",
                             Value=25m
                       },
                       new BarChartData
                       {
                            Category="Week 3",
                             Value=57m
                       },
                       new BarChartData
                       {
                            Category="Week 4",
                             Value=76m
                       }
                   }
                },
                new BarChartModel
                {
                    Color = "#ff304f",
                    Label = "Buyers",
                    Data = new List<BarChartData>
                   {
                       new BarChartData
                       {
                            Category="Week 1",
                             Value=5m
                       },
                       new BarChartData
                       {
                            Category="Week 2",
                             Value=7m
                       },
                       new BarChartData
                       {
                            Category="Week 3",
                             Value=17m
                       },
                       new BarChartData
                       {
                            Category="Week 4",
                             Value=6m
                       }
                    }
                }
                }
            };
            return Json(model);
        }
    }

}