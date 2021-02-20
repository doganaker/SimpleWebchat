using Microsoft.AspNetCore.Mvc;
using SimpleWebchat.BLL.Interfaces;
using SimpleWebchat.DAL.Models.Entities;
using SimpleWebchat.Web.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebchat.Web.Controllers
{
    public class AdminController : Controller
    {
        private IAdminUser<AdminUser> _adminRepository;
        private IUnitOfWork _unitofwork;

        public AdminController(IAdminUser<AdminUser> adminRepository, IUnitOfWork unitofwork)
        {
            _adminRepository = adminRepository;
            _unitofwork = unitofwork;
        }
        public IActionResult List()
        {
            string email = HttpContext.User.Claims.ToArray()[0].Value;

            var userList = _adminRepository.FindAll(q => q.EMail != email);
            
            return View(userList);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(UserAddVM model)
        {
            if (ModelState.IsValid)
            {
                AdminUser user = new AdminUser();
                user.Name = model.name;
                user.Surname = model.surname;
                user.EMail = model.email;
                user.Password = model.password;
                user.IsAdmin = model.isadmin;
                user.OnlineStatus = false;

                _adminRepository.Add(user);
                _unitofwork.SaveChanges();

                return RedirectToAction("List", "Admin");
            }
            else
            {
                return View();
            }
        }
    }
}
