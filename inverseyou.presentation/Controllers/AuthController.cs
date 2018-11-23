using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using inverseyou.presentation.Models;
using inverseyou.presentation.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace inverseyou.presentation.Controllers
{
    public class AuthController : Controller
    {
        private readonly AuthService _authService;
        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Register([FromBody]RegisterUser user)
        {
            if(ModelState.IsValid)
            {
                _authService.RegisterNewUser(user, out Exception ex);
                if (ex == null)
                {
                    return new JsonResult(new AjaxReponseResult(ResponseState.Sucess, null, null));
                }
                else
                {
                    return new JsonResult(new AjaxReponseResult(ResponseState.Fail, null, "注册失败"));
                }
            }
            else
            {
                return new JsonResult(new AjaxReponseResult(ResponseState.Fail,null, "注册信息不符合要求"));
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> Login([FromBody] LoginUser user)
        {
            if(ModelState.IsValid)
            {
                var loginUser = _authService.LoginUser(user, out Exception ex);

                if (ex == null && loginUser!=null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name,loginUser.Name),
                        new Claim(ClaimTypes.Email,loginUser.Email)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrinciple = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrinciple, new AuthenticationProperties { IsPersistent = true });

                    return new JsonResult(new AjaxReponseResult(ResponseState.Sucess, loginUser, null));
                }
                else
                {
                    return new JsonResult(new AjaxReponseResult(ResponseState.Fail, null, "用户名或密码错误"));
                }
            }
            else
            {
                return new JsonResult(new AjaxReponseResult(ResponseState.Fail, null, "用户名或密码不符合要求"));
            }
        }

        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Auth");
        }
    }
}