using Helperland.Models;
using Helperland.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Repository
{
    public interface ILoginRepository
    {
        public string Message();

        public Boolean IsUserValid(LoginViewModel loginViewModel);
        public Boolean IsUserEmailValid(LoginViewModel loginViewModel);
        public User GetUser(int userID);
        public Boolean updateUserNewPassword(User uc);
        public bool ResetPassword(int userId, string OldPassword, string NewPassword);
    }
}
