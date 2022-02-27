using Microsoft.AspNetCore.Mvc;

namespace AsyncSample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult AjaxTest()
        {
            Random random = new();
            int delayTime = random.Next(1000, 10000);

            Thread.Sleep(delayTime);

            return Json(new { message= "message", delayTime= delayTime });
        }
    }
}
