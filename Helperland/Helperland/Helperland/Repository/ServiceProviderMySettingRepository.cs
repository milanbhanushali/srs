using Helperland.Models;
using Helperland.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Repository
{
    public class ServiceProviderMySettingRepository : IServiceProviderMySettingRepository
    {
        private IInsertUserRepository _iInsertUserRepository;
        private IUserAddressRepository _iUserAddressRepository;
        public ServiceProviderMySettingRepository(IInsertUserRepository insertUserRepository, IUserAddressRepository userAddressRepository)
        {
            _iInsertUserRepository = insertUserRepository;
            _iUserAddressRepository = userAddressRepository;
        }
        public SPDetailsViewModel SPDetails(int userId)
        {
            SPDetailsViewModel model = new SPDetailsViewModel();
            User user;
            user = _iInsertUserRepository.GetUserById(userId);
            UserAddress userAddress = _iUserAddressRepository.GetServiceProviderAddress(userId);
            if (user != null)
            {
                model.FirstName = user.FirstName;
                model.lastName = user.LastName;
                model.month = Convert.ToDateTime(user.DateOfBirth).Month;
                model.day = Convert.ToDateTime(user.DateOfBirth).Day;
                model.year = Convert.ToDateTime(user.DateOfBirth).Year;
                model.mobileNumber = user.Mobile;
                model.email = user.Email;
                if (user.Gender != null)
                {
                    model.Gender = (int)user.Gender;
                }
                if (user.NationalityId != null)
                {
                    model.NationalityId = (int)user.NationalityId;
                }
                model.UserProfilePicture = user.UserProfilePicture;
                if (user.IsActive != false)
                    model.IsActive = (bool)user.IsActive;
                else
                    model.IsActive = false;
            }
            if (userAddress != null)
            {
                model.AddressLine1 = userAddress.AddressLine1;
                model.AddressLine2 = userAddress.AddressLine2;
                model.Zipcode = userAddress.PostalCode;
                model.CityId = userAddress.CityId;
            }
            return model;
        }
    }
}
