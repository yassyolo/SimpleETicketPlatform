using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleETicketPlatform.Infrastructure.Data.Models;

namespace SimpleETicketPlatform.Infrastructure.SeedDb
{
	public class ActorConfiguration : IEntityTypeConfiguration<Actor>
	{
		public void Configure(EntityTypeBuilder<Actor> builder)
		{
			var data = new SeedData();
			builder.HasData(new Actor[] { data.Actor1, data.Actor2, data.Actor3, data.Actor4, data.Actor5, data.Actor6 });
		}
	}
}
