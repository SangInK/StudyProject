using Microsoft.AspNetCore.Mvc;

namespace MyApp.Models
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {

            return View();
        }

        public IActionResult Register()
        {

            return View();
        }
    }
}
