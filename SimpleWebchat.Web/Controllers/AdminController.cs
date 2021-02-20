using Microsoft.AspNetCore.Mvc;
using SimpleWebchat.BLL.Interfaces;
using SimpleWebchat.DAL.Models.Entities;
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
    }
}
