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
    public class CategoriesController : Controller
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
                Name = "Categories"
            });
            ViewBag.Info = infoMessage;
            ViewBag.Success = successMessage;
            ViewBag.Error = errorMessage;
            ViewBag.Warning = warningMessage;
            return View();
        }
        [HttpPost]
        public IActionResult GetDtCategories([FromBody]JqueryDataTablesParameters dataTableParams)
        {
            List<CategoriesListingViewModel> data = new List<CategoriesListingViewModel>
            {
                new CategoriesListingViewModel
                {
                    Id = 1,
                    Name = "Crops"
                },
                new CategoriesListingViewModel
                {
                    Id = 2,
                    Name = "Fruits"
                },
                new CategoriesListingViewModel
                {
                    Id = 3,
                    Name = "Vegetables"
                },
                new CategoriesListingViewModel
                {
                    Id = 4,
                    Name = "Pesticides"
                },
                new CategoriesListingViewModel
                {
                    Id = 5,
                    Name = "Machinary"
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
            data.ForEach(x => x.ActionButtons = RenderedActionButtons.GetActionButtons(insightsCallback: $"CategoryInsights({x.Id})", editCallback: $"EditCategory({x.Id})", deleteCallback: $"DeleteCategory({x.Id})"));
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
        public IActionResult DeleteCategory(int id)
        {
            return Json(pk.Common.CommonValues.DELETE_MESSAGE);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCategory(CategoryViewModel model)
        {
            return RedirectToAction("Index", new { successMessage = pk.Common.CommonValues.UPDATE_MESSAGE });
        }
        [HttpPost]
        public IActionResult GetFormData(int id)
        {
            CityViewModel model = new CityViewModel
            {
                Id = id,
                Name = "Crop"
            };
            return Json(model);
        }
    }
}