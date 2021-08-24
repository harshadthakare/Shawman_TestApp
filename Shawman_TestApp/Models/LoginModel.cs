using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shawman_TestApp.Models
{
    public class LoginModel
    {
        

        [Required(ErrorMessage = "User Name is Required")]

        public string UserName { get; set; }



        [Required(ErrorMessage = "Password is Required")]

        public string Password { get; set; }

    }
}
