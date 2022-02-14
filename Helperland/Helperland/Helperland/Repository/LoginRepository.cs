﻿using Helperland.Data;
using Helperland.Models;
using Helperland.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Repository
{
    public class LoginRepository : ILoginRepository
    {
        public HelperlandsContext _helperlandsContext;
        public LoginRepository(HelperlandsContext helperlandsContext)
        {
            _helperlandsContext = helperlandsContext;
        }
        public int GetUserID(string Email)
        {
            throw new NotImplementedException();
        }

        public bool IsUserEmailValid(LoginViewModel loginViewModel)
        {
            throw new NotImplementedException();
        }

        public bool IsUserValid(LoginViewModel loginViewModel)
        {
            try
            {
                string objUser = _helperlandsContext.User.Where(x => x.Password == loginViewModel.Password && x.Email == loginViewModel.Email).ToString();
                if(objUser == null)
                {
                    _Message += " Invalid username or password";
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch(Exception ex)
            {
                _Message += ex.Message;
                return false;
            }
        }

        public string _Message { get; set; }
        public string Message()
        {
            _Message = "User is invalid";
            return _Message;
        }
    }
}
