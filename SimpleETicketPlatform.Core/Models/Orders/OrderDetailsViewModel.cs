using SimpleETicketPlatform.Core.Models.Cart;

namespace SimpleETicketPlatform.Core.Models.Orders
{
	public class OrderDetailsViewModel
	{
        public int Id { get; set; }
		public decimal TotalPrice { get; set; }
        public string Date { get; set; } = string.Empty;

        public IEnumerable<CartItemViewModel> OrderItems = new List<CartItemViewModel>();

	}
}
