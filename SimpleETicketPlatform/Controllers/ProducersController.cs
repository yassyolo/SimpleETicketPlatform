using Microsoft.AspNetCore.Mvc;
using SimpleETicketPlatform.Core.Contacts;
using SimpleETicketPlatform.Core.Models.Producers;

namespace SimpleETicketPlatform.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducersService producersService;

        public ProducersController(IProducersService producersService)
        {
            this.producersService = producersService;
        }
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] FilteredProducersViewModel query)
        {
            var model = await producersService.GetAllProducersAsync(query.SearchTerm);
            query.Producers = model.Producers;
            query.ProducersMatched = model.ProducersMatched;
            return View(query);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (await producersService.ProducerExistsByIdAsync(id) == false)
            {
                TempData["Message"] = "Producer does not exist!";
                return RedirectToAction("NotFound", "Home");
            }
            var model = await producersService.GetProducerDetailsAsync(id);
            return View(model);
        }
        [HttpGet]
        public IActionResult Add()
        {
            var model = new ProducerFormViewModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(ProducerFormViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }
            await producersService.AddProducerAsync(model);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (await producersService.ProducerExistsByIdAsync(id) == false)
            {
                TempData["Message"] = "Producer does not exist!";
                return RedirectToAction("NotFound", "Home");
            }
            var model = await producersService.GetProducerForEditAsync(id);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProducerFormViewModel model)
        {
            if (await producersService.ProducerExistsByIdAsync(id) == false)
            {
                TempData["Message"] = "Producer does not exist!";
                return RedirectToAction("NotFound", "Home");
            }
            if (ModelState.IsValid == false)
            {
                return View(model);
            }
            await producersService.EditProducerAsync(id, model);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
			if (await producersService.ProducerExistsByIdAsync(id) == false)
			{
				TempData["Message"] = "Producer does not exist!";
				return RedirectToAction("NotFound", "Home");
			}
            var model = new ProducerIndexViewModel();
            return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (await producersService.ProducerExistsByIdAsync(id) == false)
			{
				TempData["Message"] = "Producer does not exist!";
				return RedirectToAction("NotFound", "Home");
			}
            await producersService.DeleteProducerAsync(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
