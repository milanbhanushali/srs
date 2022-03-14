using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Helperland.Models.ViewModel
{
    public class UserAddressModel
    {
        [JsonPropertyName("addressID")]
        public int AddressId { get; set; }
        [JsonPropertyName("userId")]
        public int? UserId { get; set; }
        [JsonPropertyName("stateId")]
        public int StateId { get; set; }
        [JsonPropertyName("addressLine1")]
        public string AddressLine1 { get; set; }
        [JsonPropertyName("addressLine2")]
        public string AddressLine2 { get; set; }
        [JsonPropertyName("mobileNo")]
        public string Mobile { get; set; }
        [JsonPropertyName("cityId")]
        public int? CityId { get; set; }
        [JsonPropertyName("zipCode")]
        public string PostalCode { get; set; }
    }
}
