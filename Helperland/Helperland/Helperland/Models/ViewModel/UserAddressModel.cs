using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Models.ViewModel
{
    public class UserAddressModel
    {
        public int AddressId { get; set; }
        public int? UserId { get; set; }
        public int StateId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Mobile { get; set; }
        public int? CityId { get; set; }
        public string PostalCode { get; set; }
    }
}
