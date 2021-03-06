﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alone_Revisal.Models;
using Alone_Revisal.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Alone_Revisal.Controllers
{   
    public class AccountController : Controller
    {
        private readonly UserManager<Utilizator> _userManager;
        private readonly SignInManager<Utilizator> _signInManager;


        public AccountController (UserManager<Utilizator> userManager, SignInManager<Utilizator> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel
            {
                ReturnUrl = returnUrl
            }
                );
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
                return View(loginViewModel);

            var user = await _userManager.FindByNameAsync(loginViewModel.UserName);

            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
                if (result.Succeeded)
                {
                    if (string.IsNullOrEmpty(loginViewModel.ReturnUrl))
                        return RedirectToAction("Index", "Home");

                    return Redirect(loginViewModel.ReturnUrl);
                }
            }

            ModelState.AddModelError("","Email/Password not found");
            return View(loginViewModel);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new Utilizator()
                {
                    UserName = registerViewModel.UserName,
                    CNP = registerViewModel.CNP
                };
                var result = await _userManager.CreateAsync(user, registerViewModel.Password);

                if (result.Succeeded)
                    return RedirectToAction("Index","Home");
            }
            return View("Login", registerViewModel);
        }


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

    }
}