using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleETicketPlatform.Infrastructure.Data.Models;

namespace SimpleETicketPlatform.Infrastructure.SeedDb
{
    public class MovieActorConfiguration : IEntityTypeConfiguration<MovieActor>
    {
        public void Configure(EntityTypeBuilder<MovieActor> builder)
        {
            builder.HasKey(x => new { x.MovieId, x.ActorId });
            builder.HasOne(x => x.Movie).WithMany(x => x.MovieActors).HasForeignKey(x => x.MovieId);
            builder.HasOne(x => x.Actor).WithMany(x => x.MovieActors).HasForeignKey(x => x.ActorId);

			var data = new SeedData();
            builder.HasData(new MovieActor[] { data.Actor1Movie1, data.Actor2Movie1, data.Actor3Movie2, data.Actor4Movie2, data.Actor5Movie3, data.Actor6Movie3 });

		}
    }
}
