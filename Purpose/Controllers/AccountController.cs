using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Purpose.Models;
using Purpose.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Purpose.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;      // use for add user
        private readonly SignInManager<User> signInManager;  // use for login

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


        [HttpPost]
        public async Task<JsonResult> Login([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid) // Valid Ok
            {
                // Searche user and password chek
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
                if (result.Succeeded) // is Ok
                {
                    // Searche user in DB
                    var user = await userManager.FindByEmailAsync(model.Email);
                    Response.StatusCode = 200;
                    var userFront = new UserFrontViewModel(user);  //Create "User for Frontend" from "User from DB"
                    return Json(new ResponseViewModel(userFront)); //Send User
                }
            }
            #region Create ogj ModelStateVM for send to Front and add errors
            List<ModelStateViewModel> modelStateViewModel = new List<ModelStateViewModel>();
            foreach (var item in ModelState)
            {
                ModelStateViewModel ms = new ModelStateViewModel(item.Key, item.Value.Errors[0].ErrorMessage);
                modelStateViewModel.Add(ms);
            }
            #endregion

            Response.StatusCode = 401;
            return Json(new ResponseViewModel(modelStateViewModel)); //Send errors
        }


        [HttpPost]
        public async Task<StatusCodeResult> Logout()
        {
            await signInManager.SignOutAsync();  // Delete cookie
            return new OkResult();
        }


        [HttpPost]
        public async Task<JsonResult> Register([FromBody] RegisterViewModel model)
        {
            
            if (ModelState.IsValid)
            {
                //Create nickname from @mail -> {nickname}@gmail.com
                var nickName = model.Email.Substring(0, model.Email.IndexOf('@') + 1); 

                //Create User from form register
                User user = new User
                {
                    Email = model.Email,
                    UserName = model.Email,
                    FirstName = model.FirstName,
                    SecondName = model.SecondName,
                    Year = model.Year,
                    NickName = model.NickName == String.Empty ? nickName : model.NickName,
                    Photo = model.Photo
                };

                // Add User in DB
                IdentityResult result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded) //is Ok
                {
                    await signInManager.SignInAsync(user, false);  // add cookie
                    Response.StatusCode = 200;

                    var userFront = new UserFrontViewModel(user); //Create "User for Frontend" from "User from DB"
                    return Json(new ResponseViewModel(userFront)); //Send User
                }

                Response.StatusCode = 401;
                // Create Error from DB
                var errorFromDB = new ModelStateViewModel("Error login", "This email already exists or the password is incorrect");
                return Json(new ResponseViewModel(errorFromDB)); //Send error
            }

            #region Create ogj ModelStateVM for send to Front and add errors
            List<ModelStateViewModel> modelStateViewModel = new List<ModelStateViewModel>();
            foreach (var item in ModelState)
            {
                ModelStateViewModel ms = new ModelStateViewModel(item.Key, item.Value.Errors[0].ErrorMessage);
                modelStateViewModel.Add(ms);
            }
            #endregion

            Response.StatusCode = 401;
            return Json(new ResponseViewModel(modelStateViewModel)); //Send errors

        }
    }
}
