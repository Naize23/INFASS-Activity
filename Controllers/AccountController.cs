using INFASS_Activity.Models;
using Microsoft.AspNetCore.Mvc;

namespace INFASS_Activity.Controllers
{
    public class AccountController : Controller
    {

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string username, string fullname,string email,string password)
        {
            User user = new User()
            {
                username = username,
                fullname = fullname,
                email = email,
                password = password

            };

            string[] fields =
            {
                "Username","Fullname","Email","Password"
            };

            string[] values =
            {
                user.username, user.fullname,user.email,user.password
            };

            string sql = user.Display(fields, values, "User");
        
            return Content(sql);
        }

        [HttpPost]
        public IActionResult SelectAll(string tablename)
        {
            User user = new User();
            string sql = user.SelectAll(tablename);
            return Content(sql);
        }

        [HttpPost]
        public IActionResult Delete(string tablename, string condition)
        {
            User user = new User();
            condition = "UserID = 1;";

            string sql = user.Delete(tablename, condition);
            return Content(sql);
        }

        //[HttpPost]
        //public IActionResult Update(string)
        //{

        //}
    }

}
