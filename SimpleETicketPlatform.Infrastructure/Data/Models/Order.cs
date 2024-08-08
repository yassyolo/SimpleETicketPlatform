using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SimpleETicketPlatform.Infrastructure.Data.Models
{
    [Comment("Order entity")]
	public class Order
	{
		[Key]
		[Comment("Actor identifier")]
		public int Id { get; set; } 

		[Comment("Order email")]
		public string Email { get; set; } = string.Empty;

		[Comment("Order user identifier")]
		public string UserId { get; set; } = string.Empty;

        [Comment("Order date when made")]
        public DateTime Date { get; set; }

        [Comment("Order items")]
		public IEnumerable<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
	}
}
