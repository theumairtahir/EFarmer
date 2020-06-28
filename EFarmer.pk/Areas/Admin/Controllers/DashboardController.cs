using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}