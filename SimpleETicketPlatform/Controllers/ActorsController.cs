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
        public async Task<IActionResult> Index()
        {
            var model = await actorsService.GetAllActorsAsync();
            return View(model);
        }
    }
}
