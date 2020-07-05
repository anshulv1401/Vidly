using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class RentalsController : Controller
    {
        [Authorize(Roles = RoleName.MovieManager)]
        public ActionResult New()
        {
            return View();
        }
    }
}