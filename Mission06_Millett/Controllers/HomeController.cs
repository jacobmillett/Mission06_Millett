using Microsoft.AspNetCore.Mvc;
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
            return View();
        }
        // Post side of the Enter a new movie controller
        [HttpPost]
        public IActionResult EnterNewMovie(EnterNewMovie response)
        {

            _context.Movies.Add(response);
            _context.SaveChanges();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
