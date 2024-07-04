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
            builder.Property(x => x.Price).HasColumnType("decimal(5,2)").IsRequired();
            var data = new SeedData();
            builder.HasData(new Movie[] { data.Movie1, data.Movie2, data.Movie3, data.Movie4, data.Movie5, data.Movie6 });
        }
    }
}
