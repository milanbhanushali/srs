using Helperland.Data;
using Helperland.Models;
using Helperland.Models.ViewModel;
using Helperland.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
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
                    
                    if(loginViewModel.Email != null)
                    {
                        User objUser =_iLoginRepository.GetUser(loginViewModel.UserID);
                        HttpContext.Session.SetInt32("userID", loginViewModel.UserID);
                        HttpContext.Session.SetString("FirstName", objUser.FirstName);

                        CookieOptions options = new CookieOptions();
                        options.Expires = DateTime.Now.AddMinutes(20);
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
                    ModelState.AddModelError("", _iLoginRepository.Message());
                    ViewBag.isOpen = true;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ForgotPasswordResetlink(LoginViewModel uc)
        {
            if (ModelState.IsValid)
            {
                string baseUrl = string.Format("{0}://{1}", HttpContext.Request.Scheme, HttpContext.Request.Host);
                var activationUrl = $"{baseUrl}/Account/NewPassword";
                var verify = _iLoginRepository.IsUserEmailValid(uc);

                String To = uc.Email;
                String subject = "Helperland - Reset your password ";
                String Body = "Reset password" + " : " + activationUrl;
                MailMessage obj = new MailMessage();
                obj.To.Add(To);
                obj.Subject = subject;
                obj.Body = Body;
                obj.From = new MailAddress("180540107015@darshan.ac.in");
                obj.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.Port = 587;
                smtp.UseDefaultCredentials = true;
                smtp.EnableSsl = true;
                smtp.Credentials = new System.Net.NetworkCredential("180540107015@darshan.ac.in", "6354699577");
                smtp.Send(obj);
                ViewBag.message = "The email has been sent";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        public IActionResult Index(bool isLogged = false , bool isLoginOpen = false)
        {
            ViewBag.IsLogged = isLogged;
            ViewBag.isLoginOpen = isLoginOpen;
            ViewBag.isOpen = false;
            ViewBag.isForgetPasswordOpen = false;
            ViewBag.Success = false;
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
