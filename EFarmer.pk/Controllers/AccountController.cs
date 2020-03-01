using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFarmer.pk.ViewModels.AccountViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EFarmer.pk.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterAccountViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Terms()
        {
            return View();
        }
    }
}