using Microsoft.AspNetCore.Mvc;
using SimpleETicketPlatform.Core.Contacts;
using SimpleETicketPlatform.Core.Models.Cinemas;

namespace SimpleETicketPlatform.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemasService cinemaService;

        public CinemasController(ICinemasService cinemaService)
        {
            this.cinemaService = cinemaService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await cinemaService.GetAllCinemasAsync();
            return View(model);
        }
        [HttpGet]
        public IActionResult Add()
        {
            var model = new CinemaFormViewModel();
            return View(model);
        }
        [HttpPost]
		public async Task<IActionResult> Add(CinemaFormViewModel model) 
        { 
            if (ModelState.IsValid == false)
            {
                return View(model);
            }
            await cinemaService.AddCinemaAsync(model);
			return RedirectToAction(nameof(Index));
		}
		[HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (await cinemaService.CinemaExistsByIdAsync(id) == false)
            {
                TempData["Message"] = "Cinema does not exist!";
                return RedirectToAction("NotFound", "Home");
            }
            var model = await cinemaService.GetDetailsForCinemaAsync(id);
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
			if (await cinemaService.CinemaExistsByIdAsync(id) == false)
			{
				TempData["Message"] = "Cinema does not exist!";
				return RedirectToAction("NotFound", "Home");
			}
            var model = await cinemaService.GetCinemaForEditAsync(id);
            return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> Edit(int id, CinemaFormViewModel model)
		{
			if (await cinemaService.CinemaExistsByIdAsync(id) == false)
			{
				TempData["Message"] = "Cinema does not exist!";
				return RedirectToAction("NotFound", "Home");
			}
            if (ModelState.IsValid == false)
            {
                return View(model);
            }
            await cinemaService.EditCinemaAsync(id, model);
			return RedirectToAction(nameof(Index));
		}
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
			if (await cinemaService.CinemaExistsByIdAsync(id) == false)
			{
				TempData["Message"] = "Cinema does not exist!";
				return RedirectToAction("NotFound", "Home");
			}
            var model = new CinemaIndexViewModel();
            return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (await cinemaService.CinemaExistsByIdAsync(id) == false)
			{
				TempData["Message"] = "Cinema does not exist!";
				return RedirectToAction("NotFound", "Home");
			}
            await cinemaService.DeleteCinemaAsync(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
