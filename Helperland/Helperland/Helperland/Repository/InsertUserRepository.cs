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
        #region Variables
        private readonly HelperlandsContext _helperlandsContext = null;
        public string ExceptionMessage;
        public string _Message { get; set; }
        #endregion Variables

        #region Constructor
        public InsertUserRepository(HelperlandsContext helperlandsContext)
        {
            _helperlandsContext = helperlandsContext;
        }
        #endregion Constructor

        #region Add New User
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
        #endregion Add New User

        #region Message
        public string Message()
        {
            _Message = "User is invalid";
            return _Message;
        }
        #endregion Message

        #region Add Service Provider
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
        #endregion Add Service Provider

        #region Change User Data
        public Boolean ChangeUserData(string FirstName, string LastName, string DOB, string MobileNumber, int UserId, int LanguageId)
        {
            User user = _helperlandsContext.User.Where(x => x.UserId == UserId).FirstOrDefault();
            user.FirstName = FirstName;
            user.LanguageId = LanguageId;
            user.LastName = LastName;
            user.DateOfBirth = Convert.ToDateTime(DOB);
            user.Mobile = MobileNumber;

            try
            {
                _helperlandsContext.User.Update(user);
                _helperlandsContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                ExceptionMessage = ex.Message.ToString();
                return false;
            }
        }
        #endregion Change User Data

        #region GetUser By ID
        public User GetUserById(int userID)
        {
            User user = new User();
            try
            {
                user = _helperlandsContext.User.Where(x => x.UserId == userID).FirstOrDefault();
                if (user != null)
                    return user;
                else
                    return null;
            }
            catch (Exception ex)
            {
                ExceptionMessage = ex.Message.ToString();
                return null;
            }
        }
        #endregion GetUser By ID

    }
}
