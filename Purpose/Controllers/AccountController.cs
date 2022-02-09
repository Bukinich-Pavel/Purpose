using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Purpose.Models;
using Purpose.ViewModels;
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
        public async Task<StatusCodeResult> Register(RegisterViewModel model)
        {
            //if (ModelState.IsValid)
            //{
            //    var userName = model.Email.Substring(model.Email.IndexOf('@'));
            //    User user = new User {  Email = model.Email, 
            //                            UserName = userName,
            //                            FirstName = model.FirstName,
            //                            SecondName = model.SecondName,
            //                            Year = model.Year
            //    };

            //    IdentityResult result = await userManager.CreateAsync(user, model.Password);  // добавляем пользователя
            //    if (result.Succeeded)
            //    {
            //        await signInManager.SignInAsync(user, false);  // установка куки
            //        return new OkResult();
            //    }
            //}
            return new BadRequestResult();
        }
    }
}
