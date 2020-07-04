using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFarmer.pk.Areas.Admin.Common;
using EFarmer.pk.Areas.Admin.Models;
using JqueryDataTables.ServerSide.AspNetCoreWeb.Extentions;
using JqueryDataTables.ServerSide.AspNetCoreWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EFarmer.pk.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CitiesController : Controller
    {
        private const string emptyString = "";
        public IActionResult Index(string successMessage = emptyString, string errorMessage = emptyString, string warningMessage = emptyString, string infoMessage = emptyString)
        {
            ViewBag.Create = pk.Common.CommonValues.CREATE_MESSAGE;
            ViewBag.BreadCrumb = Common.Functions.CreateBreadCrumb(new Models.Shared.BreadCrumb
            {
                Link = Url.Action("Index", "Dashboard"),
                Name = "Admin"
            },
            new Models.Shared.BreadCrumb
            {
                IsActive = true,
                IsLast = true,
                Name = "Cities"
            });
            ViewBag.Info = infoMessage;
            ViewBag.Success = successMessage;
            ViewBag.Error = errorMessage;
            ViewBag.Warning = warningMessage;
            return View();
        }
        [HttpPost]
        public IActionResult GetDtCities([FromBody]JqueryDataTablesParameters dataTableParams)
        {
            List<CitiesListingViewModel> data = new List<CitiesListingViewModel>
            {
                new CitiesListingViewModel
                {
                    Id = 1,
                    Name = "Lahore"
                },
                new CitiesListingViewModel
                {
                    Id = 2,
                    Name = "Islamabad"
                },
                new CitiesListingViewModel
                {
                    Id = 3,
                    Name = "Karachi"
                },
                new CitiesListingViewModel
                {
                    Id = 4,
                    Name = "Peshawar"
                },
                new CitiesListingViewModel
                {
                    Id = 5,
                    Name = "Quetta"
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
                        case 1:
                            data = data.OrderBy(x => x.Name).ToList();
                            break;
                        default:
                            data = data.OrderBy(x => x.Name).ToList();
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
                        case 1:
                            data = data.OrderByDescending(x => x.Name).ToList();
                            break;
                        default:
                            data = data.OrderByDescending(x => x.Name).ToList();
                            break;
                    }
                }
            }
            data.ForEach(x => x.ActionButtons = RenderedActionButtons.GetActionButtons(insightsCallback: $"CityInsights({x.Id})", editCallback: $"EditCity({x.Id})", deleteCallback: $"DeleteCity({x.Id})"));
            var result = data.Where(x => x.Name.ToLower()
                                                .Contains(dataTableParams.Search.Value.ToLower()))
                            .Skip(dataTableParams.Start)
                            .Take(dataTableParams.Length)
                            .ToDataTable(dataTableParams.Draw, data.Count);
            try
            {
                return Json(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCity(CityViewModel model)
        {
            return RedirectToAction("Index", new { successMessage = EFarmer.pk.Common.CommonValues.UPDATE_MESSAGE });
        }
        [HttpPost]
        public IActionResult GetFormData(int id)
        {
            CityViewModel model = new CityViewModel
            {
                Id = id,
                Name = "Lahore"
            };
            return Json(model);
        }
        [HttpPost]
        public IActionResult DeleteCity(int id)
        {
            return Json("Your data has been deleted");
        }
        [HttpPost]
        public IActionResult GetPieChartData(int id)
        {
            var data = new List<RoseChartModel>
            {
                new RoseChartModel
                {
                    Color = "#feff89",
                    Label = "Wheat",
                    Value = 50
                },
                new RoseChartModel
                {
                    Color = "#ff9f68",
                    Label = "Sunflower",
                    Value = 15
                },
                new RoseChartModel
                {
                    Color = "#f85959",
                    Label = "Rice",
                    Value = 25
                },
                new RoseChartModel
                {
                    Color = "#7c203a",
                    Label = "Cotton",
                    Value = 10
                }
            };
            PieChartViewModel model = new PieChartViewModel
            {
                Legend = data
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
                    Label = "Ads. Posted",
                    Data = new List<BarChartData>
                   {
                       new BarChartData
                       {
                            Category="Jan",
                             Value=20m
                       },
                       new BarChartData
                       {
                            Category="Feb",
                             Value=25m
                       },
                       new BarChartData
                       {
                            Category="Mar",
                             Value=57m
                       },
                       new BarChartData
                       {
                            Category="Apr",
                             Value=76m
                       },
                       new BarChartData
                       {
                            Category="May",
                             Value=43m
                       },
                       new BarChartData
                       {
                            Category="Jun",
                             Value=56m
                       },
                       new BarChartData
                       {
                            Category="Jul",
                             Value=98m
                       },
                       new BarChartData
                       {
                            Category="Aug",
                             Value=78m
                       },
                       new BarChartData
                       {
                            Category="Sep",
                             Value=20m
                       },
                       new BarChartData
                       {
                            Category="Oct",
                             Value=45m
                       },
                       new BarChartData
                       {
                            Category="Nov",
                             Value=35m
                       },
                       new BarChartData
                       {
                            Category="Dec",
                             Value=65m
                       }
                   }
                },
                new BarChartModel
                {
                    Color = "#ff304f",
                    Label = "Users Joined",
                    Data = new List<BarChartData>
                   {
                       new BarChartData
                       {
                            Category="Jan",
                             Value=5m
                       },
                       new BarChartData
                       {
                            Category="Feb",
                             Value=7m
                       },
                       new BarChartData
                       {
                            Category="Mar",
                             Value=17m
                       },
                       new BarChartData
                       {
                            Category="Apr",
                             Value=6m
                       },
                       new BarChartData
                       {
                            Category="May",
                             Value=13m
                       },
                       new BarChartData
                       {
                            Category="Jun",
                             Value=26m
                       },
                       new BarChartData
                       {
                            Category="Jul",
                             Value=8m
                       },
                       new BarChartData
                       {
                            Category="Aug",
                             Value=27m
                       },
                       new BarChartData
                       {
                            Category="Sep",
                             Value=2m
                       },
                       new BarChartData
                       {
                            Category="Oct",
                             Value=45m
                       },
                       new BarChartData
                       {
                            Category="Nov",
                             Value=25m
                       },
                       new BarChartData
                       {
                            Category="Dec",
                             Value=16m
                       }
                   }
                }
            }
            };
            return Json(model);
        }
    }
}