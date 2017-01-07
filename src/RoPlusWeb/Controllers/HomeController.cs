using Microsoft.AspNetCore.Mvc;

namespace RoPlusAngularWeb.Controllers {
  public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
