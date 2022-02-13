using Helperland.Data;
using Helperland.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Repository
{
    public class InsertUserRepository : IInsertUserRepository
    {
        private readonly HelperlandsContext _context = null;
        public string ExceptionMessage;
        public InsertUserRepository(HelperlandsContext context)
        {
            _context = context;
        }

        public int AddNewUser(User user)
        {
            try
            {
                var newUser = new User()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Password = user.Password,
                    Mobile = user.Mobile,
                    CreatedDate = DateTime.UtcNow,
                    ModifiedDate = DateTime.UtcNow,
                    UserTypeId = 0,
                    IsRegisteredUser = true,
                    WorksWithPets = false,
                    IsApproved = true,
                    IsActive = true,
                    IsDeleted = true
                };
                _context.User.Add(newUser);
                
                _context.SaveChanges();

                return newUser.UserId;
            }
            catch(Exception ex)
            {
                ExceptionMessage = ex.Message.ToString();
                return 0;
            }
            
        }
        public string Message()
        {
            throw new NotImplementedException();
        }
    }
}
