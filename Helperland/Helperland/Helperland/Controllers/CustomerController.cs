using Helperland.Models;
using Helperland.Models.ViewModel;
using Helperland.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Controllers
{
    public class CustomerController : Controller
    {
        #region Repository Variable
        private readonly ICustomerServiceRepository _icustomerServiceRepository;
        private readonly IRatingRepository _iRatingRepository;
        private readonly IBookServiceRepository _iBookServiceRepository;
        private readonly IUserAddressRepository _iUserAddressRepository;
        private readonly IInsertUserRepository _iInsertUserRepository;
        private readonly ILoginRepository _iLoginRepository;
        #endregion Repository Variable

        #region Constructor
        public CustomerController(ICustomerServiceRepository customerServiceRepository, IRatingRepository ratingRepository,IBookServiceRepository bookServiceRepository,IUserAddressRepository userAddressRepository, IInsertUserRepository insertUserRepository, ILoginRepository loginRepository)
        {
            _icustomerServiceRepository = customerServiceRepository;
            _iRatingRepository = ratingRepository;
            _iBookServiceRepository = bookServiceRepository;
            _iUserAddressRepository = userAddressRepository;
            _iInsertUserRepository = insertUserRepository;
            _iLoginRepository = loginRepository;
        }
        #endregion Constructor

        #region Index
        public IActionResult Index(bool isLogged = false)
        {
            ViewBag.IsLogged = isLogged;
            if (ViewBag.IsLogged)
            {
                int userID = Convert.ToInt32(HttpContext.Session.GetInt32("userID"));

                if(userID > 0)
                {
                    IEnumerable<CustomerServiceHistoryViewModel> serviceRequests = _icustomerServiceRepository.GetCustomerServiceHistory(userID);
                    return View(serviceRequests);
                }
                else
                {
                    return Json("UserId is null");
                }
            }
            else
            {
                return Json("User is not logged");
            }
        }
        #endregion Index

        #region Get Service History Data
        public IActionResult GetUserServiceHistoryData(int ServiceRequestId)
        {
            CustomerServiceHistoryViewModel objCustomerServiceHistory = _icustomerServiceRepository.GetServiceRequestID(ServiceRequestId);
            if(objCustomerServiceHistory != null)
            {
                return Json(objCustomerServiceHistory);
            }
            else
            {
                return Json("Service Request ID is null");
            }
        }
        #endregion Get Service History Data

        #region Get Service Date
        public string GetServiceDate(string strServiceRequestId)
        {
            return _icustomerServiceRepository.GetServiceDate(Int32.Parse(strServiceRequestId));
        }
        #endregion Get Service Date

        #region Service Updated Date
        public bool UpdateServiceDate(string serviceDate, string serviceId)
        {
            bool serviceUpdated = _icustomerServiceRepository.UpdateServiceDate(Int32.Parse(serviceId), Convert.ToDateTime(serviceDate));
            return serviceUpdated;
        }
        #endregion Service Updated Date

        #region Service Cancel
        public bool CancelService(string serviceId, string message)
        {
            if(serviceId != null && message != null)
            {
                bool serviceCancel = _icustomerServiceRepository.CancelService(Int32.Parse(serviceId), message);
                return serviceCancel;
            }
            else
            {
                return false;
            }
            
        }
        #endregion Service Cancel

        #region Customer Service History
        public IActionResult CustomerServiceHistory(bool isLogged = false)
        {
            ViewBag.IsLogged = isLogged;
            if (ViewBag.IsLogged)
            {
                int userID = Convert.ToInt32(HttpContext.Session.GetInt32("userID"));
                if (userID > 0)
                {
                    try
                    {
                        List<ServiceHistoryViewModel> serviceRequests = _icustomerServiceRepository.GetServicesHistoryByUserId(userID);
                        return View(serviceRequests);
                    }
                    catch (Exception ex)
                    {
                        string message = ex.Message;
                        return Json("Error because of " + message);
                    }
                }
                else
                {
                    return Json("UserId is less than 0");
                }
            }
            else
            {
                return Json("UserId is not logged !!");
            }
        }
        #endregion Customer Service History

        #region Get Service Data from Service ID
        public IActionResult GetServiceRequestData(string serviceID)
        {
            return Json(JsonConvert.SerializeObject(_icustomerServiceRepository.GetServiceDetails(Int32.Parse(serviceID))));
        }
        #endregion Get Service Data from Service ID

        #region Add Rating
        public bool AddRating(string ServiceRequestId, string onTime, string friendly, string qualityOfService, string feedBack)
        {
            return _iRatingRepository.AddRating(Int32.Parse(ServiceRequestId), decimal.Parse(onTime), decimal.Parse(friendly), decimal.Parse(qualityOfService), feedBack);
        }
        #endregion Add Rating

        #region My Setting
        public IActionResult MySetting(bool isLogged = false)
        {
            ViewBag.IsLogged = isLogged;
            if (ViewBag.IsLogged)
            {
                int userID = Convert.ToInt32(HttpContext.Session.GetInt32("userID"));
                if (userID > 0)
                {
                    ViewBag.city = _iBookServiceRepository.GetAllCity().Select(x => new SelectListItem()
                    {
                        Text = x.CityName,
                        Value = x.Id.ToString()
                    });
                    return View();
                }
                else
                {
                    return Json("UserId is null");
                }
            }
            else
            {
                return Json("User is not logged");
            }
            
        }
        #endregion My Setting

        public IActionResult GetAddress(string userID)
        {
            List<UserAddressModel> addresses = _iBookServiceRepository.GetAddress(Int32.Parse(userID));
            if (addresses == null)
            {
                Json(false);
            }
            return Json(JsonConvert.SerializeObject(addresses));
        }

        #region Get Address from AddressID
        public IActionResult GetAddressById(string AddressID)
        {
            UserAddressModel addresses = _iUserAddressRepository.GetAddressById(Int32.Parse(AddressID));
            if (addresses == null)
            {
                Json(false);
            }
            return Json(JsonConvert.SerializeObject(addresses));
        }
        #endregion Get Address from AddressID

        #region Update User Profile
        [HttpPost]
        public IActionResult UpdateUserData(string FirstName, string LastName, string DOB, string MobileNumber, string UserId, string LanguageId)
        {
            var objUserData = _iInsertUserRepository.ChangeUserData(FirstName, LastName, DOB, MobileNumber, Int32.Parse(UserId), Int32.Parse(LanguageId));
            return Json(objUserData);
        }
        #endregion Update User Profile

        #region Get User By Id
        public IActionResult GetUserById(string userId)
        {
            User user;
            user = _iInsertUserRepository.GetUserById(Int32.Parse(userId));
            if (user == null)
            {
                Json(false);
            }
            int lan = 0;
            if (user.LanguageId != null)
            {
                lan = (int)user.LanguageId;
            }
            var u = new
            {
                userId = user.UserId,
                firstName = user.FirstName,
                lastName = user.LastName,
                month = Convert.ToDateTime(user.DateOfBirth).Month,
                day = Convert.ToDateTime(user.DateOfBirth).Day,
                year = Convert.ToDateTime(user.DateOfBirth).Year,
                email = user.Email,
                mobileNumber = user.Mobile,
                language = lan
            };
            return Json(JsonConvert.SerializeObject(u));
        }
        #endregion Get User By Id

        #region Update User Address
        [HttpPost]
        public IActionResult UpdateAddress([FromBody] UserAddress address)
        {
            if (_iUserAddressRepository.UpdateAddress(address))
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }
        #endregion Update User Address

        #region Add New Address
        [HttpPost]
        public IActionResult AddNewAddress([FromBody] UserAddress address)
        {
            if (_iUserAddressRepository.AddNewAddress(address))
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }
        #endregion Add New Address

        #region Delete Address
        [HttpPost]
        public IActionResult DeleteAddress(string AddressId)
        {
            if (_iUserAddressRepository.DeleteAddress(Int32.Parse(AddressId)))
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }
        #endregion Delete Address

        #region Reset Password
        public bool ResetPassword(string oldPassword, string newPassword)
        {
            int userId = Convert.ToInt32(HttpContext.Session.GetInt32("userID"));

            return _iLoginRepository.ResetPassword(userId, oldPassword, newPassword);
        }
        #endregion Reset Password
    }
}
