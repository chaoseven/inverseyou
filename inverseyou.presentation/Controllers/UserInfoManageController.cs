﻿using inverseyou.presentation.Models;
using Microsoft.AspNetCore.Mvc;

namespace inverseyou.presentation.Controllers
{
    public class UserInfoManageController : Controller
    {
        [HttpGet]
        public IActionResult UserInfoEdit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserInfoEdit([FromBody] RegisterUser user)
        {
            return null;
        }
    }
}