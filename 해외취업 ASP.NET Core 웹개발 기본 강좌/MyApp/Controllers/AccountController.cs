using Microsoft.AspNetCore.Mvc;
using MyApp.ViewModels;

namespace MyApp.Models
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {

            return View();
        }

        public IActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, NickName = model.NickName };

            }

            return View();
        }
    }
}
