using Helperland.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Controllers
{
    public class AdminController : Controller
    {
        private IAdminUserManagementRepository _iAdminUserManagementRepository;
        public AdminController(IAdminUserManagementRepository adminUserManagementRepository)
        {
            _iAdminUserManagementRepository = adminUserManagementRepository;
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
            return View();
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
    }
}
