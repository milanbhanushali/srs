using Helperland.Data;
using Helperland.Models;
using Helperland.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Repository
{
    public class InsertUserRepository : IInsertUserRepository
    {
        private readonly HelperlandsContext _helperlandsContext = null;
        public string ExceptionMessage;
        public string _Message { get; set; }
        public InsertUserRepository(HelperlandsContext helperlandsContext)
        {
            _helperlandsContext = helperlandsContext;
        }

        public int AddNewUser(User user)
        {
            try
            {
                var newUser = new User()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Password = user.Password,
                    Mobile = user.Mobile,
                    CreatedDate = DateTime.UtcNow,
                    ModifiedDate = DateTime.UtcNow,
                    UserTypeId = 0,
                    IsRegisteredUser = true,
                    WorksWithPets = false,
                    IsApproved = true,
                    IsActive = true,
                    IsDeleted = true
                };
                _helperlandsContext.User.Add(newUser);

                _helperlandsContext.SaveChanges();

                return newUser.UserId;
            }
            catch(Exception ex)
            {
                ExceptionMessage = ex.Message.ToString();
                return 0;
            }
            
        }
        public string Message()
        {
            _Message = "User is invalid";
            return _Message;
        }

        public Boolean AddServiceProvider(ServiceUserRegistrationModel serviceUserRegistrationModel)
        {
            User check = _helperlandsContext.User.Where(x => x.Email == serviceUserRegistrationModel.Email).FirstOrDefault();
            if (check == null)
            {
                try
                {
                    User user = new User();
                    user.FirstName = serviceUserRegistrationModel.FirstName;
                    user.LastName = serviceUserRegistrationModel.LastName;
                    user.Email = serviceUserRegistrationModel.Email;
                    user.Mobile = serviceUserRegistrationModel.PhoneNumber;
                    user.Password = serviceUserRegistrationModel.Password;
                    user.CreatedDate = DateTime.Now.Date;
                    user.ModifiedDate = DateTime.Now.Date;
                    user.UserTypeId = 2;
                    _helperlandsContext.User.Add(user);
                    _helperlandsContext.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    _Message += ex.Message;
                    return false;
                }
            }
            else
            {
                _Message += "Already register User with this email ";
                return false;
            }
        }

    }
}
