using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Models.ViewModel
{
    public class InsertUserViewModel
    {
        #region FirstName
        [Required(ErrorMessage = "Please Enter The FirstName")]
        public string FirstName { get; set; }
        #endregion FirstName

        #region LastName
        [Required(ErrorMessage = "Please Enter The LastName")]
        public string LastName { get; set; }
        #endregion LastName

        #region Email
        [EmailAddress(ErrorMessage = "Please Enter Valid Email")] public string Email { get; set; }
        #endregion Email

        #region Mobile
        [Required(ErrorMessage = "You must provide a phone number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string Mobile { get; set; }
        #endregion Mobile

        #region Password
        [Required(ErrorMessage = "Please Enter The Password")]
        public string Password { get; set; }
        #endregion Password
    }
}
