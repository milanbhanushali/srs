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
        private readonly IRatingRepository _iRatingRepository;
        public string _Message { get; set; }

        public CustomerServiceRepository(HelperlandsContext helperlandsContext, IConfiguration configuration,IRatingRepository ratingRepository)
        {
            _helperlandsContext = helperlandsContext;
            _iconfiguration = configuration;
            _iRatingRepository = ratingRepository;
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
                    objTempCustomerHistory.Rating = _iRatingRepository.GetRating(item.ServiceProviderId);
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
                    objCustomerServiceHistory.TotalHour = (objServiceRequest.ExtraHours + objServiceRequest.ServiceHours).ToString();
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

        #region Get all services history 
        public List<ServiceHistoryViewModel> GetServicesHistoryByUserId(int userID)
        {
            List<ServiceRequest> objServiceRequest = _helperlandsContext.ServiceRequest.Where(x => x.UserId == userID).ToList();
            List<ServiceHistoryViewModel> objServiceHistoryViewModel = new List<ServiceHistoryViewModel>();
            foreach (var item in objServiceRequest)
            {
                ServiceHistoryViewModel objServiceHVM = new ServiceHistoryViewModel();
                objServiceHVM.ServiceId = item.ServiceRequestId;
                objServiceHVM.ServiceProvideId = item.ServiceProviderId;
                if (objServiceHVM.ServiceProvideId != null)
                {
                    User u = _helperlandsContext.User.Where(x => x.UserId == objServiceHVM.ServiceProvideId).FirstOrDefault();
                    objServiceHVM.ServiceProviderName = u.FirstName + " " + u.LastName;
                }
                objServiceHVM.StartDate = item.ServiceStartDate.ToString("dd/MM/yyyy");
                objServiceHVM.Payment = item.TotalCost;
                objServiceHVM.Status = item.Status;
                if (objServiceHVM.Status == 1)
                {
                    objServiceHVM.Rate = false;
                }
                else
                {
                    Rating rating = _helperlandsContext.Rating.Where(x => x.ServiceRequestId == item.ServiceRequestId).FirstOrDefault();
                    if (rating == null)
                        objServiceHVM.Rate = true;
                    else
                        objServiceHVM.Rate = false;
                }

                objServiceHVM.Rating = _iRatingRepository.GetRating(item.ServiceProviderId);
                objServiceHistoryViewModel.Add(objServiceHVM);
            }
            return objServiceHistoryViewModel;
        }
        #endregion Get all services history 

        #region Get Service From Service Id
        public object GetServiceDetails(int serviceId)
        {
            ServiceRequest sr = _helperlandsContext.ServiceRequest.Where(x => x.ServiceRequestId == serviceId).FirstOrDefault();

            List<ServiceRequestExtra> sre = _helperlandsContext.ServiceRequestExtra.Where(x => x.ServiceRequestId == serviceId).ToList();
            ServiceRequestAddress sra = _helperlandsContext.ServiceRequestAddress.Where(x => x.ServiceRequestId == serviceId).FirstOrDefault();
            string name = "";
            User u = _helperlandsContext.User.Where(x => x.UserId == sr.UserId).FirstOrDefault();
            if (sr.ServiceProviderId != null)
            {
                User user = _helperlandsContext.User.Where(x => x.UserId == sr.ServiceProviderId).FirstOrDefault();
                name = user.FirstName + " " + user.LastName;
            }

            string extra = "";
            foreach (var i in sre)
            {
                if (i.ServiceExtraId == 1)
                    extra += "Inside Cabinet, ";
                if (i.ServiceExtraId == 2)
                    extra += "Inside Fridge, ";
                if (i.ServiceExtraId == 3)
                    extra += "Interior Oven, ";
                if (i.ServiceExtraId == 4)
                    extra += "Interior Window, ";
                if (i.ServiceExtraId == 5)
                    extra += "Laundry & Wash, ";
            }
            var temp = new
            {
                ServiceDate = sr.ServiceStartDate.ToString("dd/MM/yyyy"),
                TotalHour = sr.ServiceHours,
                Extra = extra,
                TotalCost = sr.TotalCost,
                Address = sra.AddressLine1 + " , " + sra.AddressLine2 + " , " + sra.PostalCode,
                MobileNumber = sra.Mobile,
                Email = u.Email,
                ServiceProviderId = sr.ServiceProviderId,
                Comments = sr.Comments,
                Haspet = sr.HasPets,
                ServiceProviderName = name,
                Rating = _iRatingRepository.GetRating(sr.ServiceProviderId)
            };
            return temp;

        }
        #endregion Get Service From Service Id

        #region Message
        public string Message()
        {
            throw new NotImplementedException();
        }
        #endregion Message
    }
}
