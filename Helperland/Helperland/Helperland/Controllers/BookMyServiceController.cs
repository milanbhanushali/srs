using Helperland.Models;
using Helperland.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Helperland.Controllers
{
    public class BookMyServiceController : Controller
    {

        private readonly IBookServiceRepository _iBookServiceRepository;

        public BookMyServiceController(IBookServiceRepository iBookServiceRepository)
        {
            _iBookServiceRepository = iBookServiceRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CheckPincode(string Pincode)
        {
            if (ModelState.IsValid)
            {
                if(Pincode == null || Pincode.Length > 7 || !Regex.IsMatch(Pincode, @"^[0-9]{6}$"))
                {
                    return Json(false);
                }
                else
                {
                    if (_iBookServiceRepository.IsPincodeAvailable(Pincode))
                    {
                        return Json(true);
                    }
                    else
                    {
                        return Json(false);
                    }
                }
            }
            else
            {
                return Json("Enter Pincode Properly");
            }
        }
    }
}
