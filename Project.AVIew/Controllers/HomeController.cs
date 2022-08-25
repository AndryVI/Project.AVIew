using Microsoft.AspNetCore.Mvc;

namespace Project.AVIew.Controllers
{

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Archive()
        {
            return View();
        }

    }
}