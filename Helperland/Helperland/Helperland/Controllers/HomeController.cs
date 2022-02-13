using Helperland.Data;
using Helperland.Models;
using Helperland.Models.ViewModel;
using Helperland.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILoginRepository _iLoginRepository;
        private readonly IInsertUserRepository _iInsertUserRepository;

        #region HomeController Constructor
        public HomeController(ILogger<HomeController> logger,ILoginRepository iLoginRepository,IInsertUserRepository insertUserRepository)
        {
            _logger = logger;
            _iLoginRepository = iLoginRepository;
            _iInsertUserRepository = insertUserRepository;
        }
        #endregion HomeController Constructor

        #region Login
        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                if (_iLoginRepository.IsUserValid(loginViewModel))
                {
                    ModelState.Clear();
                }
                else
                {
                    ModelState.AddModelError("", _iLoginRepository.Message());
                    ViewBag.isOpen = true;
                }
            }
            
            return View("Index");
        }
        #endregion Login

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UserRegistration(bool isSuccess=false)
        {
            ViewBag.IsSuccess = isSuccess;
            return View();
        }

        #region AddNewUser
        [HttpPost]
        public IActionResult AddNewUser(User objUser)
        {
            if (ModelState.IsValid)
            {
                int id = _iInsertUserRepository.AddNewUser(objUser);
                if (id > 0)
                {
                    return RedirectToAction("UserRegistration",new { isSuccess = true });
                }
                return RedirectToAction("UserRegistration");
            }
            else
            {
                return View();
            }
        }
        #endregion AddNewUser
        public IActionResult FAQ()
        {
            return View();
        }
        public IActionResult Prices()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult ServiceProviderBecomeAPro()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
