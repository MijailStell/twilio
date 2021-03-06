using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        public SignInManager<ApplicationUser> signInManager;

        public HomeController(SignInManager<ApplicationUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous, HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous, HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        [Authorize, HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet("verification")]
        public IActionResult Verification()
        {
            return View();
        }

        [HttpGet("verified")]
        public IActionResult Verified()
        {
            return View();
        }

        [Authorize, HttpGet("2fa")]
        public IActionResult TwoFactorSample()
        {
            return View();
        }

        [Authorize, HttpGet("protected")]
        public IActionResult Protected()
        {
            return View();
        }

        [HttpGet("error")]
        public IActionResult Error()
        {
            return View();
        }
    }
}
