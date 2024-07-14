using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleETicketPlatform.Infrastructure.Data.Models
{
    [Comment("Shopping cart item entity")]
	public class ShoppingCartItem
	{
        [Key]
        [Comment("Shopping cart item identifier")]
        public int Id { get; set; }

		[Comment("Shopping cart item identifier")]
		public Movie Movie { get; set; } = null!;

		[Comment("Shopping cart items amount")]
		public int Amount { get; set; }

		[Comment("Shopping cart identifier")]
		public string ShoppingCartId { get; set; } = string.Empty;

		[Comment("Shopping cart identifier")]
		[ForeignKey(nameof(ShoppingCartId))]
		public ShoppingCart ShoppingCart { get; set; } = null!;
    }
}
