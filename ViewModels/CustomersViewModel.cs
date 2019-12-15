using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomersViewModel
    {
        public Customer ShowCustomer { get; set; }
        public List<Customer> Customers { get; set; }
        public Customer GetCustomer(int Id)
        {
            if(Customers != null && Customers.Count > 0)
               return Customers.Where(x => x.Id == Id).FirstOrDefault();
            return null;
        }
    }
}