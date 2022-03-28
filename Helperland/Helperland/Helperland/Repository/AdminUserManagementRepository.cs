using Helperland.Data;
using Helperland.Models;
using Helperland.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Repository
{
    public class AdminUserManagementRepository : IAdminUserManagementRepository
    {
        public HelperlandsContext _helperlandsContext;
        
        public AdminUserManagementRepository(HelperlandsContext helperlandsContext)
        {
            _helperlandsContext = helperlandsContext;
            
        }

        #region List of User
        public List<AdminUserManagementViewModel> GetUserDetails()
        {
            try
            {
                List<User> arrUser = _helperlandsContext.User.Where(x => x.UserTypeId != 2).ToList();
                List<AdminUserManagementViewModel> arrAdminUserManagement = new List<AdminUserManagementViewModel>();
                foreach (var item in arrUser)
                {
                    AdminUserManagementViewModel objAdminUserManagement = new AdminUserManagementViewModel();
                    objAdminUserManagement.UserID = item.UserId;
                    objAdminUserManagement.UserName = item.FirstName + " " + item.LastName;
                    objAdminUserManagement.DateOfRegistration = item.CreatedDate;
                    objAdminUserManagement.UserType = item.UserTypeId == 0 ? "Customer" : "Service Provider";
                    objAdminUserManagement.Phone = item.Mobile;
                    objAdminUserManagement.PostalCode = item.ZipCode;
                    objAdminUserManagement.Status = item.Status;
                    arrAdminUserManagement.Add(objAdminUserManagement);
                }
                return arrAdminUserManagement;
            }
            catch(Exception ex)
            {
                string Message = ex.Message;
                return null;
            }
            
        }
        #endregion List of User

        #region Make User Active
        public bool MakeUserActive(int userID)
        {
            try
            {
                User objUser = _helperlandsContext.User.Where(x => x.UserId == userID).FirstOrDefault();
                if(objUser != null)
                {
                    objUser.Status = 1;
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
                string Message = ex.Message;
                return false;
            }
        }
        #endregion Make User Active

        #region Make User Deactive
        public bool MakeUserDeactive(int userID)
        {
            try
            {
                User objUser = _helperlandsContext.User.Where(x => x.UserId == userID).FirstOrDefault();
                if (objUser != null)
                {
                    objUser.Status = 0;
                    _helperlandsContext.User.Update(objUser);
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
                string Message = ex.Message;
                return false;
            }
        }
        #endregion Make User Deactive
    }
}
