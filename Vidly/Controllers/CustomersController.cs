using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        public Customer Model;
        public ActionResult Index()
        {
            return View(GetCustomers());
        }

        public ActionResult Details(int Id)
        {
            Model = GetCustomers().Where(x => x.Id == Id).FirstOrDefault();

            if(Model == null)
                return HttpNotFound();            
            else
                return View(Model);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "Anshul Vanawat" },
                new Customer { Id = 2, Name = "Anjali Jain" }
            };
        }
    }
}