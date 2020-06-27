using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFarmer.pk.ViewModels.AccountViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EFarmer.pk.Controllers
{
    /// <summary>
    /// Manages User Accounts
    /// </summary>
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginAccountViewModel model)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ForgetAccount(LoginAccountViewModel model)
        {
            return View();
        }
        public IActionResult Terms()
        {
            return View();
        }
    }
}