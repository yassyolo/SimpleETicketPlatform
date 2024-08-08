namespace SimpleETicketPlatform.Core.Models.Orders
{
	public class OrdersHistoryViewModel
	{
		public string Username { get; set; } = string.Empty;
        public int OrdersCount { get; set; }

        public IEnumerable<OrderDetailsViewModel> Orders = new List<OrderDetailsViewModel>();
    }
}
