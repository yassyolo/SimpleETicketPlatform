﻿using Microsoft.EntityFrameworkCore;
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
        }
    }
}
