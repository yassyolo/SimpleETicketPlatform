using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpleETicketPlatform.Infrastructure.Data.Models;
using SimpleETicketPlatform.Infrastructure.SeedDb;

namespace SimpleETicketPlatform.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> context)
            :base(context)
        {
                
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
			builder.ApplyConfiguration(new CinemaConfiguration());
			builder.ApplyConfiguration(new ProducerConfiguration());
            builder.ApplyConfiguration(new MovieCategoryConfiguration());
            builder.ApplyConfiguration(new MovieConfiguration());
			builder.ApplyConfiguration(new ActorConfiguration());
			builder.ApplyConfiguration(new MovieActorConfiguration());
            builder.ApplyConfiguration(new OrderItemConfiguration());
            //builder.ApplyConfiguration(new RolesConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRolesConfiguration());

            base.OnModelCreating(builder);
        }

        public DbSet<Actor> Actors { get; set; } = null!;
        public DbSet<Cinema> Cinemas { get; set; } = null!;
        public DbSet<MovieCategory> MovieCategories { get; set; } = null!;
        public DbSet<Movie> Movies { get; set; } = null!;
        public DbSet<MovieActor> MovieActors { get; set; } = null!;
        public DbSet<Producer> Producers { get; set; } = null!;
		public DbSet<Order> Orders { get; set; } = null!;
		public DbSet<OrderItem> OrderItems { get; set; } = null!;
		public DbSet<ShoppingCartItem> ShoppingCartItem { get; set; } = null!;
        public DbSet<ShoppingCart> ShoppingCart { get; set; } = null!;
    }
}
