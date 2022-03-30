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
    public class AdminController : Controller
    {
        private IAdminUserManagementRepository _iAdminUserManagementRepository;
        private readonly IBookServiceRepository _iBookServiceRepository;
        public AdminController(IAdminUserManagementRepository adminUserManagementRepository,IBookServiceRepository bookServiceRepository)
        {
            _iAdminUserManagementRepository = adminUserManagementRepository;
            _iBookServiceRepository = bookServiceRepository;
        }
        #region View - Index ( User Management )
        public IActionResult Index()
        {
            int userID = Convert.ToInt32(HttpContext.Session.GetInt32("userID"));
            if (userID > 0)
            {
                ViewBag.IsLogged = true;
                return View(_iAdminUserManagementRepository.GetUserDetails());
            }
            else
            {
                return Json("UserID is null");
            }
        }
        #endregion View - Index ( User Management )

        #region View - Service Request
        public IActionResult ServiceRequest()
        {
            ViewBag.city = _iBookServiceRepository.GetAllCity().Select(x => new SelectListItem()
            {
                Text = x.CityName,
                Value = x.Id.ToString()
            });
            int userID = Convert.ToInt32(HttpContext.Session.GetInt32("userID"));
            if (userID > 0)
            {
                ViewBag.IsLogged = true;
                return View(_iAdminUserManagementRepository.GetAllServiceListForAdmin());
            }
            else
            {
                return Json("UserID is null");
            }
            
        }
        #endregion View - Service Request

        #region Method - MakeUserActive
        public bool MakeUserActive(int userID)
        {
            return _iAdminUserManagementRepository.MakeUserActive(userID);
        }
        #endregion Method - MakeUserActive

        #region Method - MakeUserDeactive
        public bool MakeUserDeactive(int userID)
        {
            return _iAdminUserManagementRepository.MakeUserDeactive(userID);
        }
        #endregion Method - MakeUserDeactive

        #region Method - Get Service By Service Request ID
        public IActionResult GetServiceRequestData(string ServiceRequestId)
        {
            return Json(JsonConvert.SerializeObject(_iAdminUserManagementRepository.GetServiceDetails(Int32.Parse(ServiceRequestId))));
        }
        #endregion Method - Get Service By Service Request ID

        #region Method - Get All details of services 
        public IActionResult GetServiceRequestDetailsForEdit(string ServiceRequestId)
        {
            return Json(JsonConvert.SerializeObject(_iAdminUserManagementRepository.GetServiceDetailsForEditing(Int32.Parse(ServiceRequestId))));
        }
        #endregion Method - Get All details of services 

        #region Update Service Details
        [HttpPost]
        public IActionResult UpdateService(string serviceRequestID, string modalDate, string StreetName, string HouseNo, string PostalCode, string City,string Message)
        {
            ViewBag.city = _iBookServiceRepository.GetAllCity().Select(x => new SelectListItem()
            {
                Text = x.CityName,
                Value = x.Id.ToString()
            });
            if (_iAdminUserManagementRepository.UpdateServiceRequest(serviceRequestID,modalDate,StreetName,HouseNo,PostalCode,City,Message))
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }
        #endregion Update Service Details
        
    }
}
