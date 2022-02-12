using Microsoft.AspNetCore.Mvc;
using Purpose.Models;
using Purpose.Cloud;
using System;
using Microsoft.AspNetCore.Authorization;

namespace Purpose.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext db;
        public HomeController(ApplicationContext db)
        {
            this.db = db;
        }

        [HttpGet]
        //[Authorize]
        public IActionResult Index()
        {
            foreach (var item in User.Identities)
            {
                item.
            }
            if (User.Identity.IsAuthenticated)
            {
                return Content(User.Identity.Name);
            }
            return Content("хуй");
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
