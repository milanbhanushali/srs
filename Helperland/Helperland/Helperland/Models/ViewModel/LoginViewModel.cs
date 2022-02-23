using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Models.ViewModel
{
    public class LoginViewModel
    {
        public int UserID { get; set; }

        [EmailAddress (ErrorMessage = "Please Enter Valid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter The Password")]
        public string Password { get; set; }

        public string FirstName { get; set; }
    }
}
