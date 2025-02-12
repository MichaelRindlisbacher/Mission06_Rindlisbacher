using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Rindlisbacher.Models;

namespace Mission06_Rindlisbacher.Controllers
{
    public class HomeController : Controller
    {

        private MovieContext _context;

        public HomeController(MovieContext temp) //Constructor
        { 
            _context = temp;
        }

        public IActionResult AboutJoel()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SubmitMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitMovie(Movie response)
        {
            _context.Movies.Add(response); // Add record to the database
            _context.SaveChanges();

            return View("Confirmation");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
