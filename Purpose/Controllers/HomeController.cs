using Microsoft.AspNetCore.Mvc;
using Purpose.Models;
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
                return $"Hello {name}!";
            }
            else
            {
                Response.Cookies.Append("name", "Tom");
                return "Hello World";
            }
        }
    }
}
