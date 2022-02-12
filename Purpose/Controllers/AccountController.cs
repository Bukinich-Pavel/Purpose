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
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
                if (result.Succeeded)
                {
                    var user = await userManager.FindByEmailAsync(model.Email);
                    Response.StatusCode = 200;
                    return Json(new UserFrontViewModel(user));
                }
            }
            Response.StatusCode = 401;
            return null;
        }


        [HttpPost]
        public async Task<StatusCodeResult> Logout()
        {
            await signInManager.SignOutAsync();  // удаляем аутентификационные куки
            return new OkResult();
        }


        [HttpPost]
        public async Task<JsonResult> Register([FromBody] RegisterViewModel model)
        {
            
            if (ModelState.IsValid)
            {
                var nickName = model.Email.Substring(0, model.Email.IndexOf('@') + 1);

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

                IdentityResult result = await userManager.CreateAsync(user, model.Password);  // добавляем пользователя
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);  // установка куки
                    Response.StatusCode = 200;

                    var userFront = new UserFrontViewModel(user);
                    return Json(new ResponseViewModel(userFront));
                }
                Response.StatusCode = 401;

                // Create Error from DB
                var errorFromDB = new ModelStateViewModel("Error login", "This email already exists or the password is incorrect");
                return Json(new ResponseViewModel(errorFromDB));
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
            return Json(new ResponseViewModel(modelStateViewModel));

        }
    }
}
