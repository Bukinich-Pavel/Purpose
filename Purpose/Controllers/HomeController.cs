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
        public OkResult Index()
        {
            return new OkResult();
        }
    }
}
