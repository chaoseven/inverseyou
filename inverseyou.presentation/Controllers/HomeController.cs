using Microsoft.AspNetCore.Mvc;

namespace inverseyou.presentation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
