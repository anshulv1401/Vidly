using System;
using System.Data.Entity;
using System.Linq;
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
            //List<Movie> movies = _context.Movies.Include(x => x.Genre).ToList();
            if(User.IsInRole(RoleName.CanManageMovies) || User.IsInRole(RoleName.CanManageAll))
                return View("List");

            return View("ReadOnlyList");
        }

        public ActionResult Details(int Id)
        {
            var Model = _context.Movies.Include(x => x.Genre).SingleOrDefault(x => x.Id == Id);

            if (Model == null)
                return HttpNotFound();
            else
                return View(Model);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        [Authorize(Roles = RoleName.CanManageAll)]
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewmodel = new MovieFormViewModel()
            {
                Genres = genres
            };
            return View("MovieForm", viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        [Authorize(Roles = RoleName.CanManageAll)]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.CreatedDate = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.Stock = movie.Stock;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        [Authorize(Roles = RoleName.CanManageAll)]
        public ActionResult Edit(int Id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == Id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }
    }
}