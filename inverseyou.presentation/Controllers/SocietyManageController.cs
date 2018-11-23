using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace inverseyou.presentation.Controllers
{
    public class SocietyManageController : Controller
    {
        [HttpGet]
        public IActionResult CreateNewPost()
        {
            return View();
        }
    }
}