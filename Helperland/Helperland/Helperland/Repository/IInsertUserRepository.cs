using Helperland.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Repository
{
    public interface IInsertUserRepository
    {
        public string Message();

        public int AddNewUser(User user);
    }
}
