using Microsoft.AspNetCore.Mvc;

namespace MyApp.Models
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
