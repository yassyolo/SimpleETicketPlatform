using Microsoft.AspNetCore.Mvc;
using SimpleETicketPlatform.Core.Contacts;

namespace SimpleETicketPlatform.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemasService cinemaService;

        public CinemasController(ICinemasService cinemaService)
        {
            this.cinemaService = cinemaService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
