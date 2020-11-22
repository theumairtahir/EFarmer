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
    public class UsersController : Controller
    {
        private const string emptyString = "";
        public IActionResult Index(string successMessage = emptyString, string errorMessage = emptyString, string warningMessage = emptyString, string infoMessage = emptyString)
        {
            //ViewBag.Create = pk.Common.CommonValues.CREATE_CAPTION;
            ViewBag.BreadCrumb = Common.Functions.CreateBreadCrumb(new Models.Shared.BreadCrumb
            {
                Link = Url.Action("Index", "Dashboard"),
                Name = "Admin"
            },
            new Models.Shared.BreadCrumb
            {
                IsActive = true,
                IsLast = true,
                Name = "Users"
            });
            ViewBag.Info = infoMessage;
            ViewBag.Success = successMessage;
            ViewBag.Error = errorMessage;
            ViewBag.Warning = warningMessage;
            return View();
        }
        [HttpPost]
        public IActionResult GetDtUsers([FromBody] JqueryDataTablesParameters dataTableParams)
        {
            List<UserListingModel> data = new List<UserListingModel>();
            data.Add(new UserListingModel
            {
                Address = "123 abc, xyz",
                City = "Sialkot",
                Name = "Mushtaq Ahmad",
                Phone = "0300-1234567"
            });
            data.Add(new UserListingModel
            {
                Address = "123 abc, xyz",
                City = "Vehari",
                Name = "Saeed Ajmal",
                Phone = "0300-1234567"
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
                        case 2:
                            data = data.OrderBy(x => x.Name).ToList();
                            break;
                        case 3:
                            data = data.OrderBy(x => x.City).ToList();
                            break;
                        case 4:
                            data = data.OrderBy(x => x.Phone).ToList();
                            break;
                        case 5:
                            data = data.OrderBy(x => x.Address).ToList();
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
                            data = data.OrderByDescending(x => x.City).ToList();
                            break;
                        case 4:
                            data = data.OrderByDescending(x => x.Phone).ToList();
                            break;
                        case 5:
                            data = data.OrderByDescending(x => x.Address).ToList();
                            break;
                    }
                }
            }
            data.ForEach(x => x.ActionButtons = RenderedActionButtons.GetActionButtonsWithBlockIcon(insightsCallback: $"UserInsights({x.Id})", blockCallback: $"BlockUser({x.Id})"));
            var searchedResult = data.Where(x => x.Name.ToLower()
                                                .Contains(dataTableParams.Search.Value.ToLower())
                                                || x.City.ToLower()
                                                             .Contains(dataTableParams.Search.Value.ToLower())
                                                             || x.Phone.ToLower()
                                                                                .Contains(dataTableParams.Search
                                                                                .Value.ToLower()));
            var result = searchedResult.Skip(dataTableParams.Start)
                                       .Take(dataTableParams.Length)
                                       .ToDataTable(dataTableParams.Draw, data.Count, searchedResult.Count());

            return Json(result);
        }
        [HttpPost]
        public IActionResult BlockUser(int id)
        {
            return Json("The User has been blocked.");
        }
    }
}
