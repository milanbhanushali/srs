using Helperland.Data;
using Helperland.Models;
using Helperland.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Helperland.Repository
{
    public class ServiceRequestRepository : IServiceRequestRepository
    {
        #region variables
        public HelperlandsContext _helperlandsContext;
        public RatingRepository _iRatingRepository;
        #endregion variables

        #region Constructor
        public ServiceRequestRepository(HelperlandsContext helperlandsContext,RatingRepository ratingRepository)
        {
            _helperlandsContext = helperlandsContext;
            _iRatingRepository = ratingRepository;
        }
        #endregion Constructor

        #region Get all services by UserID
        public List<ServiceHistoryViewModel> GetServicesByUserId(int userID)
        {
           List<ServiceRequest> sr = _helperlandsContext.ServiceRequest.Where(x=> x.UserId == userID && x.Status == null).ToList();
            List<ServiceHistoryViewModel> csv =new List<ServiceHistoryViewModel> ();
           foreach(var item in sr)
           {
                ServiceHistoryViewModel l = new ServiceHistoryViewModel();
                l.ServiceId = item.ServiceRequestId;
                l.ServiceProvideId = item.ServiceProviderId;
                if(l.ServiceProvideId != null)
                {
                    User u = _helperlandsContext.User.Where(x => x.UserId == l.ServiceProvideId).FirstOrDefault();
                    l.ServiceProviderName = u.FirstName + " " + u.LastName;
                }
                l.StartDate = item.ServiceStartDate.ToString("dd/MM/yyyy");
                l.Payment = item.TotalCost;
                l.Rating = _iRatingRepository.GetRating(item.ServiceProviderId);
                csv.Add(l);
           }
           return csv;
        }
        #endregion Get all services by UserID

        #region GetServiceDetails from ServiceRequestID
        public object GetServiceDetails(int serviceRequestId)
        {
            ServiceRequest sr = _helperlandsContext.ServiceRequest.Where(x => x.ServiceRequestId == serviceRequestId).FirstOrDefault();

            List<ServiceRequestExtra> sre = _helperlandsContext.ServiceRequestExtra.Where(x => x.ServiceRequestId == serviceRequestId).ToList();
            ServiceRequestAddress sra= _helperlandsContext.ServiceRequestAddress.Where(x => x.ServiceRequestId == serviceRequestId).FirstOrDefault();
            string name = "";
            User u = _helperlandsContext.User.Where(x => x.UserId == sr.UserId).FirstOrDefault();
            if (sr.ServiceProviderId != null)
            {
                User user = _helperlandsContext.User.Where(x => x.UserId == sr.ServiceProviderId).FirstOrDefault();
                name= user.FirstName + " " + user.LastName;
            }
            
            string extra = "";
            foreach(var i in sre)
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
                ServiceProviderId=sr.ServiceProviderId,
                Comments = sr.Comments,
                Haspet = sr.HasPets,
                ServiceProviderName = name,
                Rating = _iRatingRepository.GetRating(sr.ServiceProviderId)
            };
            return temp;
            
        }
        #endregion GetServiceDetails from ServiceRequestID

        #region Get Service Request Date
        public string GetServiceDate(int serviceRequestId)
        {
            ServiceRequest sr = _helperlandsContext.ServiceRequest.Where(x => x.ServiceRequestId == serviceRequestId).FirstOrDefault();
            return sr.ServiceStartDate.ToString("yyyy-MM-dd");
        }
        #endregion Get Service Request Date

        #region Update Service Date
        public bool UpdateServiceDate(int serviceRequestId,DateTime serviceDate)
        {
            ServiceRequest request=_helperlandsContext.ServiceRequest.Where(x => x.ServiceRequestId == serviceRequestId).FirstOrDefault();

            if (request.ServiceProviderId == null)
            {
                request.ServiceStartDate = serviceDate;
                _helperlandsContext.ServiceRequest.Update(request);
                _helperlandsContext.SaveChanges();
                return true;
            }
            else
            {
                ServiceRequest sr = _helperlandsContext.ServiceRequest.Where(x => x.ServiceProviderId == request.ServiceProviderId && x.ServiceStartDate == serviceDate).FirstOrDefault();
                if (sr == null)
                {
                    User user = _helperlandsContext.User.Where(x => x.UserId == request.ServiceProviderId).FirstOrDefault();
                    string welcomeMessage = "Welcome to Helperland,   <br/> Service Date chanege for Service Request no " + request.ServiceRequestId +" <br/> <b> Check it now <b>";

                    String To = user.Email;
                    String subject = "Service Request Date Change";
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
                    request.ServiceStartDate = serviceDate;
                    _helperlandsContext.ServiceRequest.Update(request);
                    _helperlandsContext.SaveChanges();
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
        public bool CancelService(int serviceRequestId, string message)
        {
            ServiceRequest sr = _helperlandsContext.ServiceRequest.Where(x => x.ServiceRequestId == serviceRequestId).FirstOrDefault();
            sr.Status = 1;
            try
            {
                _helperlandsContext.ServiceRequest.Update(sr);
                _helperlandsContext.SaveChanges();
                if(sr.ServiceProviderId != null)
                {
                    string welcomeMessage = "Welcome to Helperland,   <br/> Service Request no  " + sr.ServiceRequestId + " is canceled due to below reason. <br/>" + message;
                    User user = _helperlandsContext.User.Where(x => x.UserId == sr.ServiceProviderId).FirstOrDefault();
                    String To = user.Email;
                    String subject = "Cancellation of Service Request";
                    String Body = "X Cancel X " + " : " + welcomeMessage;
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

                }

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region Get all services history 
        public List<ServiceHistoryViewModel> GetServicesHistoryByUserId(int userID)
        {
            List<ServiceRequest> sr = _helperlandsContext.ServiceRequest.Where(x => x.UserId == userID && x.Status != null).ToList();
            List<ServiceHistoryViewModel> csv = new List<ServiceHistoryViewModel>();
            foreach (var item in sr)
            {
                ServiceHistoryViewModel l = new ServiceHistoryViewModel();
                l.ServiceId = item.ServiceRequestId;
                l.ServiceProvideId = item.ServiceProviderId;
                if (l.ServiceProvideId != null)
                {
                    User u = _helperlandsContext.User.Where(x => x.UserId == l.ServiceProvideId).FirstOrDefault();
                    l.ServiceProviderName = u.FirstName + " " + u.LastName;
                }
                l.StartDate = item.ServiceStartDate.ToString("dd/MM/yyyy");
                l.Payment = item.TotalCost;
                l.Status = item.Status;
                if(l.Status == 2)
                {
                    l.Rate = false;

                }
                else
                {
                    Rating rating = _helperlandsContext.Rating.Where(x => x.ServiceRequestId == item.ServiceRequestId).FirstOrDefault();
                    if (rating == null)
                        l.Rate = true;
                    else
                        l.Rate = false;
                }

                l.Rating = _iRatingRepository.GetRating(item.ServiceProviderId);
                csv.Add(l);
            }
            return csv;
        }
        #endregion

        #region Get Service Request Which is not Accepted
        public List<NewServiceRequestViewModel> GetServiceRequestsNotAccepted(int userId,bool hasPate)
        {
            User u = _helperlandsContext.User.Where(x => x.UserId == userId).FirstOrDefault();
            List<ServiceRequest> sr = _helperlandsContext.ServiceRequest.Where(x => x.Status == null && x.ServiceProviderId == null && x.ZipCode == u.ZipCode && x.HasPets == hasPate).ToList();
            List<NewServiceRequestViewModel> newServiceRequestViewModels = new List<NewServiceRequestViewModel>();
          
            foreach (var item in sr)
            {
                NewServiceRequestViewModel l = new NewServiceRequestViewModel();
                l.ServiceRequestID = item.ServiceRequestId;
                l.ServicestarDate = item.ServiceStartDate.ToString("dd/MM/yyyy");
                l.Payment = item.TotalCost;
                User user = _helperlandsContext.User.Where(x => x.UserId == item.UserId).FirstOrDefault();
                l.CustomerName = user.FirstName + " " + user.LastName;
                ServiceRequestAddress adress = _helperlandsContext.ServiceRequestAddress.Where(x => x.ServiceRequestId == item.ServiceRequestId).FirstOrDefault();
                l.Addressline1 = adress.AddressLine1 + " " + adress.AddressLine2;
                City city = _helperlandsContext.City.Where(x => x.Id == adress.CityId).FirstOrDefault();
                l.Addressline2 = adress.PostalCode+" "+city.CityName;
                newServiceRequestViewModels.Add(l);
            }
            newServiceRequestViewModels.Reverse();
            return newServiceRequestViewModels;

        }
        #endregion

        #region Get Service Details for ServiceProvider
        public object GetServiceDetailsforServiceProvider(int serviceRequestId)
        {
            ServiceRequest sr = _helperlandsContext.ServiceRequest.Where(x => x.ServiceRequestId == serviceRequestId).FirstOrDefault();

            List<ServiceRequestExtra> sre = _helperlandsContext.ServiceRequestExtra.Where(x => x.ServiceRequestId == serviceRequestId).ToList();
            ServiceRequestAddress sra = _helperlandsContext.ServiceRequestAddress.Where(x => x.ServiceRequestId == serviceRequestId).FirstOrDefault();
            User u = _helperlandsContext.User.Where(x => x.UserId == sr.UserId).FirstOrDefault();
            City city = _helperlandsContext.City.Where(x => x.Id == sra.CityId).FirstOrDefault();
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
                Address = sra.AddressLine1 + " , " + sra.AddressLine2 + " , " + sra.PostalCode + " ," +city.CityName,
                ServiceProviderId = sr.ServiceProviderId,
                Comments = sr.Comments,
                Haspet = sr.HasPets,
                CustomerName =u.FirstName+ " "+ u.LastName
            };
            return temp;

        }
        #endregion Get Service Details for ServiceProvider

        #region Accept Service Request 
        public string AcceptServiceRequest(int userId,int serviceRequestId)
        {
            ServiceRequest sr = _helperlandsContext.ServiceRequest.Where(x => x.ServiceRequestId == serviceRequestId).FirstOrDefault();
            if(sr.ServiceProviderId != null)
            {
                return "This service request is no more available. It has been assigned to another provider.";
            }
            else
            {
                ServiceRequest s = _helperlandsContext.ServiceRequest.Where(x => x.ServiceProviderId == userId && x.Status == 2 && x.ServiceStartDate == sr.ServiceStartDate).FirstOrDefault();
                if(s != null)
                {
                    return "Another service request  has already been assigned which has time overlap with this service request. You can’t pick this one!";
                }
                else
                {
                    sr.ServiceProviderId = userId;
                    sr.SpacceptedDate = DateTime.Now;
                    sr.Status = 3;
                    _helperlandsContext.ServiceRequest.Update(sr);
                    _helperlandsContext.SaveChanges();
                     User user = _helperlandsContext.User.Where(x => x.UserId == userId).FirstOrDefault();
                    string welcomeMessage = "Welcome to Helperland,   <br/> Your Service is accpted by  " + user.FirstName + " "+user.LastName + " <br/> <b> Check it now <b>";
                    User u = _helperlandsContext.User.Where(x => x.UserId == sr.UserId).FirstOrDefault();
                    String To = u.Email;
                    String subject = "Service Request accepted";
                    String Body = "Service Accepted " + " : " + welcomeMessage;
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
                    return "true";
                }
            }

        }
        #endregion Accept Service Request 

        #region Upcoming Services Which is Accepted
        public List<NewServiceRequestViewModel> GetServiceRequestsIsAccepted(int userId)
        {
            User u = _helperlandsContext.User.Where(x => x.UserId == userId).FirstOrDefault();
            List<ServiceRequest> sr = _helperlandsContext.ServiceRequest.Where(x => x.Status == 3 && x.ServiceProviderId == userId).ToList();
            List<NewServiceRequestViewModel> newServiceRequestViewModels = new List<NewServiceRequestViewModel>();
            foreach (var item in sr)
            {
                NewServiceRequestViewModel l = new NewServiceRequestViewModel();
                l.ServiceRequestID = item.ServiceRequestId;
                l.ServicestarDate = item.ServiceStartDate.ToString("dd/MM/yyyy");
                l.Payment = item.TotalCost;
                User user = _helperlandsContext.User.Where(x => x.UserId == item.UserId).FirstOrDefault();
                l.CustomerName = user.FirstName + " " + user.LastName;
                ServiceRequestAddress adress = _helperlandsContext.ServiceRequestAddress.Where(x => x.ServiceRequestId == item.ServiceRequestId).FirstOrDefault();
                l.Addressline1 = adress.AddressLine1 + " " + adress.AddressLine2;
                City city = _helperlandsContext.City.Where(x => x.Id == adress.CityId).FirstOrDefault();
                l.Addressline2 = adress.PostalCode + " " + city.CityName;
                newServiceRequestViewModels.Add(l);
            }
            newServiceRequestViewModels.Reverse();
            return newServiceRequestViewModels;

        }
        #endregion Upcoming Services Which is Accepted

        #region Completed Service Request
        public bool CompletedService(int serviceRequestId)
        {
            ServiceRequest serviceRequest = _helperlandsContext.ServiceRequest.Where(x => x.ServiceRequestId == serviceRequestId).FirstOrDefault();
            serviceRequest.Status = 1;
            _helperlandsContext.ServiceRequest.Update(serviceRequest);
            _helperlandsContext.SaveChanges();

            User user = _helperlandsContext.User.Where(x => x.UserId == serviceRequest.UserId).FirstOrDefault();
            string welcomeMessage = "Welcome to Helperland,   <br/> Your Service Request with id   "+ serviceRequest.ServiceRequestId.ToString()+" is Completed. ";
            String To = user.Email;
            String subject = "Completed Service Request";
            String Body = "Service Completed Hope you enjoy " + " : " + welcomeMessage;
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
            return true;
        }
        #endregion Completed Service Request

        #region Cancelled Service Request From Service Provider
        public bool CancelServiceRequest(int serviceRequestId,string message)
        {
            ServiceRequest serviceRequest = _helperlandsContext.ServiceRequest.Where(x => x.ServiceRequestId == serviceRequestId).FirstOrDefault();
            serviceRequest.Status = 1;
            _helperlandsContext.ServiceRequest.Update(serviceRequest);
            _helperlandsContext.SaveChanges();

            User user = _helperlandsContext.User.Where(x => x.UserId == serviceRequest.UserId).FirstOrDefault();
            string welcomeMessage = "Welcome to Helperland,   <br/> Your Service Request with id   " + serviceRequest.ServiceRequestId.ToString() + " is canceled due to  <b>" + message+" </b>." ;
            String To = user.Email;
            String subject = "Cancelled service request";
            String Body = "Cancelled because of " + " : " + welcomeMessage;
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
            return true;
        }
        #endregion Cancelled Service Request From Service Provider

        #region Service History
        public List<SPServiceHistoryViewModel> GetServiceHistoryForServiceProvider(int userID)
        {
            List<ServiceRequest> sr = _helperlandsContext.ServiceRequest.Where(x => x.ServiceProviderId == userID && x.Status == 2).ToList();
            List<SPServiceHistoryViewModel> li = new List<SPServiceHistoryViewModel>();
            foreach(var item in sr)
            {
                User u = _helperlandsContext.User.Where(x => x.UserId == item.UserId).FirstOrDefault();
                ServiceRequestAddress sra= _helperlandsContext.ServiceRequestAddress.Where(x => x.ServiceRequestId == item.ServiceRequestId).FirstOrDefault();
                City c = _helperlandsContext.City.Where(x => x.Id == sra.CityId).FirstOrDefault();
                SPServiceHistoryViewModel temp = new SPServiceHistoryViewModel();
                temp.ServiceRequestId = item.ServiceRequestId;
                temp.ServiceDate = item.ServiceStartDate.ToString("dd/MM/yyyy");
                temp.CustomerName = u.FirstName + " " + u.LastName;
                temp.AddressLine1 = sra.AddressLine1 + " ," + sra.AddressLine2;
                temp.AddressLine2 = sra.PostalCode + "," + c.CityName;
                li.Add(temp);

            }
            return li;
        }
        #endregion Service History
    }
}
