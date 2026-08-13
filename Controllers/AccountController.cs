using INFASS_Activity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace INFASS_Activity.Controllers
{
   
    public class AccountController : Controller
    {
        private readonly string _connectionString;

        public AccountController(IConfiguration configuration)
        {
            _connectionString =
                configuration.GetConnectionString("DefaultConnection")!;
        }

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
        public IActionResult Register(User user)
        {
            string[] fields =
            {
                "Username","Fullname","Email","Password"
            };

            string[] values =
            {
                user.username, user.fullname,user.email,user.password
            };

            string sql = user.Display(fields, values, "User");
            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand cmd = new SqlCommand(sql, connection);
            connection.Open();
            cmd.ExecuteNonQuery();

            return Content("User registered successfully!");
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

        [HttpPost]
        public IActionResult Update(string tablename, string username, string fullname, string email, string password)
        {
            User user = new User();

            string[] fields =
            {
                "username","fullname","email","password"
            };

            string[] values =
            {
               username, fullname,email,password
            };

            string sql = user.Update(tablename, fields, values);
            return Content(sql);

        }
    }

}
