using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleETicketPlatform.Infrastructure.Data.Models;

namespace SimpleETicketPlatform.Infrastructure.SeedDb
{
	public class ProducerConfiguration : IEntityTypeConfiguration<Producer>
	{
		public void Configure(EntityTypeBuilder<Producer> builder)
		{
			var data = new SeedData();
			builder.HasData(new Producer[] { data.Producer1, data.Producer2, data.Producer3, data.Producer4, data.Producer5, data.Producer6 });
		}
	}
}
