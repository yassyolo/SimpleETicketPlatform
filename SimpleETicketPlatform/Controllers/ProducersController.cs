using Microsoft.AspNetCore.Mvc;
using SimpleETicketPlatform.Core.Contacts;

namespace SimpleETicketPlatform.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducersService producersService;

        public ProducersController(IProducersService producersService)
        {
            this.producersService = producersService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
