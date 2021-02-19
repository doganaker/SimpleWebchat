using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SimpleWebchat.BLL.Interfaces;
using SimpleWebchat.DAL.Models.Entities;
using SimpleWebchat.Web.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SimpleWebchat.Web.Controllers
{
    public class LoginController : Controller
    {
        IAdminUser<AdminUser> _adminUser;

        public LoginController(IAdminUser<AdminUser> adminUser)
        {
            _adminUser = adminUser;
        }

        [Route("/girisyap")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var user = _adminUser.FirstOrDefault(q => q.EMail == model.Email && q.Password == model.Password);

                if (user != null)
                {
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, model.Email),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Sid, user.ID.ToString())
                };

                    var userIdentity = new ClaimsIdentity(claims, "login");

                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                    await HttpContext.SignInAsync(principal);

                    return Redirect("/Home/Index");
                }
                else
                {
                    ViewBag.error = "Üzgünüz, sizi bulamadık...";
                    return View();
                }
            }
            else
            {
                return View();
            }
            
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
