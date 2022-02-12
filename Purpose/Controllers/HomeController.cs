using Microsoft.AspNetCore.Mvc;
using Purpose.Models;
using Purpose.Cloud;
using System;

namespace Purpose.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext db;
        public HomeController(ApplicationContext db)
        {
            this.db = db;
        }
        public string Index()
        {
            if (Request.Cookies.ContainsKey("name"))
            {
                string name = Request.Cookies["name"];
                UploudCloud cloud = new UploudCloud();
                return "Hello World\n";
            }
            else
            {
                Response.Cookies.Append("name", "Tom");
                UploudCloud cloud = new UploudCloud();
                return "Hello World\n" ;
            }
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
