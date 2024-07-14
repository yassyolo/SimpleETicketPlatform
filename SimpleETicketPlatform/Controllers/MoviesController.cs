using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SimpleETicketPlatform.Core.Contacts;
using SimpleETicketPlatform.Core.Models.Movies;

namespace SimpleETicketPlatform.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService moviesService;

        public MoviesController(IMoviesService moviesService)
        {
            this.moviesService = moviesService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await moviesService.GetAllMoviesAsync();
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (await moviesService.MovieExistsWithId(id) == false)
            {
                TempData["Message"] = "Movie not found!";
                return RedirectToAction("NotFound", "Home");
            }
            var model = await moviesService.GetDetailsForMovie(id);
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var dropdownLists = await moviesService.GetNewMovieDropdowns();
            ViewBag.CinemaId = new SelectList(dropdownLists.Cinemas, "Id", "Name");
			ViewBag.ProducerId = new SelectList(dropdownLists.Producers, "Id", "FullName");
			ViewBag.ActorId = new SelectList(dropdownLists.Actors, "Id", "FullName");
			var model = new MovieFormViewModel();
            return View(model);
        }
        [HttpPost]
		public async Task<IActionResult> Add(MovieFormViewModel model)
		{
            if (ModelState.IsValid == false)
            {
                return View(model);
            }
            await moviesService.AddNewMovieAsync(model);
			return RedirectToAction(nameof(Index));
		}
		[HttpGet]
        public async Task<IActionResult> Filter([FromQuery] FilteredMoviesViewModel query)
        {
            var model = await moviesService.FilterMoviesAsync(query.SearchTerm);
            query.Movies = model.Movies;
            query.MoviesMatched = model.MoviesMatched;
            return View(query);
        }
    }
}
