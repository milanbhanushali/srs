﻿using Helperland.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Repository
{
    public interface IFavouriteAndBlockRepository
    {
        public List<BlockCustomerViewModel> GetListOfCustomer(int userId);
        public bool UnblockCustomer(int userId, int targetUserId);
        public bool BlockCustomer(int userId, int targetUserId);
    }
}
