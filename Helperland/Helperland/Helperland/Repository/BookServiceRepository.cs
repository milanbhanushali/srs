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

        public int intServiceRequestID;

        public int serviceID = 0;
        Random random = new Random();
        public BookServiceRepository(HelperlandsContext helperlandsContext)
        {
            _helperlandsContext = helperlandsContext;
        }

        #region Message
        public string Message()
        {
            throw new NotImplementedException();
        }
        #endregion Message

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
                    address.PostalCode = item.PostalCode;
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
        #endregion Method - GetAddress

        #region Method - GetAllCity
        public List<City> GetAllCity()
        {
            return _helperlandsContext.City.ToList();
        }
        #endregion Method - GetAllCity

        #region Method - SetAddress
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
        #endregion Method - SetAddress

        #region Method - AddService
        public int AddService(BookServiceViewModel bookServiceViewModel)
        {
            try
            {
                ServiceRequest serviceRequest = new ServiceRequest();
                serviceRequest.UserId = bookServiceViewModel.UserId;
                serviceRequest.ServiceStartDate = bookServiceViewModel.ServiceStartDate;
                serviceRequest.ZipCode = bookServiceViewModel.ZipCode;
                serviceRequest.Comments = bookServiceViewModel.Comments;
                serviceRequest.TotalCost = bookServiceViewModel.TotalCost;
                serviceRequest.SubTotal = bookServiceViewModel.SubTotal;
                serviceRequest.HasPets = bookServiceViewModel.HasPets;
                serviceRequest.PaymentDone = true;
                serviceRequest.ServiceId = random.Next(11,200);
                serviceRequest.CreatedDate = DateTime.Now;
                serviceRequest.ServiceHourlyRate = 18;
                double extra = 0;
                if (bookServiceViewModel.InsideCabinet == true)
                {
                    extra += 0.5;
                }
                if (bookServiceViewModel.InsideFridge == true)
                {
                    extra += 0.5;
                }
                if (bookServiceViewModel.InteriorOven == true)
                {
                    extra += 0.5;
                }
                if (bookServiceViewModel.InteriorWindows == true)
                {
                    extra += 0.5;
                }
                if (bookServiceViewModel.LaundryWashDry == true)
                {
                    extra += 0.5;
                }
                serviceRequest.ExtraHours = extra;
                _helperlandsContext.ServiceRequest.Add(serviceRequest);
                _helperlandsContext.SaveChanges();

                UserAddress userAddress = _helperlandsContext.UserAddress.Where(x => x.AddressId == bookServiceViewModel.AddressId).FirstOrDefault();
                ServiceRequestAddress serviceRequestAddress = new ServiceRequestAddress();
                serviceRequestAddress.ServiceRequestId = serviceRequest.ServiceRequestId;
                serviceRequestAddress.AddressLine1 = userAddress.AddressLine1;
                serviceRequestAddress.AddressLine2 = userAddress.AddressLine2;
                serviceRequestAddress.CityId = userAddress.CityId;
                serviceRequestAddress.StateId = userAddress.StateId;
                serviceRequestAddress.PostalCode = userAddress.PostalCode;
                serviceRequestAddress.Mobile = userAddress.Mobile;
                serviceRequestAddress.Email = userAddress.Email;
                _helperlandsContext.ServiceRequestAddress.Add(serviceRequestAddress);
                _helperlandsContext.SaveChanges();

                if (bookServiceViewModel.InsideCabinet == true)
                {
                    ServiceRequestExtra serviceRequestExtra = new ServiceRequestExtra();
                    serviceRequestExtra.ServiceRequestId = serviceRequest.ServiceRequestId;
                    serviceRequestExtra.ServiceExtraId = 1;
                    _helperlandsContext.ServiceRequestExtra.Add(serviceRequestExtra);
                    _helperlandsContext.SaveChanges();

                }
                if (bookServiceViewModel.InsideFridge == true)
                {
                    ServiceRequestExtra serviceRequestExtra = new ServiceRequestExtra();
                    serviceRequestExtra.ServiceRequestId = serviceRequest.ServiceRequestId;
                    serviceRequestExtra.ServiceExtraId = 2;
                    _helperlandsContext.ServiceRequestExtra.Add(serviceRequestExtra);
                    _helperlandsContext.SaveChanges();
                }
                if (bookServiceViewModel.InteriorOven == true)
                {
                    ServiceRequestExtra serviceRequestExtra = new ServiceRequestExtra();
                    serviceRequestExtra.ServiceRequestId = serviceRequest.ServiceRequestId;
                    serviceRequestExtra.ServiceExtraId = 3;
                    _helperlandsContext.ServiceRequestExtra.Add(serviceRequestExtra);
                    _helperlandsContext.SaveChanges();
                }
                if (bookServiceViewModel.InteriorWindows == true)
                {
                    ServiceRequestExtra serviceRequestExtra = new ServiceRequestExtra();
                    serviceRequestExtra.ServiceRequestId = serviceRequest.ServiceRequestId;
                    serviceRequestExtra.ServiceExtraId = 4;
                    _helperlandsContext.ServiceRequestExtra.Add(serviceRequestExtra);
                    _helperlandsContext.SaveChanges();
                }
                if (bookServiceViewModel.LaundryWashDry == true)
                {
                    ServiceRequestExtra serviceRequestExtra = new ServiceRequestExtra();
                    serviceRequestExtra.ServiceRequestId = serviceRequest.ServiceRequestId;
                    serviceRequestExtra.ServiceExtraId = 5;
                    _helperlandsContext.ServiceRequestExtra.Add(serviceRequestExtra);
                    _helperlandsContext.SaveChanges();
                }

                return serviceRequest.ServiceId;
            }
            catch(Exception ex)
            {
                _Message = ex.Message.ToString();
                return -1;
            }
        }
        #endregion Method - AddService




    }
}
