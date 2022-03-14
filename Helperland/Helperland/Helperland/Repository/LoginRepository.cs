using Helperland.Data;
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

        #region Constructor
        public LoginRepository(HelperlandsContext helperlandsContext)
        {
            _helperlandsContext = helperlandsContext;
        }
        #endregion Constructor

        #region Get User from UserID
        public User GetUser(int userID)
        {
            try
            {
                User objUser = _helperlandsContext.User.Where(x => x.UserId == userID).FirstOrDefault();
                if (objUser == null)
                {
                    _Message += " Invalid username or password";
                    return null;
                }
                else
                {
                    return objUser;
                }
            }
            catch (Exception ex)
            {
                _Message += ex.Message;
                return null;
            }
        }
        #endregion Get User from UserID

        #region Is User Email Valid
        public bool IsUserEmailValid(LoginViewModel loginViewModel)
        {
            try
            {
                User objUser = _helperlandsContext.User.Where(x =>x.Email == loginViewModel.Email).FirstOrDefault();
                if (objUser == null)
                {
                    _Message += " Invalid username or password";
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                _Message += ex.Message;
                return false;
            }
        }
        #endregion Is User Email Valid

        #region Is User Valid
        public bool IsUserValid(LoginViewModel loginViewModel)
        {
            try
            {
                User objUser = _helperlandsContext.User.Where(x => x.Password == loginViewModel.Password && x.Email == loginViewModel.Email).FirstOrDefault();
                if(objUser == null)
                {
                    _Message += " Invalid username or password";
                    return false;
                }
                else
                {
                    loginViewModel.UserID = objUser.UserId;
                    return true;
                }
            }
            catch(Exception ex)
            {
                _Message += ex.Message;
                return false;
            }
        }
        #endregion Is User Valid

        #region Update New Password
        public bool updateUserNewPassword(User user)
        {
            try
            {
                User objUser = _helperlandsContext.User.Where(x => x.Email == user.Email).FirstOrDefault();
                if (objUser != null)
                {
                    objUser.Email = user.Email;
                    objUser.Password = user.Password;
                    _helperlandsContext.User.Update(objUser);
                    _helperlandsContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                _Message += ex.Message;
                return false;
            }
        }
        #endregion Update New Password

        #region Reset Password 
        public bool ResetPassword(int userId, string OldPassword, string NewPassword)
        {
            try
            {
                User user = _helperlandsContext.User.Find(userId);
                string pass = user.Password;
                if (pass == OldPassword)
                {
                    user.Password = NewPassword;
                    _helperlandsContext.User.Update(user);
                    _helperlandsContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                _Message += ex.Message;
                return false;
            }

        }
        #endregion Reset Password

        public string _Message { get; set; }
        public string Message()
        {
            _Message = "User is invalid";
            return _Message;
        }
    }
}
