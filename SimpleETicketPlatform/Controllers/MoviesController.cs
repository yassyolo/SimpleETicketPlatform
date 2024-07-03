using Microsoft.AspNetCore.Mvc;
using SimpleETicketPlatform.Core.Contacts;

namespace SimpleETicketPlatform.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService moviesService;

        public MoviesController(IMoviesService moviesService)
        {
            this.moviesService = moviesService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
