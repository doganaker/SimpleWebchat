using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebchat.Web.Models.VM
{
    public class UserAddVM
    {
        [Required(ErrorMessage = "Alanı boş geçemezsiniz!")]
        [Display(Name = "Ad")]
        public string name { get; set; }

        [Required(ErrorMessage = "Alanı boş geçemezsiniz!")]
        [Display(Name = "Soyad")]
        public string surname { get; set; }

        [Required(ErrorMessage = "Alanı boş geçemezsiniz!")]
        [Display(Name = "EMail")]
        public string email { get; set; }

        [Required(ErrorMessage = "Alanı boş geçemezsiniz!")]
        [Display(Name = "Şifre")]
        public string password { get; set; }

        [Required(ErrorMessage = "Alanı boş geçemezsiniz!")]
        [Display(Name = "Şifre Tekrar")]
        [Compare("password",ErrorMessage = "Lütfen aynı şifreyi giriniz!")]
        public string confirmpassword { get; set; }

        [Display(Name = "Rol")]
        public bool isadmin { get; set; }
    }
}
