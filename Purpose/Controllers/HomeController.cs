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
        //public string Index()
        //{
        //    var users = db.Users;
        //    string str = String.Empty;


        //    foreach (var user in users)
        //    {
        //        if(user.Email == "bukinich06@gmail.com")
        //        {
        //            user.FirstName = "Павел";
        //            user.SecondName = "Букинич";
        //            user.Year = 23;
        //            str = "true";
        //        }
        //        else
        //        {
        //            str = "false";
        //        }

        //    }
        //    db.SaveChanges();

        //    return str;
        //}
    }
}
