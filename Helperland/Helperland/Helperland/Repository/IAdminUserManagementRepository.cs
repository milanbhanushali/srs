using Helperland.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Repository
{
    public interface IAdminUserManagementRepository
    {
        public List<AdminUserManagementViewModel> GetUserDetails();

        public bool MakeUserActive(int userID);

        public bool MakeUserDeactive(int userID);
    }
}
