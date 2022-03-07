using Helperland.Models;
using Helperland.Models.ViewModel;
using Helperland.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Net.Mail;

namespace Helperland.Controllers
{
    public class HomeController : Controller
    {
        #region Repository variables
        private readonly ILogger<HomeController> _logger;
        private readonly ILoginRepository _iLoginRepository;
        private readonly IInsertUserRepository _iInsertUserRepository;
        #endregion Repository variables

        #region HomeController Constructor

        public HomeController(ILogger<HomeController> logger, ILoginRepository iLoginRepository, IInsertUserRepository insertUserRepository)
        {
            _logger = logger;
            _iLoginRepository = iLoginRepository;
            _iInsertUserRepository = insertUserRepository;
        }

        #endregion HomeController Constructor

        #region Index
        public IActionResult Index(bool isLogged = false, bool isLoginOpen = false)
        {
            ViewBag.IsLogged = isLogged;
            ViewBag.isLoginOpen = isLoginOpen;
            ViewBag.isOpen = false;
            ViewBag.isForgetPasswordOpen = false;
            ViewBag.Success = false;
            
            return View();
        }
        #endregion Index

        #region Login

        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                if (_iLoginRepository.IsUserValid(loginViewModel))
                {
                    if (loginViewModel.Email != null)
                    {
                        User objUser = _iLoginRepository.GetUser(loginViewModel.UserID);
                        HttpContext.Session.SetInt32("userID", loginViewModel.UserID);
                        HttpContext.Session.SetString("FirstName", objUser.FirstName);
                        HttpContext.Session.SetString("userEmail", objUser.Email);

                        CookieOptions options = new CookieOptions();
                        options.Expires = DateTime.Now.AddMinutes(15);
                        Response.Cookies.Append("userID", objUser.UserId.ToString(), options);
                        Response.Cookies.Append("username", objUser.FirstName, options);
                        Response.Cookies.Append("usertype", objUser.UserTypeId.ToString(), options);
                        HttpContext.Session.SetInt32("userID", objUser.UserId);
                        HttpContext.Session.SetString("username", objUser.FirstName);
                        HttpContext.Session.SetInt32("usertype", objUser.UserTypeId);
                    }
                   

                    return RedirectToAction("Index", new { isLogged = true });
                }
                else
                {
                    ModelState.AddModelError("CustomError", "Email is not registered");
                }
            }

            return View("Index");
        }

        #endregion Login

        #region Logout

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            Response.Cookies.Delete("userID");
            Response.Cookies.Delete("username");
            Response.Cookies.Delete("usertype");
            return RedirectToAction("Index", new { isLogged = false });
        }

        #endregion Logout

        #region Forgot Password Reset Link
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ForgotPasswordResetlink(LoginViewModel uc)
        {
            string baseUrl = string.Format("{0}://{1}", HttpContext.Request.Scheme, HttpContext.Request.Host);
            var activationUrl = $"{baseUrl}/Home/NewPassword/{uc.Email}";
            var verify = _iLoginRepository.IsUserEmailValid(uc);
            if (verify)
            {
                String To = uc.Email;
                String subject = "Helperland - Reset your password ";
                String Body = "Reset password" + " : " + activationUrl;
                MailMessage obj = new MailMessage();
                obj.To.Add(To);
                obj.Subject = subject;
                obj.Body = Body;
                obj.From = new MailAddress("dreamers96845@gmail.com");
                obj.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.Port = 587;
                smtp.UseDefaultCredentials = true;
                smtp.EnableSsl = true;
                smtp.Credentials = new System.Net.NetworkCredential("dreamers96845@gmail.com", "goals@2022");
                smtp.Send(obj);
                ModelState.AddModelError("MsgEmailSent", "MessageSent");
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("MsgEmailSent", "Error Occured");
                return RedirectToAction("Index");
            }
        }
        #endregion Forgot Password Reset Link

        #region NewPassword
        [HttpGet]
        public IActionResult NewPassword()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewPassword(User uc)
        {
            
            if (_iLoginRepository.updateUserNewPassword(uc))
            {
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ErrorMessage"] = "Invalid email";
                return RedirectToAction("NewPassword");
            }
        }
        #endregion NewPassword

        #region User Registration
        public IActionResult UserRegistration(bool isSuccess = false)
        {
            ViewBag.IsSuccess = isSuccess;
            return View();
        }
        #endregion User Registration

        #region AddNewUser

        [HttpPost]
        public IActionResult AddNewUser(User objUser)
        {
            if (ModelState.IsValid)
            {
                int id = _iInsertUserRepository.AddNewUser(objUser);
                if (id > 0)
                {
                    return RedirectToAction("UserRegistration", new { isSuccess = true });
                }
                return RedirectToAction("UserRegistration");
            }
            else
            {
                return View();
            }
        }

        #endregion AddNewUser

        #region FAQ
        public IActionResult FAQ()
        {
            int? userID = HttpContext.Session.GetInt32("userID");
            if (userID > 0)
            {
                ViewBag.IsLogged = true;
            }
            return View();
        }
        #endregion FAQ

        #region Prices
        public IActionResult Prices(bool isLogged = false)
        {
            int? userID = HttpContext.Session.GetInt32("userID");
            if(userID > 0)
            {
                ViewBag.IsLogged = true;
            }
            return View();
        }
        #endregion Prices

        #region Contact
        public IActionResult Contact()
        {
            int? userID = HttpContext.Session.GetInt32("userID");
            if (userID > 0)
            {
                ViewBag.IsLogged = true;
            }
            return View();
        }
        #endregion Contact

        #region About
        public IActionResult About()
        {
            int? userID = HttpContext.Session.GetInt32("userID");
            if (userID > 0)
            {
                ViewBag.IsLogged = true;
            }
            return View();
        }
        #endregion About

        #region ServiceUserRegistration
        public IActionResult ServiceUserRegistration(ServiceUserRegistrationModel serviceUserRegistrationModel)
        {
            if (ModelState.IsValid)
            {

                if (serviceUserRegistrationModel.FirstName.Trim() == "" && serviceUserRegistrationModel.LastName.Trim() == "")
                {
                    ModelState.AddModelError("", "Please Enter Correct Data");
                }
                else
                {
                    ViewBag.IsSuccessForSP = _iInsertUserRepository.AddServiceProvider(serviceUserRegistrationModel);
                }
            }
            else
            {
                return View("ServiceProviderBecomeAPro");
            }
            if (ViewBag.IsSuccessForSP)
            {
                ModelState.Clear();
                return View("ServiceProviderBecomeAPro", new { isSuccessForSP = true }); ;
            }
            else
            {
                ModelState.AddModelError("", _iInsertUserRepository.Message());
                return View("Index");
            }
        }
        #endregion ServiceUserRegistration

        #region ServiceProviderBecomeAPro
        public IActionResult ServiceProviderBecomeAPro(bool isSuccessForSP = false)
        {
            ViewBag.IsSuccessForSP = isSuccessForSP;
            return View();
        }
        #endregion ServiceProviderBecomeAPro

        #region Error
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion Error

        #region Service Provider Details
        public IActionResult ServiceProviderDetails()
        {
            return View();
        }
        #endregion Service Provider Details

        #region Customer
        public IActionResult Customer()
        {
            return View();
        }
        #endregion Customer
    }
}