using Helperland.Models;
using Helperland.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Repository
{
    public interface IUserAddressRepository
    {
        public string Message();

        public int GetUserID();

        public string GetUserAddress(int userAddress);

        public Boolean AddNewAddress(UserAddress userAddress);

        public UserAddressModel GetAddressById(int AddressID);
        public Boolean UpdateAddress(UserAddress userAddress);
        public Boolean DeleteAddress(int addressId);

        public UserAddress GetServiceProviderAddress(int userId);
    }
}
