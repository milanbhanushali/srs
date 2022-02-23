using Helperland.Models;
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

        public int AddNewAddress(UserAddressRepository userAddress);

    }
}
