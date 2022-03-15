using Helperland.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        #endregion Repository Variable
        public ServiceProviderController(ICustomerServiceRepository customerServiceRepository, IRatingRepository ratingRepository, IBookServiceRepository bookServiceRepository, IUserAddressRepository userAddressRepository, IInsertUserRepository insertUserRepository, ILoginRepository loginRepository,IServiceRequestRepository serviceRequestRepository)
        {
            _icustomerServiceRepository = customerServiceRepository;
            _iRatingRepository = ratingRepository;
            _iBookServiceRepository = bookServiceRepository;
            _iUserAddressRepository = userAddressRepository;
            _iInsertUserRepository = insertUserRepository;
            _iLoginRepository = loginRepository;
            _iServiceRequestRepository = serviceRequestRepository;

            int userID = Convert.ToInt32(HttpContext.Session.GetInt32("userID"));
            if(userID > 0)
            {
                ViewBag.IsLogged = true;
            }
            else
            {
                ViewBag.IsLogged = false;
            }
        }   
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NewServiceRequest(string strHasPets)
        {
            int userID = Convert.ToInt32(HttpContext.Session.GetInt32("userID"));
            bool hasPets;
            if (strHasPets == "on")
            {
                hasPets = true;
            }
            else
            {
                hasPets = false;
            }
            ViewBag.hasPets = hasPets;
            return View(_iServiceRequestRepository.GetServiceRequestsNotAccepted(userID,hasPets));
        }
    }
}
