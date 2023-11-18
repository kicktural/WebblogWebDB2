
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebblogWebDB2.DTOs;
using WebblogWebDB2.Models;

namespace WebblogWebDB2.Controllers
{
    public class AuthController : Controller
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet] 
        public IActionResult Login()
        {
            return View();
        }
           
        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var CheckEmail = await _userManager.FindByEmailAsync(login.Email);

            if (CheckEmail == null)
            {
                ModelState.AddModelError("Email", "Error");
                return View();
            }

            Microsoft.AspNetCore.Identity.SignInResult result2 = await _signInManager.PasswordSignInAsync(CheckEmail, login.Password, login.Rememberme, false);

            if (!result2.Succeeded)
            {
                ModelState.AddModelError("Error", "Email!");
                return View();
            }
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult Regester()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Regester(Regester regester)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var checkEmail = await _userManager.FindByEmailAsync(regester.Email);

            if (checkEmail != null)
            {
                ModelState.AddModelError("Email", "Page");
            }

            User newuser = new()
            {
               FirstName = regester.FistName,
               LastName = regester.LastName,
               Email = regester.Email,
               UserName = regester.Email,
               PhotoUrl="/"
            };
            
            var result = await _userManager.CreateAsync(newuser, regester.Password);

            if (result.Succeeded)
            {
				await _signInManager.SignInAsync(newuser, isPersistent: true);
				return RedirectToAction(nameof(Login));
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("Error", error.Description);
                }
                return View(regester);
            }
        }
         
    }
}
