using Helperland.Data;
using Helperland.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Repository
{
    public class UserAddressRepository : IUserAddressRepository
    {
        private readonly HelperlandsContext _context = null;
        public string ExceptionMessage;

        public UserAddressRepository(HelperlandsContext context)
        {
            _context = context;
        }

        public int AddNewAddress(UserAddressRepository userAddress)
        {
            throw new NotImplementedException();
        }
        
        public string GetUserAddress(int userID)
        {
            var userAdd = from address in _context.UserAddress where address.UserId == userID select address;
            return userAdd.ToString();
        }

        public int GetUserID()
        {
            throw new NotImplementedException();
        }

        public string Message()
        {
            throw new NotImplementedException();
        }
    }
}
