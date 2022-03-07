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

        public string CustomerCancelService();

        public string CustomerRescheduleService();


    }
}
