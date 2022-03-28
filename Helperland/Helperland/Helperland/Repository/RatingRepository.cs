using Helperland.Data;
using Helperland.Models;
using Helperland.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Repository
{
    public class RatingRepository : IRatingRepository
    {
        #region variable
        private HelperlandsContext _helperlandsContext;
        #endregion variable

        #region Constructor
        public RatingRepository(HelperlandsContext helperlandsContext)
        {
            _helperlandsContext = helperlandsContext;
        }
        #endregion Constructor

        #region Add Rating
        public bool AddRating(int serviceRequestId, decimal onTime, decimal friendly, decimal qualityOfService, string feedBack)
        {
            try
            {
                ServiceRequest sr = _helperlandsContext.ServiceRequest.Where(x => x.ServiceRequestId == serviceRequestId).FirstOrDefault();
                Rating rating = new Rating();
                rating.ServiceRequestId = sr.ServiceRequestId;
                rating.RatingFrom = sr.UserId;
                rating.RatingTo =(int) sr.ServiceProviderId;
                rating.Comments = feedBack;
                rating.OnTimeArrival = onTime;
                rating.Friendly = friendly;
                rating.QualityOfService = qualityOfService;
                decimal ratingAverage = (friendly + onTime + qualityOfService)/3 ;
                rating.Ratings = ratingAverage;
                rating.RatingDate = DateTime.Now;
                _helperlandsContext.Rating.Add(rating);
                _helperlandsContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion Add Rating

        #region Get Rating
        public decimal? GetRating(int? serviceProviderId)
        {
            if(serviceProviderId == null)
            {
                return null;
            }
            else
            {
                List<Rating> ratings = _helperlandsContext.Rating.Where(x => x.RatingTo == serviceProviderId).ToList();
                int i = 0;
                decimal sum = 0;
                foreach(var item in ratings)
                {
                    sum += item.Ratings;
                    i++;
                }
                if (i == 0)
                {
                    return 0;
                }
                else
                {
                    return (sum / i);
                }
                
            }
        }
        #endregion Get Rating

        #region Get Rating for Service Provider
        public List<RatingViewModel> GetRatingsForServiceProvider(int serviceproviderId)
        {
            List<RatingViewModel> ratingsViewModels = new List<RatingViewModel>();
            List<Rating> ratings = _helperlandsContext.Rating.Where(x => x.RatingTo == serviceproviderId).ToList();
            if (ratings != null)
            {
                foreach (var item in ratings)
                {
                    RatingViewModel r = new RatingViewModel();
                    User u = _helperlandsContext.User.Where(x => x.UserId == item.RatingFrom).FirstOrDefault();
                    ServiceRequest s = _helperlandsContext.ServiceRequest.Where(x => x.ServiceRequestId == item.ServiceRequestId).FirstOrDefault();
                    r.RatingID = item.RatingId;
                    r.CustomerName = u.FirstName + " " + u.LastName;
                    r.Comments = item.Comments;
                    r.Rating = item.Ratings;
                    r.ServiceRequestID = item.ServiceRequestId;
                    r.ServiceDate = s.ServiceStartDate.ToString("dd/MM/yyyy");
                    ratingsViewModels.Add(r);
                }
                return ratingsViewModels;
            }
            else
            {
                return null;
            }
        }
        #endregion Get Rating for Service Provider
    }
}
