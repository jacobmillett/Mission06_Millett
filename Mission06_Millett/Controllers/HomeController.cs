using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Millett.Models;
using System.Diagnostics;

namespace Mission06_Millett.Controllers
{
    //Linking the database
    public class HomeController : Controller
    {
        private EnterNewMovieContext _context;

        public HomeController(EnterNewMovieContext someMovie) 
        {
            _context = someMovie;
        }


        //index controller
        public IActionResult Index()
        {

            return View();
        }
        //Get to know Joel controller
        public IActionResult GetToKnowJoel()
        {
            return View();
        }
        // Get side of the Enter a new movie controller
        [HttpGet]
        public IActionResult EnterNewMovie()
        {
            ViewBag.Categories = _context.Categories
             .OrderBy(x => x.CategoryName)
             .ToList();
            return View();
        }
        // Post side of the Enter a new movie controller
        [HttpPost]
        public IActionResult EnterNewMovie(EnterNewMovie response)
        {
            if (response.Title != null && response.Edited != null && response.CopiedToPlex != null) 
            {
                // Ensure the year is not less than 1888
                if (response.Year < 1888)
                {
                    ModelState.AddModelError(nameof(response.Year), "The year must be 1888 or later.");
                }
                else
                {
                    _context.Movies.Add(response);
                    _context.SaveChanges();
                    return RedirectToAction("MovieList"); // Redirect to the movie list page after successful addition
                }
            }
            else
            {
                ModelState.AddModelError("", "The Title, Edited, and Copied to Plex fields are required.");
            }

            // Populate ViewBag.Categories regardless of ModelState validity
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("EnterNewMovie", response); // Return the view with the model to display validation errors
        }
        public IActionResult MovieList()
        {
            var Movies = _context.Movies
                .Include(x => x.Category)
                .OrderBy(x => x.Title).ToList();

            return View(Movies);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
             var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
            return View("EnterNewMovie", recordToEdit);
        }

        [HttpPost]

        public IActionResult Edit(EnterNewMovie movie)
        {
            _context.Update(movie);
            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);
            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(EnterNewMovie movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return RedirectToAction("MovieList");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
