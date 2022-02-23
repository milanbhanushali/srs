using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Helperland.Models;
using Helperland.Models.ViewModel;

namespace Helperland.Repository
{
    public interface IBookServiceRepository
    {
        public string Message();

        public Boolean IsPincodeAvailable(string strZipcode);

        public List<UserAddressModel> GetAddress(int userID);
        public List<City> GetAllCity();
        public Boolean SetAddress(UserAddressModel userAddressModel);

    }
}
