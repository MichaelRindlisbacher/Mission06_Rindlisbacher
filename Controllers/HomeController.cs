using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult SubmitMovie() // pull the information from the viewbag and display the page
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("SubmitMovie", new Movie());
        }

        [HttpPost]
        public IActionResult SubmitMovie(Movie response) // Send the new record to the database
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response); // Add record to the database
                _context.SaveChanges();

                return View("Confirmation");
            }
            else
            {
                ViewBag.Categories = _context.Categories
                    .OrderBy(x => x.CategoryName)
                    .ToList();

                return View(response); // Bring it back and display the errors
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Movies() // grab all movies from the database and pull them in to display
        {
            var Movies = _context.Movies
                .Include(x => x.Category) // pull in the information from the category table as well
                .Where(x => true)
                .ToList();

            return View(Movies);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName)
            .ToList();

            var recordToEdit = _context.Movies
                .Single(x => x.MovieID == id); // load the info from the specific record

            return View("SubmitMovie", recordToEdit); // grab same info from submit movie action
        }

        [HttpPost]
        public IActionResult Edit(Movie UpdatedInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Update(UpdatedInfo);
                _context.SaveChanges();

                return RedirectToAction("Movies");
            }
            else
            {
                return RedirectToAction("Edit"); // Start them over until it's valid
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var MovieToDelete = _context.Movies
                .Single(x => x.MovieID == id);

            return View(MovieToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movie recordToDelete)
        {
            _context.Movies.Remove(recordToDelete);
            _context.SaveChanges();

            return RedirectToAction("Movies");
        }
    }
}
