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
                    HttpContext.Session.SetString("Email", loginViewModel.Email);
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

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult ForgotPasswordResetlink(User uc)
        //{
        //    string baseUrl = string.Format("{0}://{1}", HttpContext.Request.Scheme, HttpContext.Request.Host);
        //    var activationUrl = $"{baseUrl}/Account/NewPassword";
        //    var verify = (from x in _iLoginRepository.Users where x.Email == uc.Email select x).FirstOrDefault();

        //    String To = uc.Email;
        //    String subject = "Helperland - Reset your password ";
        //    String Body = "Reset password" + " : " + activationUrl;
        //    MailMessage obj = new MailMessage();
        //    obj.To.Add(To);
        //    obj.Subject = subject;
        //    obj.Body = Body;
        //    obj.From = new MailAddress("harshitrajani1988@gmail.com");
        //    obj.IsBodyHtml = true;
        //    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
        //    smtp.Port = 587;
        //    smtp.UseDefaultCredentials = true;
        //    smtp.EnableSsl = true;
        //    smtp.Credentials = new System.Net.NetworkCredential("harshitrajani1988@gmail.com", "harshit@Ldrp.");
        //    smtp.Send(obj);
        //    ViewBag.message = "The email has been sent";
        //    return RedirectToAction("Index", "Home");


        //}

        public IActionResult Index(bool isLogged = false)
        {
            ViewBag.IsLogged = isLogged;
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
            ViewBag.IsLogged = true;
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
