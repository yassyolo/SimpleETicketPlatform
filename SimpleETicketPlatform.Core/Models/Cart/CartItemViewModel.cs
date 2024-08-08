namespace SimpleETicketPlatform.Core.Models.Cart
{
    public class CartItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty!;
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public decimal SubTotal { get; set; }
        public string PhotoURL { get; set; } = string.Empty;
    }
}
