using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TestProj.Models;

namespace TestProj.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterModel registration)
        {
            return Content("Hej " + registration.Username);
            //if (!ModelState.IsValid)
            //    return View("Index", registration);

            //var newUser = new IdentityUser()
            //{
            //    Email = registration.EmailAddress,
            //    UserName = registration.Username
            //};

            //var result = await _userManager.CreateAsync(newUser, registration.Password);

            //if (!result.Succeeded)
            //{
            //    foreach (var error in result.Errors.Select(x => x.Description))
            //    {
            //        ModelState.AddModelError("", error);
            //    }

            //    return View();
            //}
            //return RedirectToAction("Index");
        }
    }
}
