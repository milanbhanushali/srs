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
    public class ServiceProviderController : Controller
    {
        #region Repository Variable
        private readonly ICustomerServiceRepository _icustomerServiceRepository;
        private readonly IRatingRepository _iRatingRepository;
        private readonly IBookServiceRepository _iBookServiceRepository;
        private readonly IUserAddressRepository _iUserAddressRepository;
        private readonly IInsertUserRepository _iInsertUserRepository;
        private readonly ILoginRepository _iLoginRepository;
        private readonly IServiceRequestRepository _iServiceRequestRepository;
        private readonly IFavouriteAndBlockRepository _iFavouriteAndBlockRepository;
        private readonly IServiceProviderMySettingRepository _iServiceProviderMySettingRepository;

        #endregion Repository Variable

        #region Constructor
        public ServiceProviderController(ICustomerServiceRepository customerServiceRepository, IRatingRepository ratingRepository, IBookServiceRepository bookServiceRepository, IUserAddressRepository userAddressRepository, IInsertUserRepository insertUserRepository, ILoginRepository loginRepository,IServiceRequestRepository serviceRequestRepository,IFavouriteAndBlockRepository favouriteAndBlockRepository,IServiceProviderMySettingRepository serviceProviderMySettingRepository)
        {
            _icustomerServiceRepository = customerServiceRepository;
            _iRatingRepository = ratingRepository;
            _iBookServiceRepository = bookServiceRepository;
            _iUserAddressRepository = userAddressRepository;
            _iInsertUserRepository = insertUserRepository;
            _iLoginRepository = loginRepository;
            _iServiceRequestRepository = serviceRequestRepository;
            _iFavouriteAndBlockRepository = favouriteAndBlockRepository;
            _iServiceProviderMySettingRepository = serviceProviderMySettingRepository;
        }
        #endregion Constructor

        #region View - Index Page Of Service Provider
        public IActionResult Index()
        {
            int userID = Convert.ToInt32(HttpContext.Session.GetInt32("userID"));
            if (userID > 0)
            {
                ViewBag.IsLogged = true;
            }
            else
            {
                ViewBag.IsLogged = false;
            }
            return View();
        }
        #endregion View - Index Page Of Service Provider

        #region View - New Service Request
        [HttpGet]
        public IActionResult NewServiceRequest(string strHasPets)
        {
            int userID = Convert.ToInt32(HttpContext.Session.GetInt32("userID"));
            if (userID > 0)
            {
                bool hasPets;
                ViewBag.IsLogged = true;
                if (strHasPets == "on")
                {
                    hasPets = true;
                }
                else
                {
                    hasPets = false;
                }
                ViewBag.hasPets = hasPets;
                return View(_iServiceRequestRepository.GetServiceRequestsNotAccepted(userID, hasPets));
            }
            else
            {
                ViewBag.IsLogged = false;
                return Json("UserID is null");
            }
        }
        #endregion View - New Service Request

        #region View - Upcoming Services
        public IActionResult UpcomingServices()
        {
            int userID = Convert.ToInt32(HttpContext.Session.GetInt32("userID"));
            if (userID > 0)
            {
                ViewBag.IsLogged = true;
                return View(_iServiceRequestRepository.GetServiceRequestsIsAccepted(userID));
            }
            else
            {
                return Json("UserID is null");
            } 
        }
        #endregion View - Upcoming Services

        #region View - Service History
        public IActionResult ServiceHistory()
        {
            int userID = Convert.ToInt32(HttpContext.Session.GetInt32("userID"));
            if (userID > 0)
            {
                ViewBag.IsLogged = true;
                return View(_iServiceRequestRepository.GetServiceHistoryForServiceProvider(userID));
            }
            else
            {
                return Json("UserID is null");
            }
        }
        #endregion View - Service History

        #region View - My Rating
        public IActionResult MyRating()
        {
            int userID = Convert.ToInt32(HttpContext.Session.GetInt32("userID"));
            if (userID > 0)
            {
                ViewBag.IsLogged = true;
                return View(_iRatingRepository.GetRatingsForServiceProvider(userID));
            }
            else
            {
                return Json("UserID is null");
            }
            
        }
        #endregion View - My Rating

        #region View - Block Customer
        public IActionResult BlockCustomer()
        {
            int userID = Convert.ToInt32(HttpContext.Session.GetInt32("userID"));
            if (userID > 0)
            {
                ViewBag.IsLogged = true;
                return View(_iFavouriteAndBlockRepository.GetListOfCustomer(userID));
            }
            else
            {   
                return Json("UserID is null");
            }
        }
        #endregion View - Block Customer

        #region View - My Setting
        public IActionResult MySetting()
        {
            int userID = Convert.ToInt32(HttpContext.Session.GetInt32("userID"));
            if (userID > 0)
            {
                ViewBag.IsLogged = true;
                ViewBag.city = _iBookServiceRepository.GetAllCity().Select(x => new SelectListItem()
                {
                    Text = x.CityName,
                    Value = x.Id.ToString()
                });
                return View(_iServiceProviderMySettingRepository.SPDetails(userID));
            }
            else
            {
                return Json("UserID is null");
            }
        }
        #endregion View - My Setting

        #region Method - Get Service Request Data from Service Request ID
        public IActionResult GetServiceRequestData(string ServiceReqestId)
        {
            return Json(JsonConvert.SerializeObject(_iServiceRequestRepository.GetServiceDetailsforServiceProvider(Int32.Parse(ServiceReqestId))));
        }
        #endregion Method - Get Service Request Data from Service Request ID

        #region Method - Accept Service
        public string AcceptServiceRequest(string serviceRequeestId)
        {
            int userID = Convert.ToInt32(HttpContext.Session.GetInt32("userID"));
            return _iServiceRequestRepository.AcceptServiceRequest(userID, Int32.Parse(serviceRequeestId));
        }
        #endregion Method - Accept Service

        #region Method - Cancelled Service
        public bool CancelledServiceRequest(string serviceRequestId, string message)
        {
            return _iServiceRequestRepository.CancelServiceRequest(Int32.Parse(serviceRequestId), message);
        }
        #endregion Method - Cancelled Service

        #region Method - Accept Service
        public bool CompleteServiceRequest(string serviceRequestId)
        {
            return _iServiceRequestRepository.CompletedService(Int32.Parse(serviceRequestId));
        }
        #endregion Method - Accept Service

        #region Method - Unblock This Customer
        public bool UnblockThisCustomer(string userId)
        {
            int SPuserID = Convert.ToInt32(HttpContext.Session.GetInt32("userID"));
            return _iFavouriteAndBlockRepository.UnblockCustomer(SPuserID, Int32.Parse(userId));
        }
        #endregion Method - Unblock This Customer

        #region Method - Block This Customer
        public bool BlockThisCustomer(string userId)
        {
            int SPuserID = Convert.ToInt32(HttpContext.Session.GetInt32("userID"));
            return _iFavouriteAndBlockRepository.BlockCustomer(SPuserID, Int32.Parse(userId));
        }
        #endregion Method - Block This Customer

        #region Method - Get User Data
        [HttpPost]
        public IActionResult GetUserData(SPDetailsViewModel sPDetailsViewModel)
        {
            if (ModelState.IsValid)
            {
                int SPuserID = Convert.ToInt32(HttpContext.Session.GetInt32("userID"));
                _iInsertUserRepository.UpdateServiceProviderData(sPDetailsViewModel, SPuserID);
            }
            return RedirectToAction("MySetting");
        }
        #endregion Method - Get User Data

        #region Method - Reset Password
        public bool ResetPassword(string oldPassword, string newPassword)
        {
            int SPuserID = Convert.ToInt32(HttpContext.Session.GetInt32("userID"));
            return _iLoginRepository.ResetPassword(SPuserID, oldPassword, newPassword);
        }
        #endregion Method - Reset Password
    }
}
