﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coraza_LabActivity1.Data;
using Coraza_LabActivity1.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Coraza_LabActivity1.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        // GET: /<controller>/
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Register(RegisterViewModel userEnteredData)
        {
            if(!ModelState.IsValid)
            {
                User newUser = new User();
                newUser.UserName = userEnteredData.UserName;
                newUser.Firstname = userEnteredData.FirstName;
                newUser.Lastname = userEnteredData.LastName;
                newUser.Email = userEnteredData.Email;
                newUser.PhoneNumber = userEnteredData.Phone;

                var result = await _userManager.CreateAsync(newUser, userEnteredData.Password);
           
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Instructor");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(userEnteredData);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginInfo)
        {
            var result = await _signInManager.PasswordSignInAsync(loginInfo.UserName,
                loginInfo.Password,loginInfo.RememberMe,false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Instructor");
            }
            else 
            {
                ModelState.AddModelError("", "Failed to Login");
            }
            return View(loginInfo);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Instructor");
        }
    }
}
