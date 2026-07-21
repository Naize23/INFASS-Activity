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
        public IActionResult Register(User user)
        {
        
            return Content(user.Sql());
        }
    }

}
