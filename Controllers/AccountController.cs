using INFASS_Activity.Models;
using Microsoft.AspNetCore.Mvc;

namespace INFASS_Activity.Controllers
{
    public class AccountController : Controller
    {
        private static readonly List<User> Users = new()
        {
            new User
            {
                FullName = "Administrator",
                Username = "admin",
                Password = "admin123"
            }
        };

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            User? user = Users.FirstOrDefault(user =>
                user.Username.Equals(
                    model.Username,
                    StringComparison.OrdinalIgnoreCase
                ) &&
                user.Password == model.Password
            );

            if (user == null)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "Invalid username or password."
                );

                return View(model);
            }

            TempData["Message"] = $"Welcome, {user.FullName}!";

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (Users.Any(user =>
                user.Username.Equals(
                    model.Username,
                    StringComparison.OrdinalIgnoreCase
                )))
            {
                ModelState.AddModelError(
                    "Username",
                    "Username already exists."
                );
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Users.Add(new User
            {
                FullName = model.FullName,
                Username = model.Username,
                Password = model.Password
            });

            TempData["SuccessMessage"] =
                "Registration successful. You may now log in.";

            return RedirectToAction("Login");
        }
    }
}
