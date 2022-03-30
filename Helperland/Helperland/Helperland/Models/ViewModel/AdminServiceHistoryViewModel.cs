using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Models.ViewModel
{
    public class AdminServiceHistoryViewModel
    {
        public int ServiceRequestId { get; set; }
        public DateTime ServiceDate { get; set; }
        public DateTime ServiceStartDate { get; set; }
        public int CityId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddressLine1 { get; set; }
        public string CustomerAddressLine2 { get; set; }
        public string ServiceProviderName { get; set; }
        public int ServiceProviderId { get; set; }
        public int Rating { get; set; }
        public decimal NetAmount { get; set; }
        public int? Status { get; set; }
        public string Avatar { get; set; }
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
        public string Postalcode { get; set; }
        public string Message { get; set; }

    }
}
