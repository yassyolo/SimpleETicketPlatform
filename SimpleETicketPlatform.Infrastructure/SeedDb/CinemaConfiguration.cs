using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleETicketPlatform.Infrastructure.Data.Models;

namespace SimpleETicketPlatform.Infrastructure.SeedDb
{
    public class CinemaConfiguration : IEntityTypeConfiguration<Cinema>
    {
        public void Configure(EntityTypeBuilder<Cinema> builder)
        {
            builder.HasMany(x => x.Movies).WithOne(x => x.Cinema).OnDelete(DeleteBehavior.Restrict);
            var data = new SeedData();
            builder.HasData(new Cinema[] { data.Cinema1, data.Cinema2, data.Cinema3 });
        }
    }
}
