using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleETicketPlatform.Infrastructure.Data.Models;

namespace SimpleETicketPlatform.Infrastructure.SeedDb
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasOne(x => x.Producer).WithMany().HasForeignKey(x => x.ProducerId);
            builder.HasOne(x => x.Cinema).WithMany().HasForeignKey(x => x.CinemaId);
        }
    }
}
