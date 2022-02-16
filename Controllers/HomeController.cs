using BaconsaleMovieCollection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BaconsaleMovieCollection.Controllers
{
    public class HomeController : Controller
    {
        private MoviesContext moviesContext { get; set; }

        public HomeController(MoviesContext movies)
        {
            moviesContext = movies;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            ViewBag.Categories = moviesContext.categories.ToList();
            return View(new ApplicationResponse());
        }

        [HttpPost]
        public IActionResult AddMovie(ApplicationResponse model)
        {
            if (ModelState.IsValid)
            {
                moviesContext.Add(model);
                moviesContext.SaveChanges();
                return View("ConfirmationPage", model);
            }
            else
            {
                ViewBag.Categories = moviesContext.categories.ToList();
                return View(model);
            }
            
        }

        [HttpGet]
        public IActionResult MovieList()
        {
            var movies = moviesContext.responses
                .Include(x => x.Category) //include major object
                .OrderBy(x => x.Category.CategoryName)
                .ToList();
            return View(movies);
        }

        public IActionResult Baconsale()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = moviesContext.categories.ToList();
            var movie = moviesContext.responses.Single(x => x.ApplicationId == id);
            return View("AddMovie", movie);
        }

        [HttpPost]
        public IActionResult Edit(ApplicationResponse movieEdit)
        {
            if (ModelState.IsValid)
            {
                moviesContext.Update(movieEdit);
                moviesContext.SaveChanges();
                return RedirectToAction("MovieList");
            }
            else
            {
                return RedirectToAction("Edit");
            }
            
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = moviesContext.responses.Single(x => x.ApplicationId == id);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete( ApplicationResponse movieDelete)
        {
            moviesContext.responses.Remove(movieDelete);
            moviesContext.SaveChanges();
            return RedirectToAction("MovieList");
        }
    }
}
