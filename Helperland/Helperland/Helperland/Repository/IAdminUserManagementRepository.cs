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
        public List<AdminServiceHistoryViewModel> GetAllServiceListForAdmin();
        public bool MakeUserActive(int userID);
        public object GetServiceDetails(int serviceRequestId);
        public bool MakeUserDeactive(int userID);
        public object GetServiceDetailsForEditing(int serviceRequestId);
        public Boolean UpdateServiceRequest(string serviceRequestID, string modalDate, string StreetName, string HouseNo, string PostalCode, string City, string Message);
    }
}
