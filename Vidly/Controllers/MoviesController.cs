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
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _context.Dispose();
        }


        // GET: Movies/Random
        public ActionResult Index()
        {
            List<Movie> movies = _context.Movies.Include(x => x.Genre).ToList();
            return View(movies);
        }

        public ActionResult Details(int Id)
        {
            var Model = _context.Movies.Include(x => x.Genre).SingleOrDefault(x => x.Id == Id);

            if (Model == null)
                return HttpNotFound();
            else
                return View(Model);
        }
    }
}