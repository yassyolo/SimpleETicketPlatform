using Microsoft.AspNetCore.Mvc;
using SimpleETicketPlatform.Core.Contacts;
using SimpleETicketPlatform.Core.Models.Cart;
using SimpleETicketPlatform.Extensions;

namespace SimpleETicketPlatform.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IShoppingCartService shoppingCartService;
        private readonly IOrdersService ordersService;

        public OrdersController(IShoppingCartService shoppingCartService, IOrdersService ordersService)
        {
            this.shoppingCartService = shoppingCartService;
            this.ordersService = ordersService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetOrderSummary(string id)
        {
            if (await shoppingCartService.CartWithIdExists(id) == false)
            {
                TempData["Message"] = "Cart not found!";
                return RedirectToAction("NotFound", "Home");
            }
            var model = await shoppingCartService.GetCartSummaryAsync(id);
            return View(model);
        }
        public async Task<ActionResult> PlaceOrder(string id)
        {
            if (await shoppingCartService.CartWithIdExists(id) == false)
            {
                TempData["Message"] = "Cart not found!";
                return RedirectToAction("NotFound", "Home");
            }
            var userId = User.GetId();
            var email = User.GetEmail();
            await ordersService.MakeOrderAsync(id, userId, email);
            return RedirectToAction(nameof(SuccessfulOrder));
        }
        public async Task<IActionResult> SuccessfulOrder(int id)
        {
            if (await ordersService.OrderWithIdExists(id) == false)
            {
                TempData["Message"] = "Order not found!";
                return RedirectToAction("NotFound", "Home");
            }
            var model = await ordersService.GetSuccesfulOrderByIdAsync(id);
            return View(model);
        }
        /*public async Task<IActionResult> OrdersHistory(string id)
        {
            var model = await ordersService.GetOrdersForIdAsync(id);
            return View(model);
        */

    }
}
