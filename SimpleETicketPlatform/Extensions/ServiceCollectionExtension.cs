using Microsoft.EntityFrameworkCore;
using SimpleETicketPlatform.Core.Contacts;
using SimpleETicketPlatform.Core.Services;
using SimpleETicketPlatform.Infrastructure.Data;
using SimpleETicketPlatform.Infrastructure.Repository;

namespace SimpleETicketPlatform.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSession();
            services.AddScoped<IActorsService, ActorsService>();
            services.AddScoped<IProducersService, ProducersService>();
            services.AddScoped<ICinemasService, CinemasService>();
            services.AddScoped<IMoviesService, MoviesService>();
			services.AddScoped<IShoppingCartService, ShoppingCartService>();

            return services;
        }
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionStr = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>
                (options => options.UseSqlServer(connectionStr));

            services.AddScoped<IRepository, Repository>();
            return services;
        }
    }
}
