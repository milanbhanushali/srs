using Helperland.Data;
using Helperland.Models;
using Helperland.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Repository
{
    public class FavouriteAndBlockRepository : IFavouriteAndBlockRepository
    {
        private readonly HelperlandsContext _helperlandsContext;
        public FavouriteAndBlockRepository(HelperlandsContext helperlandsContext)
        {
            _helperlandsContext = helperlandsContext;
        }

        #region Get List of All Customer
        public List<BlockCustomerViewModel> GetListOfCustomer(int userId)
        {
            List<BlockCustomerViewModel> lists = new List<BlockCustomerViewModel>();
            List<ServiceRequest> li = _helperlandsContext.ServiceRequest.Where(x=>x.ServiceProviderId== userId).ToList();
            foreach(var item in li)
            {
                try
                {
                    User user = _helperlandsContext.User.Where(x => x.UserId == item.UserId).FirstOrDefault();
                    BlockCustomerViewModel temp = new BlockCustomerViewModel();
                    FavoriteAndBlocked favoriteAndBlocked = _helperlandsContext.FavoriteAndBlocked.Where(x => x.UserId==item.ServiceProviderId && x.TargetUserId == item.UserId).FirstOrDefault();
                    if (favoriteAndBlocked == null)
                    {
                        temp.UserId = user.UserId;
                        temp.Username = user.FirstName + " " + user.LastName;
                        temp.IsBlock = false;
                    }
                    else
                    {
                        temp.UserId = user.UserId;
                        temp.Username = user.FirstName + " " + user.LastName;
                        temp.IsBlock = favoriteAndBlocked.IsBlocked;
                    }
                    bool alreadyExists = lists.Any(x => x.UserId == temp.UserId);
                    if (!alreadyExists)
                    {
                        lists.Add(temp);
                    }
                }
                catch(Exception ex)
                {
                    return lists;
                }   
            }
            return lists;
        }
        #endregion

        #region Block Customer
        public bool BlockCustomer(int userId,int targetUserId)
        {
            FavoriteAndBlocked favoriteAndBlocked = _helperlandsContext.FavoriteAndBlocked.Where(x => x.UserId == userId && x.TargetUserId == targetUserId).FirstOrDefault();
            if(favoriteAndBlocked == null)
            {
                favoriteAndBlocked = new FavoriteAndBlocked();
                favoriteAndBlocked.UserId = userId;
                favoriteAndBlocked.TargetUserId = targetUserId;
                favoriteAndBlocked.IsFavorite = false;
                favoriteAndBlocked.IsBlocked = true;
                _helperlandsContext.FavoriteAndBlocked.Add(favoriteAndBlocked);
                _helperlandsContext.SaveChanges();
            }
            else
            {
                favoriteAndBlocked.IsFavorite = false;
                favoriteAndBlocked.IsBlocked = true;
                _helperlandsContext.FavoriteAndBlocked.Update(favoriteAndBlocked);
                _helperlandsContext.SaveChanges();
            }
            return true;
        }
        #endregion

        #region Unblock  Customer
        public bool UnblockCustomer(int userId, int targetUserId)
        {
            FavoriteAndBlocked favoriteAndBlocked = _helperlandsContext.FavoriteAndBlocked.Where(x => x.UserId == userId && x.TargetUserId == targetUserId).FirstOrDefault();
            if (favoriteAndBlocked == null)
            {
                favoriteAndBlocked = new FavoriteAndBlocked();
                favoriteAndBlocked.UserId = userId;
                favoriteAndBlocked.TargetUserId = targetUserId;
                favoriteAndBlocked.IsFavorite = false;
                favoriteAndBlocked.IsBlocked = false;
                _helperlandsContext.FavoriteAndBlocked.Add(favoriteAndBlocked);
                _helperlandsContext.SaveChanges();
            }
            else
            {
                favoriteAndBlocked.IsFavorite = false;
                favoriteAndBlocked.IsBlocked = false;
                _helperlandsContext.FavoriteAndBlocked.Update(favoriteAndBlocked);
                _helperlandsContext.SaveChanges();
            }
            return true;
        }
        #endregion
    }
}
