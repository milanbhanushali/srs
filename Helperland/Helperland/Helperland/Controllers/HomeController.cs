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

        public HomeController(ILogger<HomeController> logger,ILoginRepository iLoginRepository)
        {
            _logger = logger;
            _iLoginRepository = iLoginRepository;
        }
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
        public IActionResult Index()
        {
            return View();
        }
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
