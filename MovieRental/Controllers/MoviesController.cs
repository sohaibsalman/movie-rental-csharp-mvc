using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieRental.Models;
using MovieRental.ViewModels;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;

namespace MovieRental.Controllers
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
            _context.Dispose();
        }

        // GET: Movies
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.ID == id);
            return View(movie);
        }

        public ActionResult New()
        {
            var genre = _context.Genre.ToList();

            var viewModel = new MovieFormViewModel()
            {
                Movie = new Movies(),
                Genre = genre
            };
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movies movie)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel
                {
                    Movie = movie,
                    Genre = _context.Genre.ToList()
                };

                return View("MovieForm", viewModel);
            }
            if(movie.ID == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.ID == movie.ID);
                movieInDb.Name = movie.Name;
                movieInDb.RelaseDate = movie.RelaseDate;
                movieInDb.Genre = movie.Genre;
                movieInDb.NoOfStock = movie.NoOfStock;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.ID == id);

            if (movie == null)
                return HttpNotFound();

            var genre = _context.Genre.ToList();

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genre = genre
            };

            return View("MovieForm", viewModel);
        }










        //GET: Movies/Random
        public ActionResult Random()
        {
            Movies movie = new Movies
            {
                Name = "The Imitation Game",
                ID = 1
            };

            List<Customers> customers = new List<Customers>
            {

            };

            RandomMovieViewModel viewModel = new RandomMovieViewModel();
            viewModel.Movie = movie;
            viewModel.Customers = customers;

            return View(viewModel);
        }
    }
}