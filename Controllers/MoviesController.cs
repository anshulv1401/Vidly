using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        public Movie Model;

        // GET: Movies/Random
        public ActionResult Index()
        {
            return View(GetMovies());
        }

        public ActionResult Details(int Id)
        {
            Model = GetMovies().Where(x => x.Id == Id).FirstOrDefault();

            if (Model == null)
                return HttpNotFound();
            else
                return View(Model);
        }

        public IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie() { Id = 1, Name = "Wall E" },
                new Movie() { Id = 2, Name = "Toy story 4" },
            };
        }
    }
}