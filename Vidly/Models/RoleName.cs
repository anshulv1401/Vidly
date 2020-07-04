using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public static class RoleName
    {
        public const string CanManageAll = "CanManageAll";
        public const string CanManageMovies = "CanManageMovie";
        public const string CanManageCustomers = "CanManageCustomers";
        public const string CanManageRentalTransactions = "CanManageRentalTransactions";
        public const string MovieManager = CanManageMovies + "," + CanManageAll;
        public const string CustomerManager = CanManageCustomers + "," + CanManageAll;
        public const string RentalTransactionManager = CanManageCustomers + "," + CanManageAll + "," + CanManageRentalTransactions;
    }
}