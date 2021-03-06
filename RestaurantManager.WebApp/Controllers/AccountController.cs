using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantManager.WebApp.Models;

namespace RestaurantManager.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }


        public IActionResult Register()
        {
            return View(new LoginVM());
        }

        // jest view register to musi byc tez post register #ez
        //Rejestracja POST​
        //Nie wymagająca podania ConfirmPassword 
        [HttpPost]
        public async Task<IActionResult> Register(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser() { UserName = loginVM.UserName };
                var result = await _userManager.CreateAsync(user, loginVM.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(loginVM);
        }

        //logout
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        //Logowanie z POST
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVM);
            }
            var user = await _userManager.FindByNameAsync(loginVM.UserName);

            if (user != null)
            {
                //logowanie
                var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("", "Invalid username or password");

            return View(loginVM);
        }



    }
}
