using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var customers = _context.Customers.Include(x => x.MembershipType).ToList();
            return View(customers);
        }

        public ActionResult Details(int Id)
        {
            var Model = _context.Customers.Include(x => x.MembershipType).SingleOrDefault(x => x.Id == Id);

            if(Model == null)
                return HttpNotFound();            
            else
                return View(Model);
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewmodel = new NewCustomersViewModel()
            {
                MembershipTypes = membershipTypes
            };
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
    }
}