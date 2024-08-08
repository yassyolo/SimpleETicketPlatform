using Microsoft.AspNetCore.Mvc;
using SimpleETicketPlatform.Core.Contacts;
using SimpleETicketPlatform.Core.Models.Home;
using SimpleETicketPlatform.Models;
using System.Diagnostics;

namespace SimpleETicketPlatform.Controllers
{
    public class HomeController : Controller
    {
        private readonly IActorsService actorsService;
        private readonly IMoviesService moviesService;
        private readonly IProducersService producersService;
        private readonly ICinemasService cinemaService;

        public HomeController(IActorsService actorsService, IMoviesService moviesService, IProducersService producersService, ICinemasService cinemaService)
        {
            this.actorsService = actorsService;
            this.moviesService = moviesService;
            this.producersService = producersService;
            this.cinemaService = cinemaService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new IndexViewModel();
            model.Actors = await actorsService.GetActorsNamesAsync();
            model.Producers = await producersService.GetProducerNamesAsync();
            model.Cinemas = await cinemaService.GetCinemaNamesAsync();
            model.Movies = await moviesService.GetMoviesForIndexPageAsync();
            return View(model);
        }
        public IActionResult NotFound()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
