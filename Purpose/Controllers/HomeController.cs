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
            //var users = db.Users;
            //string str = String.Empty;
            //foreach (var item in users)
            //{
            //    str += item.Email + "\n";
            //}
            //return str;
            return new OkResult();
        }
    }
}
