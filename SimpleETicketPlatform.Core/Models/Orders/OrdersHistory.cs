namespace SimpleETicketPlatform.Core.Models.Orders
{
	public class OrdersHistory
	{
        public int Id { get; set; }
		public string UserId { get; set; } = string.Empty;
        public int ItemsCount { get; set; }
        public decimal TotalPrice { get; set; }
        public IEnumerable<OrderDetailsViewModel> Orders = new List<OrderDetailsViewModel>();
    }
}
