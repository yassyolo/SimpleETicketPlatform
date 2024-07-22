using Microsoft.AspNetCore.Mvc;
using SimpleETicketPlatform.Core.Contacts;

namespace SimpleETicketPlatform.Controllers
{
    public class ShoppingCartController : Controller
	{
		private readonly IShoppingCartService shoppingCartService;
        private readonly IMoviesService moviesService;

        public ShoppingCartController(IShoppingCartService shoppingCartService, IMoviesService moviesService)
		{
			this.shoppingCartService = shoppingCartService;
			this.moviesService = moviesService;
		}

		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> AddToCart(int id)
		{
			if (await moviesService.MovieExistsWithId(id) == false)
			{
				TempData["Message"] = "Movie does not exist.";
				return RedirectToAction("NotFound", "Home");
			}
			var cart = await shoppingCartService.GetShoppingCart();

            await shoppingCartService.AddMovieToCartAsync(id, cart.Id);
			return RedirectToAction(nameof(CartDetails));
		}
        [HttpGet]
        public async Task<IActionResult> DeleteFromCart(int id)
        {
            var cart = await shoppingCartService.GetShoppingCart();
            if (await shoppingCartService.ShoppingCartItemExists(id, cart.Id) == false)
             {
                 TempData["Message"] = "Item does not exist.";
                 return RedirectToAction("NotFound", "Home");
             }
            
            await shoppingCartService.DeleteFromCartAsync(id, cart.Id);
            return RedirectToAction(nameof(CartDetails));
        }
        [HttpGet]
        public async Task<IActionResult> CartDetails()
        {
            var cart = await shoppingCartService.GetShoppingCart();
			var model = await shoppingCartService.GetCartDetailsAsync(cart.Id);
            return View(model);
        }
		[HttpGet]
		public async Task<IActionResult> CartSummary()
		{
			var cart = await shoppingCartService.GetShoppingCart();
			var model = await shoppingCartService.GetCartDetailsAsync(cart.Id);
            return PartialView("_CartSummaryPartial", model);
        }

	}
}
