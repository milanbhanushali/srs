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

        public CustomerController(ICustomerServiceRepository customerServiceRepository)
        {
            _icustomerServiceRepository = customerServiceRepository;
        }

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

        public string GetServiceDate(string strServiceRequestId)
        {
            return _icustomerServiceRepository.GetServiceDate(Int32.Parse(strServiceRequestId));
        }

        public bool UpdateServiceDate(string serviceDate, string serviceId)
        {
            bool serviceUpdated = _icustomerServiceRepository.UpdateServiceDate(Int32.Parse(serviceId), Convert.ToDateTime(serviceDate));
            return serviceUpdated;
        }
    }
}
