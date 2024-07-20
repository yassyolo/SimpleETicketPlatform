using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using SimpleETicketPlatform.Core.Contacts;
using SimpleETicketPlatform.Infrastructure.Data;
using SimpleETicketPlatform.Infrastructure.Data.Models;

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
        public async Task<IActionResult> DeleteFromCart(int id, string cartId)
        {
           /* if (await shoppingCartService.ShoppingCartItemExists(id, cartId) == false)
            {
                TempData["Message"] = "Item does not exist.";
                return RedirectToAction("NotFound", "Home");
            }*/
            await shoppingCartService.DeleteFromCartAsync(id, cartId);
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
			return View(model);
		}

	}
}
