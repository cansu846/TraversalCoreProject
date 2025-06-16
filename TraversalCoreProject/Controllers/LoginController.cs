using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TraversalCoreProject.Models;

namespace TraversalCoreProject.Controllers
{
    //Controller atltındaki nesneleri yetkilerden muaf tutar.
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(UserSignInViewModel p)
        {
            if (!ModelState.IsValid)
            {
                return View(p); // client-side validation hataları varsa burada döner
            }

            var result = await _signInManager.PasswordSignInAsync(p.UserName, p.Password, false, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Profile", new { area = "Member" });
            }

            // Login işlemi başarılı olmaz ise hata ekler
            ModelState.AddModelError(string.Empty, "Username or password wrong. Please try again...");
            return View(p); // View tekrar dönülür, hata mesajı burada görünür
            //Hata mesajları kaybolur cunku yeni bir sayfaya istek yapılır
            //return RedirectToAction("Index", "Destination");
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return View(user); // FluentValidation kuralları devreye girer
            }

            AppUser appUser = new AppUser
            {
                Name = user.Name,
                Surname = user.Surname,
                Email = user.EMail,
                UserName = user.UserName
            };

            var result = await _userManager.CreateAsync(appUser, user.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Default");
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }

            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("SignIn");
        }
    }
}
