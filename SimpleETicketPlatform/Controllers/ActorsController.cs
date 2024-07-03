using Microsoft.AspNetCore.Mvc;
using SimpleETicketPlatform.Core.Contacts;

namespace SimpleETicketPlatform.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService actorsService;
        public ActorsController(IActorsService actorsService)
        {
            this.actorsService = actorsService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
