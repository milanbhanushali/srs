using Helperland.Models;
using Helperland.Models.ViewModel;
using Helperland.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        #endregion Repository Variable

        #region Constructor
        public CustomerController(ICustomerServiceRepository customerServiceRepository)
        {
            _icustomerServiceRepository = customerServiceRepository;
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
    }
}
