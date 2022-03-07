using Helperland.Data;
using Helperland.Models;
using Helperland.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Repository
{
    public class CustomerServiceRepository : ICustomerServiceRepository
    {
        public HelperlandsContext _helperlandsContext;
        public string _Message { get; set; }

        public CustomerServiceRepository(HelperlandsContext helperlandsContext)
        {
            _helperlandsContext = helperlandsContext;
        }

        public string CustomerCancelService()
        {
            throw new NotImplementedException();
        }

        public string CustomerRescheduleService()
        {
            throw new NotImplementedException();
        }

        #region Get All Service History 
        public List<CustomerServiceHistoryViewModel> GetCustomerServiceHistory(int UserID)
        {
            try
            {
                List<ServiceRequest> objServiceRequest = _helperlandsContext.ServiceRequest.Where(x => x.UserId == UserID).ToList();
                List<CustomerServiceHistoryViewModel> objCustomerHistory = new List<CustomerServiceHistoryViewModel>();
                foreach (var item in objServiceRequest)
                {
                    CustomerServiceHistoryViewModel objTempCustomerHistory = new CustomerServiceHistoryViewModel();
                    objTempCustomerHistory.UserId = UserID;
                    objTempCustomerHistory.ServiceId = item.ServiceId;
                    objTempCustomerHistory.ServiceProviderId = item.ServiceProviderId;
                    if(objTempCustomerHistory.ServiceProviderId != null)
                    {
                        User objUser = _helperlandsContext.User.Where(x => x.UserId == objTempCustomerHistory.ServiceProviderId).FirstOrDefault();
                        objTempCustomerHistory.ServiceProviderName = objUser.FirstName + " " + objUser.LastName;
                    }
                    objTempCustomerHistory.ServiceStartDate = item.ServiceStartDate.ToString("dd/MM/yyyy");
                    objTempCustomerHistory.TotalCost = item.TotalCost;
                    objCustomerHistory.Add(objTempCustomerHistory);

                }
                return objCustomerHistory;
            }
            catch(Exception ex)
            {
                _Message = ex.Message;
                return null;
            }
            
        }
        #endregion Get All Service History 

        public CustomerServiceHistoryViewModel GetServiceRequestID(int ServiceRequestID)
        {
            try
            {
                
                ServiceRequest objServiceRequest = _helperlandsContext.ServiceRequest.Where(x => x.ServiceId == ServiceRequestID).FirstOrDefault();
                ServiceRequestAddress objServiceRequestAddress = _helperlandsContext.ServiceRequestAddress.Where(x => x.ServiceRequestId == objServiceRequest.ServiceRequestId).FirstOrDefault();
                if (objServiceRequest != null && objServiceRequestAddress!=null)
                {
                    CustomerServiceHistoryViewModel objCustomerServiceHistory = new CustomerServiceHistoryViewModel();
                    objCustomerServiceHistory.ServiceStartDate = objServiceRequest.ServiceStartDate.ToString("dd/MM/yyyy");
                    objCustomerServiceHistory.TotalHour = objServiceRequest.ServiceHours.ToString();
                    objCustomerServiceHistory.TotalCost = objServiceRequest.TotalCost;
                    objCustomerServiceHistory.Comments = objServiceRequest.Comments;
                    objCustomerServiceHistory.AddressLine1 = objServiceRequestAddress.AddressLine1;
                    objCustomerServiceHistory.AddressLine2 = objServiceRequestAddress.AddressLine2;
                    objCustomerServiceHistory.Mobile = objServiceRequestAddress.Mobile;
                    objCustomerServiceHistory.Email = objServiceRequestAddress.Email;
                    objCustomerServiceHistory.HasPets = objServiceRequest.HasPets;

                    
                    return objCustomerServiceHistory;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                _Message = ex.Message;
                return null;
            }
        }
        public string Message()
        {
            throw new NotImplementedException();
        }
    }
}
