using Microsoft.AspNetCore.Mvc;
using SimpleETicketPlatform.Core.Contacts;

namespace SimpleETicketPlatform.Controllers
{
	public class ShoppingCartController : Controller
	{
		private readonly IShoppingCartService shoppingCartService;

		public ShoppingCartController(IShoppingCartService shoppingCartService)
		{
			this.shoppingCartService = shoppingCartService;
		}

		public IActionResult Index()
		{
			return View();
		}
	}
}
