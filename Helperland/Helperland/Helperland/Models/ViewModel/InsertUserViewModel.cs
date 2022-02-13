using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Models.ViewModel
{
    public class InsertUserViewModel
    {
        [Required(ErrorMessage = "Please Enter The FirstName")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please Enter The LastName")]
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage = "Please Enter Valid Email")] public string Email { get; set; }

        [Required(ErrorMessage = "You must provide a phone number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Please Enter The Password")]
        public string Password { get; set; }
    }
}
