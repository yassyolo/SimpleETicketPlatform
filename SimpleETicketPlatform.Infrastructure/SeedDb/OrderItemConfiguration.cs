using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleETicketPlatform.Infrastructure.Data.Models;

namespace SimpleETicketPlatform.Infrastructure.SeedDb
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
	{
		public void Configure(EntityTypeBuilder<OrderItem> builder)
		{
			builder.Property(x => x.Price).HasColumnType("decimal(7,2)");
		}
	}
}
