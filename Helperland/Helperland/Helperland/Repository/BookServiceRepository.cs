using Helperland.Data;
using Helperland.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Repository
{
    public class BookServiceRepository : IBookServiceRepository
    {

        public HelperlandsContext _helperlandsContext;
        public string _Message { get; set; }
        public BookServiceRepository(HelperlandsContext helperlandsContext)
        {
            _helperlandsContext = helperlandsContext;
        }

        

        public string Message()
        {
            throw new NotImplementedException();
        }
        public bool IsPincodeAvailable(string strZipcode)
        {
            try
            {
                User objUser = _helperlandsContext.User.Where(x => x.ZipCode == strZipcode).FirstOrDefault();
                if (objUser != null)
                {
                    return true;
                }
                else
                {
                    _Message += " Invalid Zipcode";
                    return false;
                }
            }
            catch (Exception ex)
            {
                _Message += ex.Message;
                return false;
            }
        }

    }
}
