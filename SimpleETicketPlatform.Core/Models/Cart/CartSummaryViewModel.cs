using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleETicketPlatform.Core.Models.Cart
{
    public class CartSummaryViewModel
    {
        public string Id { get; set; } = string.Empty;
        public List<CartItemViewModel> Items { get; set; } = new();
        public decimal Tax { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
