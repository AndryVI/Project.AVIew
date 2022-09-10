using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Project.AVIew.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Project.AVIew.Logic;
using System;
using Project.AVIew.EF.Repositories;

namespace Project.AVIew.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;
        public AccountController(ILogger<HomeController> logger, IUserRepository userRepository)
        {
            logger.LogInformation("This AccountController");
            _userRepository = userRepository;
        }

        public IActionResult Denied() => View();


        //[Authorize(Roles = "User,Admin")]

        #region Sign-Out

        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        #endregion


        #region Sign-In

        public IActionResult SignIn()
        {
            return View();
        }

        public IActionResult SignInAccess()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> SignIn(LoginBindingModel model)
        {
            if (ModelState.IsValid)
            {
                var userOrNull = _userRepository.GetUser(model.Login);

                if (userOrNull.Result != null)
                {
                    var isCorrectPassword = PasswordHasher.IsCorrectPassword(userOrNull.Result.PasswordHashed, model.Password);
                    if (isCorrectPassword)
                    {
                        await SignInAsync(model);
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError("", "Wrong login or password");
                return View(model);
            }
            else
            { 
                return View(model);
            }
        }

        private async Task SignInAsync(LoginBindingModel user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Login),
                new Claim(ClaimTypes.Role, user.Login  == "Admin"? "Admin" : "User"),
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await HttpContext.SignInAsync(claimsPrincipal);
        }

        #endregion


        #region Register

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterBindingModel model)
        {
            if (ModelState.IsValid)
            {
                var userAlreadyExists = _userRepository.GetUser(model.Login);
                if (userAlreadyExists.Result != null)
                {
                    ModelState.AddModelError(nameof(model.Login), "Login is already in use");
                    return View(model);
                }

                _userRepository.AddUser(model.Login, PasswordHasher.HashPassword(model.Password));

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(model);
            }
        }

        #endregion

    }
}
