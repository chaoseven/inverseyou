using Microsoft.AspNetCore.Mvc;
using inverseyou.presentation.Services;
using System;

namespace inverseyou.presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly AuthService _authService;
        public HomeController(AuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
