using Microsoft.AspNetCore.Mvc;

namespace AsyncSample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
