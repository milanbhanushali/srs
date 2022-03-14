using Helperland.Data;
using Helperland.Models;
using Helperland.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Repository
{
    public class UserAddressRepository : IUserAddressRepository
    {
        #region variables
        private readonly HelperlandsContext helperlandsContext = null;
        public string ExceptionMessage;
        #endregion variables

        #region Constructor
        public UserAddressRepository(HelperlandsContext context)
        {
            helperlandsContext = context;
        }
        #endregion Constructor

        #region Add New Address
        public Boolean AddNewAddress(UserAddress userAddress)
        {
            City city = helperlandsContext.City.Where(x => x.Id == userAddress.CityId).FirstOrDefault();

            UserAddress objUserAddress = new UserAddress();
            userAddress.AddressLine1 = userAddress.AddressLine1;
            userAddress.AddressLine2 = userAddress.AddressLine2;
            userAddress.CityId = city.Id;
            userAddress.StateId = city.StateId;
            userAddress.PostalCode = userAddress.PostalCode;
            userAddress.UserId = (int)userAddress.UserId;
            userAddress.Mobile = userAddress.Mobile;
            try
            {
                helperlandsContext.UserAddress.Add(userAddress);
                helperlandsContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                string r = ex.Message;
                r += ex.InnerException.Message;
                return false;
            }
        }
        #endregion Add New Address

        #region Ger Address by userID
        public string GetUserAddress(int userID)
        {
            var userAdd = from address in helperlandsContext.UserAddress where address.UserId == userID select address;
            return userAdd.ToString();
        }
        #endregion Ger Address by userID

        #region Get Address By ID
        public UserAddressModel GetAddressById(int AddressID)
        {
            try
            {
                UserAddress userAddress = helperlandsContext.UserAddress.Where(x => x.AddressId == AddressID).FirstOrDefault();

                UserAddressModel address = new UserAddressModel();
                address.CityId = userAddress.CityId;
                address.PostalCode = userAddress.PostalCode;
                address.Mobile = userAddress.Mobile;
                address.AddressId = userAddress.AddressId;
                address.AddressLine1 = userAddress.AddressLine1;
                address.AddressLine2 = userAddress.AddressLine2;

                return address;
            }
            catch (Exception ex)
            {
                string r = ex.Message;
                r += ex.InnerException.Message;
                return null;
            }
        }
        #endregion

        #region Update Address
        public Boolean UpdateAddress(UserAddress userAddress)
        {
            City city = helperlandsContext.City.Where(x => x.Id == userAddress.CityId).FirstOrDefault();

            UserAddress objUserAddress = new UserAddress
            {
                AddressId = (int)userAddress.AddressId,
                UserId = (int)userAddress.UserId,
                AddressLine1 = userAddress.AddressLine1,
                AddressLine2 = userAddress.AddressLine2,
                CityId = city.Id,
                StateId = city.StateId,
                Mobile = userAddress.Mobile,
                PostalCode = userAddress.PostalCode

            };
            try
            {
                helperlandsContext.UserAddress.Update(objUserAddress);
                helperlandsContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                string r = ex.Message;
                r += ex.InnerException.Message;
                return false;
            }
        }
        #endregion Update Address

        #region Delete Address
        public Boolean DeleteAddress(int addressId)
        {
            UserAddress userAddress = helperlandsContext.UserAddress.Where(x => x.AddressId == addressId).FirstOrDefault();
            try
            {
                helperlandsContext.UserAddress.Remove(userAddress);
                helperlandsContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                string r = ex.Message;
                r += ex.InnerException.Message;
                return false;
            }
        }
        #endregion

        public int GetUserID()
        {
            throw new NotImplementedException();
        }

        public string Message()
        {
            throw new NotImplementedException();
        }
    }
}
