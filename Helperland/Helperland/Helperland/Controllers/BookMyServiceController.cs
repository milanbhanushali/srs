using Helperland.Models;
using Helperland.Models.ViewModel;
using Helperland.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
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
        private readonly IUserAddressRepository _iUserAddress;

        public BookMyServiceController(IBookServiceRepository iBookServiceRepository , IUserAddressRepository iUserAddress)
        {
            _iBookServiceRepository = iBookServiceRepository;
            _iUserAddress = iUserAddress;
        }

        public IActionResult Index(bool isLogged = false)
        {
            ViewBag.IsLogged = isLogged;

            ViewBag.city = _iBookServiceRepository.GetAllCity().Select(x => new SelectListItem()
            {
                Text = x.CityName,
                Value = x.Id.ToString()
            });
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


        #region AddAddress( UserAddressModel )
        [HttpPost]
        public IActionResult AddAddress(UserAddressModel userAddressModel)
        {
            if (userAddressModel.UserId != null && userAddressModel.AddressLine1 != null && userAddressModel.AddressLine2 != null && userAddressModel.CityId != null)
            {
                if (_iBookServiceRepository.SetAddress(userAddressModel))
                {
                    return Json(true);
                }
                else
                {
                    return Json(false);
                }
            }
            else
            {
                return Json(false);
            }

        }
        #endregion AddAddress( UserAddressModel )

        public IActionResult GetAddress(string userID)
        {
            List<UserAddressModel> addresses = _iBookServiceRepository.GetAddress(Int32.Parse(userID));
            if (addresses == null)
            {
                Json(false);
            }
            return Json(JsonConvert.SerializeObject(addresses));

        }


        [HttpPost]
        public int ServiceSchedule(BookServiceViewModel bookServiceViewModels)
        {
            try
            {
                int serviceID = _iBookServiceRepository.AddService(bookServiceViewModels);
                return serviceID;
            }
            catch(Exception ex)
            {
                return -1;
            }
           
        }
        
        

    }
}
