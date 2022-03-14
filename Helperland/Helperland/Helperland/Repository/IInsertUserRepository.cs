using Helperland.Models;
using Helperland.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Repository
{
    public interface IInsertUserRepository
    {
        public string Message();

        public int AddNewUser(User user);

        public Boolean AddServiceProvider(ServiceUserRegistrationModel serviceUserRegistrationModel);

        public Boolean ChangeUserData(string FirstName, string LastName, string DOB, string MobileNumber, int UserId, int LanguageId);

        public User GetUserById(int userID);

    }
}
