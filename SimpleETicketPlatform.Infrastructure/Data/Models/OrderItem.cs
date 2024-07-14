using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SimpleETicketPlatform.Infrastructure.Data.Constants.ModelConstants.OrderItem;

namespace SimpleETicketPlatform.Infrastructure.Data.Models
{
    [Comment("Order item entity")]
	public class OrderItem
	{
		[Key]
		[Comment("Order item identifier")]
		public int Id { get; set; }

		[Comment("Order items amount")]
		public int Amount { get; set; }

		[Comment("Order ites price")]
		[Range(typeof(decimal), PriceMinValue, PriceMaxValue, ConvertValueInInvariantCulture = false)]

		public decimal Price { get; set; }

		[Comment("Order item movie identifier")]
		public int MovieId { get; set; }

		[ForeignKey(nameof(MovieId))]
		[Comment("Order item identifier")]
		public Movie Movie { get; set; } = null!;

		[Comment("Order item movie identifier")]
		public int OrderId { get; set; }

		[ForeignKey(nameof(OrderId))]
		[Comment("Order item identifier")]
		public Order Order { get; set; } = null!;
	}
}
