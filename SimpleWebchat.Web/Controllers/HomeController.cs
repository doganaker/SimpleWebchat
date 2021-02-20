using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleWebchat.BLL.Interfaces;
using SimpleWebchat.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebchat.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IAdminUser<AdminUser> _adminuserrepository;
        private IChat<Chat> _chatrepository;

        public HomeController(IAdminUser<AdminUser> adminuserrepository, IChat<Chat> chatrepository)
        {
            _adminuserrepository = adminuserrepository;
            _chatrepository = chatrepository;
        }

        public IActionResult Index()
        {
            ViewBag.id = Convert.ToInt32(HttpContext.User.Claims.ToArray()[2].Value);
            ViewBag.name = HttpContext.User.Claims.ToArray()[1].Value;
            ViewBag.isadmin = HttpContext.User.Claims.ToArray()[3].Value;

            var userList = _adminuserrepository.ListUsers();

            return View(userList);
        }

        public JsonResult User(int id)
        {
            var user = _adminuserrepository.Find(id);
            return Json(user);
        }

        [Route("GetChat/{callerId}/{clientId}")]
        public JsonResult GetChat(int callerId, int clientId)
        {
            List<Chat> chat = _chatrepository.GetChat(callerId,clientId);

            return Json(chat);
        }
    }
}
