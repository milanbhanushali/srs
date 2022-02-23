using Helperland.Data;
using Helperland.Models;
using Helperland.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Repository
{
    public class BookServiceRepository : IBookServiceRepository
    {

        public HelperlandsContext _helperlandsContext;
        public string _Message { get; set; }
        public BookServiceRepository(HelperlandsContext helperlandsContext)
        {
            _helperlandsContext = helperlandsContext;
        }


        public string Message()
        {
            throw new NotImplementedException();
        }

        #region Method - IsPinCodeAvailable
        public bool IsPincodeAvailable(string strZipcode)
        {
            try
            {
                User objUser = _helperlandsContext.User.Where(x => x.ZipCode == strZipcode).FirstOrDefault();
                if (objUser != null)
                {
                    return true;
                }
                else
                {
                    _Message += " Invalid Zipcode";
                    return false;
                }
            }
            catch (Exception ex)
            {
                _Message += ex.Message;
                return false;
            }
        }
        #endregion Method - IsPinCodeAvailable

        #region Method - GetAddress
        public List<UserAddressModel> GetAddress(int userID)
        {
            try
            {
                List<UserAddressModel> addresses = new List<UserAddressModel>();
                List<UserAddress> userAddresses = _helperlandsContext.UserAddress.Where(x => x.UserId == userID).ToList();
                foreach(var item in userAddresses)
                {
                    UserAddressModel address = new UserAddressModel();
                    address.UserId = userID;
                    address.AddressId = item.AddressId;
                    address.AddressLine1 = item.AddressLine1;
                    address.AddressLine2 = item.AddressLine2;
                    address.Mobile = item.Mobile;
                    address.CityId = item.CityId;
                    addresses.Add(address);
                    
                }
                return addresses;
            }
            catch(Exception ex)
            {
                _Message = ex.Message.ToString();
                return null;
            }
        }

        public List<City> GetAllCity()
        {
            return _helperlandsContext.City.ToList();
        }

        public bool SetAddress(UserAddressModel userAddressModel)
        {
            City city = _helperlandsContext.City.Where(x => x.Id == userAddressModel.CityId).FirstOrDefault();

            UserAddress userAddress = new UserAddress();
            userAddress.AddressLine1 = userAddressModel.AddressLine1;
            userAddress.AddressLine2 = userAddressModel.AddressLine2;
            userAddress.CityId = city.Id;
            userAddress.StateId = city.StateId;
            userAddress.PostalCode = userAddressModel.PostalCode;
            userAddress.UserId = (int)userAddressModel.UserId;
            userAddress.Mobile = userAddressModel.Mobile;
            try
            {
                _helperlandsContext.UserAddress.Add(userAddress);
                _helperlandsContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                message += ex.InnerException.Message;
                return false;
            }
        }
        #endregion Method - GetAddress


    }
}
