using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Helperland.Models;
using Helperland.Models.ViewModel;
namespace Helperland.Repository
{
    public interface ICustomerServiceRepository
    {
        public string Message();
        public List<CustomerServiceHistoryViewModel> GetCustomerServiceHistory(int UserID);
        public CustomerServiceHistoryViewModel GetServiceRequestID(int ServiceRequestID);
        public string GetServiceDate(int serviceRequestId);
        public bool UpdateServiceDate(int serviceId, DateTime serviceDate);
        public bool CancelService(int serviceId, string message);
        public object GetServiceDetails(int serviceRequestId);
        public List<ServiceHistoryViewModel> GetServicesHistoryByUserId(int userID);

    }
}
