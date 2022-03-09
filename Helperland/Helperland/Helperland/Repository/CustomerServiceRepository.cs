using Helperland.Data;
using Helperland.Models;
using Helperland.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Helperland.Repository
{
    public class CustomerServiceRepository : ICustomerServiceRepository
    {
        public HelperlandsContext _helperlandsContext;
        private readonly IConfiguration _iconfiguration;
        public string _Message { get; set; }

        public CustomerServiceRepository(HelperlandsContext helperlandsContext, IConfiguration configuration)
        {
            _helperlandsContext = helperlandsContext;
            _iconfiguration = configuration;
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

        #region Get Service Request
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
        #endregion Get Service Request

        #region GetService Request Date
        public string GetServiceDate(int serviceID)
        {
            try
            {
                ServiceRequest sr = _helperlandsContext.ServiceRequest.Where(x => x.ServiceId == serviceID).FirstOrDefault();
                return sr.ServiceStartDate.ToString("yyyy-MM-dd");
            }
            catch(Exception ex)
            {
                _Message = ex.Message;
                return _Message.ToString();
            }
            
        }
        #endregion

        #region Update Service Date
        public bool UpdateServiceDate(int serviceId, DateTime serviceDate)
        {
            ServiceRequest request = _helperlandsContext.ServiceRequest.Where(x => x.ServiceId == serviceId).FirstOrDefault();

            if (request.ServiceProviderId == null)
            {
                request.ServiceStartDate = serviceDate;
                _helperlandsContext.ServiceRequest.Update(request);
                _helperlandsContext.SaveChanges();
                return true;
            }
            else
            {
                ServiceRequest objServiceRequest = _helperlandsContext.ServiceRequest.Where(x => x.ServiceProviderId == request.ServiceProviderId && x.ServiceStartDate == serviceDate).FirstOrDefault();
                if (objServiceRequest == null)
                {
                    #region Send Email to service Provider Service Date change
                    User user = _helperlandsContext.User.Where(x => x.UserId == request.ServiceProviderId).FirstOrDefault();

                    string welcomeMessage = "Welcome to Helperland,   <br/> Service Date change for Service ID " + request.ServiceId + " <br/> <b> Check it now <b>";
                    request.ServiceStartDate = serviceDate;

                    String To = user.Email;
                    String subject = "Service Request Date Change ";
                    String Body = "Date Change" + " : " + welcomeMessage;
                    MailMessage obj = new MailMessage();
                    obj.To.Add(To);
                    obj.Subject = subject;
                    obj.Body = Body;
                    obj.From = new MailAddress("dreamers96845@gmail.com");
                    obj.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                    smtp.Port = 587;
                    smtp.UseDefaultCredentials = true;
                    smtp.EnableSsl = true;
                    smtp.Credentials = new System.Net.NetworkCredential("dreamers96845@gmail.com", "goals@2022");
                    smtp.Send(obj);
                    _helperlandsContext.ServiceRequest.Update(request);
                    _helperlandsContext.SaveChanges();
                    #endregion Send Email to service Provider Service Date change
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
        #endregion

        #region Cancel Service
        public bool CancelService(int serviceId, string message)
        {
            ServiceRequest objServiceRequest = _helperlandsContext.ServiceRequest.Where(x => x.ServiceId == serviceId).FirstOrDefault();
            objServiceRequest.Status = 1;
            try
            {
                _helperlandsContext.ServiceRequest.Update(objServiceRequest);
                _helperlandsContext.SaveChanges();
                if (objServiceRequest.ServiceProviderId != null)
                {
                    #region Send Email To Service Provider that Service is cancel 
                    string welcomeMessage = "Welcome to Helperland,   <br/> Service Request no  " + objServiceRequest.ServiceRequestId + " is canceled due to below reason. <br/>" + message;
                    User objUser = _helperlandsContext.User.Where(x => x.UserId == objServiceRequest.ServiceProviderId).FirstOrDefault();

                    String To = objUser.Email;
                    String subject = "Service Cancel Reason ";
                    String Body = "Cancel Service because of " + " : " + welcomeMessage;
                    MailMessage obj = new MailMessage();
                    obj.To.Add(To);
                    obj.Subject = subject;
                    obj.Body = Body;
                    obj.From = new MailAddress("dreamers96845@gmail.com");
                    obj.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                    smtp.Port = 587;
                    smtp.UseDefaultCredentials = true;
                    smtp.EnableSsl = true;
                    smtp.Credentials = new System.Net.NetworkCredential("dreamers96845@gmail.com", "goals@2022");
                    smtp.Send(obj);
                    #endregion Send Email To Service Provider that Service is cancel
                }

                return true;
            }
            catch (Exception ex)
            {
                _Message = ex.Message;
                return false;
            }
        }
        #endregion Cancel Service

        public string Message()
        {
            throw new NotImplementedException();
        }
    }
}
