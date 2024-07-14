using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SimpleETicketPlatform.Infrastructure.Data.Models
{
    [Comment("Shopping cart entity")]
	public class ShoppingCart
	{
		[Key]
		[Comment("Shopping cart identifier")]
		public string Id { get; set; } = string.Empty;
		public IEnumerable<ShoppingCartItem> ShoppingCartItems { get; set; } = new List<ShoppingCartItem>();
    }
}
