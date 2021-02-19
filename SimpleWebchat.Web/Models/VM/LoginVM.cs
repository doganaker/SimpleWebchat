using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebchat.Web.Models.VM
{
    public class LoginVM
    {
        [Required(ErrorMessage = "E-Mail adresinizi girmeniz gerekiyor!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifrenizi girmeniz gerekiyor!")]
        public string Password { get; set; }
    }
}
