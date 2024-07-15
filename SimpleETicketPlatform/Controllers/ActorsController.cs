using Microsoft.AspNetCore.Mvc;
using SimpleETicketPlatform.Core.Contacts;
using SimpleETicketPlatform.Core.Models.Actors;

namespace SimpleETicketPlatform.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService actorsService;
        public ActorsController(IActorsService actorsService)
        {
            this.actorsService = actorsService;
        }
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] FilteredActorsViewModel query)
        {
            var model = await actorsService.GetAllActorsAsync(query.SearchTerm);
            query.ActorsMatched = model.ActorsMatched;
            query.Actors = model.Actors;
            
            return View(query);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new ActorFormViewModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(ActorFormViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }
            await actorsService.AddNewActorAsync(model);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (await actorsService.ActorExistsByIdAsync(id) == false)
            {
				TempData["Message"] = "Actor does not exist!";
                return RedirectToAction("NotFound", "Home");
			}
            try
            {
				var model = await actorsService.GetDetailsForActorAsync(id);
				return View(model);
			}
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
			if (await actorsService.ActorExistsByIdAsync(id) == false)
			{
				TempData["Message"] = "Actor does not exist!";
				return RedirectToAction("NotFound", "Home");
			}
            var model = await actorsService.GetActorForEditAsync(id);
            return View(model);
		}
        [HttpPost]
		public async Task<IActionResult> Edit(int id, ActorFormViewModel model)
		{
			if (await actorsService.ActorExistsByIdAsync(id) == false)
			{
				TempData["Message"] = "Actor does not exist!";
				return RedirectToAction("NotFound", "Home");
			}
            if (ModelState.IsValid == false)
            {
                return View(model);
            }
            await actorsService.EditActorAsync(id, model);
			return RedirectToAction(nameof(Index));
		}
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
			if (await actorsService.ActorExistsByIdAsync(id) == false)
			{
				TempData["Message"] = "Actor does not exist!";
				return RedirectToAction("NotFound", "Home");
			}
            var model = await actorsService.GetActorForDeleteAsync(id);
            return View(model);
		}
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
			if (await actorsService.ActorExistsByIdAsync(id) == false)
			{
                TempData["Message"] = "Actor does not exist!";
				return RedirectToAction("NotFound", "Home");
			}
            await actorsService.DeleteActorAsync(id);
            return RedirectToAction(nameof(Index)); 
		}
	}
}
