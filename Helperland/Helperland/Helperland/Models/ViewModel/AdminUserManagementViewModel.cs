using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Models.ViewModel
{
    public class AdminUserManagementViewModel
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public string UserType { get; set; }
        public string Phone { get; set; }
        public string PostalCode { get; set; }
        public int? Status { get; set; }
        public string Email { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
