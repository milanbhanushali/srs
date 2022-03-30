using Helperland.Data;
using Helperland.Models;
using Helperland.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Helperland.Repository
{
    public class AdminUserManagementRepository : IAdminUserManagementRepository
    {
        #region variables
        public HelperlandsContext _helperlandsContext;
        private readonly IRatingRepository _iRatingRepository;
        #endregion variables

        #region Constructor
        public AdminUserManagementRepository(HelperlandsContext helperlandsContext, IRatingRepository ratingRepository)
        {
            _helperlandsContext = helperlandsContext;
            _iRatingRepository = ratingRepository;
        }
        #endregion Constructor

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

        #region Get All Services
        public List<AdminServiceHistoryViewModel> GetAllServiceListForAdmin()
        {
            List<ServiceRequest> arrServiceRequest = _helperlandsContext.ServiceRequest.Include(x => x.ServiceRequestAddress).ToList();
            List<AdminServiceHistoryViewModel> list = new List<AdminServiceHistoryViewModel>();
            foreach (var item in arrServiceRequest)
            {
                AdminServiceHistoryViewModel temp = new AdminServiceHistoryViewModel();
                User Customer = _helperlandsContext.User.Where(x => x.UserId == item.UserId).FirstOrDefault();
                if (item.ServiceProviderId != null)
                {
                    User ServiceProvider = _helperlandsContext.User.Where(x => x.UserId == item.ServiceProviderId).FirstOrDefault();
                    temp.ServiceRequestId = (int)item.ServiceProviderId;
                    temp.ServiceProviderName = ServiceProvider.FirstName + " " + ServiceProvider.LastName;
                    temp.Rating = (int)_iRatingRepository.GetRating(item.ServiceProviderId);
                    temp.Avatar = ServiceProvider.UserProfilePicture;
                }

                DateTime dt = DateTime.ParseExact(item.ServiceStartDate.ToString("dd/MM/yyyy"), "dd/MM/yyyy",null);
                temp.ServiceRequestId = item.ServiceRequestId;
                temp.ServiceDate = item.ServiceStartDate;
                temp.CustomerName = Customer.FirstName + " " + Customer.LastName;
                UserAddress address = _helperlandsContext.UserAddress.Where(x => x.UserId == item.UserId).FirstOrDefault();
                temp.CustomerAddressLine1 = address.AddressLine1;
                temp.CustomerAddressLine2 = address.AddressLine2;
                temp.NetAmount = item.TotalCost;
                temp.Status = item.Status;
                list.Add(temp);
            }
            return list;
        }
        #endregion Get All Services

        #region Get Service reqest details from Service RequestId 
        public object GetServiceDetails(int serviceRequestId)
        {
            ServiceRequest objServiceRequest = _helperlandsContext.ServiceRequest.Where(x => x.ServiceRequestId == serviceRequestId).FirstOrDefault();

            List<ServiceRequestExtra> arrServiceRequestExtra = _helperlandsContext.ServiceRequestExtra.Where(x => x.ServiceRequestId == serviceRequestId).ToList();
            ServiceRequestAddress objServiceRequestAddress = _helperlandsContext.ServiceRequestAddress.Where(x => x.ServiceRequestId == serviceRequestId).FirstOrDefault();
            string name = "" , avatar = "";
            User u = _helperlandsContext.User.Where(x => x.UserId == objServiceRequest.UserId).FirstOrDefault();
            if (objServiceRequest.ServiceProviderId != null)
            {
                User user = _helperlandsContext.User.Where(x => x.UserId == objServiceRequest.ServiceProviderId).FirstOrDefault();
                name = user.FirstName + " " + user.LastName;
                avatar = user.UserProfilePicture;
            }

            string extra = "";
            foreach (var i in arrServiceRequestExtra)
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
            var objServiceDetails = new
            {
                ServiceDate = objServiceRequest.ServiceStartDate.ToString("dd/MM/yyyy"),
                TotalHour = objServiceRequest.ServiceHours,
                Extra = extra,
                TotalCost = objServiceRequest.TotalCost,
                Address = objServiceRequestAddress.AddressLine1 + " , " + objServiceRequestAddress.AddressLine2 + " , " + objServiceRequestAddress.PostalCode,
                MobileNumber = objServiceRequestAddress.Mobile,
                Email = u.Email,
                ServiceProviderId = objServiceRequest.ServiceProviderId,
                Comments = objServiceRequest.Comments,
                Haspet = objServiceRequest.HasPets,
                ServiceProviderName = name,
                Rating = _iRatingRepository.GetRating(objServiceRequest.ServiceProviderId),
                Avatar = avatar
            };
            return objServiceDetails;

        }
        #endregion Get Service reqest details from Service RequestId 

        #region Get Service Request details for editing
        public object GetServiceDetailsForEditing(int serviceRequestId)
        {
            ServiceRequest sr = _helperlandsContext.ServiceRequest.Where(x => x.ServiceRequestId == serviceRequestId).FirstOrDefault();
            ServiceRequestAddress sra = _helperlandsContext.ServiceRequestAddress.Where(x => x.ServiceRequestId == serviceRequestId).FirstOrDefault();

            var temp = new
            {
                ServiceDate = sr.ServiceStartDate.ToString("yyyy/MM/dd"),
                StreetName = sra.AddressLine1,
                HouseNumber = sra.AddressLine2,
                Zipcode = sra.PostalCode,
                CityId = sra.CityId
            };
            return temp;

        }
        #endregion Get Service Request details for editing

        #region Update Service Request by Admin
        public Boolean UpdateServiceRequest(string serviceRequestID, string modalDate, string StreetName, string HouseNo, string PostalCode, string City, string Message)
        {
            try
            {
                ServiceRequest sr = _helperlandsContext.ServiceRequest.Where(x => x.ServiceRequestId == Convert.ToInt32(serviceRequestID)).FirstOrDefault();
                ServiceRequestAddress sra = _helperlandsContext.ServiceRequestAddress.Where(x => x.ServiceRequestId == Convert.ToInt32(serviceRequestID)).FirstOrDefault();
                bool reschedule = false;
                if (DateTime.Parse(modalDate) != sr.ServiceStartDate)
                {
                    reschedule = true;
                }
                sr.ServiceStartDate = DateTime.Parse(modalDate);
                sra.AddressLine1 = StreetName;
                sra.AddressLine2 = HouseNo;
                sra.CityId = Convert.ToInt32(City);
                sra.PostalCode = PostalCode;
                _helperlandsContext.ServiceRequest.Update(sr);
                _helperlandsContext.ServiceRequestAddress.Update(sra);
                _helperlandsContext.SaveChanges();
                if (reschedule)
                {
                    #region Send Mail to Customer
                    User customer = _helperlandsContext.User.Where(x => x.UserId == sr.UserId).FirstOrDefault();
                    string welcomeMessage = "Welcome to Helperland,   <br/> Your Service Request with id   " + sr.ServiceRequestId.ToString() + " is Reschedule on <b> " + DateTime.Parse(modalDate).ToString("dd/MM/yyyy") + " </b>. Due to this reason  <b>" + Message + ".<b/>";
                    String To = customer.Email;
                    String subject = "Reschedule Service Request";
                    String Body = "⌚" + " : " + welcomeMessage;
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
                    #endregion Send Mail to Customer 

                    #region Send Mail to Service Provider
                    if (sr.ServiceProviderId != null)
                    {
                        User ServiceProvider = _helperlandsContext.User.Where(x => x.UserId == sr.ServiceProviderId).FirstOrDefault();
                        string msg = "Welcome to Helperland,   <br/>  Service Request with id   " + sr.ServiceRequestId.ToString() + " is Reschedule on <b> " + DateTime.Parse(modalDate).ToString("dd/MM/yyyy") + "</b>. Due to this reason <b>" + Message + ".</b>";
                        String To1 = ServiceProvider.Email;
                        String subject1 = "Reschedule Service Request";
                        String Body1 = "⌚" + " : " + msg;
                        MailMessage obj1 = new MailMessage();
                        obj.To.Add(To1);
                        obj.Subject = subject1;
                        obj.Body = Body1;
                        obj.From = new MailAddress("dreamers96845@gmail.com");
                        obj.IsBodyHtml = true;
                        SmtpClient smtp1 = new SmtpClient("smtp.gmail.com");
                        smtp.Port = 587;
                        smtp.UseDefaultCredentials = true;
                        smtp.EnableSsl = true;
                        smtp.Credentials = new System.Net.NetworkCredential("dreamers96845@gmail.com", "goals@2022");
                        smtp.Send(obj);
                    }
                    #endregion Send Mail to Service Provider
                }
                return true;
            }
            catch(Exception ex)
            {
                string errMsg = ex.Message;
                return false;
            }
        }
        #endregion Update Service Request by Admin
    }
}
