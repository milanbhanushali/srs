using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Helperland.Models;

namespace Helperland.Repository
{
    public interface IBookServiceRepository
    {
        public string Message();

        public Boolean IsPincodeAvailable(string strZipcode);
    }
}
