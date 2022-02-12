using Microsoft.AspNetCore.Mvc;
using Purpose.Models;
using Purpose.Cloud;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Purpose.ViewModels;

namespace Purpose.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext db;
        private readonly UserManager<User> userManager;      // use for add user

        public HomeController(ApplicationContext db, UserManager<User> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }

        [HttpGet]
        //[Authorize]
        public async Task<JsonResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = await userManager.FindByEmailAsync(User.Identity.Name);
                Response.StatusCode = 200;
                var userFront = new UserFrontViewModel(user);  //Create "User for Frontend" from "User from DB"
                return Json(new ResponseViewModel(userFront)); //Send User
            }
            return Json(new ResponseViewModel(false)); //Send status:false
        }

        [HttpPost]
        public string Photo([FromBody] DataURI dataURI)
        {
            UploudCloud cloud = new UploudCloud();
            var str = cloud.Upload(dataURI.ImageDataURI);
            return str;
        }
    }
}
