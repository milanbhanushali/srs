﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public Boolean ServiceUserRegistration()
        {
            if (ModelState.IsValid)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}