using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Models.ViewModel
{
    public class ServiceUserRegistrationModel
    {
        #region UserID
        public int UserID { get; set; }
        #endregion UserID

        #region FirstName
        [Required(ErrorMessage = "Please Enter The FirstName")]
        public string FirstName { get; set; }
        #endregion FirstName

        #region LastName
        [Required(ErrorMessage = "Please Enter The LastName")]
        public string LastName { get; set; }
        #endregion LastName

        #region Email
        [EmailAddress(ErrorMessage = "Please Enter Valid Email")]
        public string Email { get; set; }
        #endregion Email

        #region PhoneNumber
        [Required(ErrorMessage = "You must provide a phone number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }
        #endregion PhoneNumber

        #region Password
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        #endregion Password

        #region ConfirmPassword
        [Required(ErrorMessage = "Confirmation Password is required.")]
        [Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
        public string ConfirmPassword { get; set; }
        #endregion ConfirmPassword
    }
}
