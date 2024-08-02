using Microsoft.EntityFrameworkCore;
using SimpleETicketPlatform.Core.Contacts;
using SimpleETicketPlatform.Core.Models.Orders;
using SimpleETicketPlatform.Infrastructure.Data.Models;
using SimpleETicketPlatform.Infrastructure.Repository;

namespace SimpleETicketPlatform.Core.Services
{
	public class OrdersService : IOrdersService
    {
        private readonly IRepository repository;

        public OrdersService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<SuccessfullOrderViewModel?> GetSuccesfulOrderByIdAsync(int id)
        {
            return await repository.AllReadOnly<Order>().Where(x => x.Id == id)
                .Select(x => new SuccessfullOrderViewModel()
                {
                    Id = x.Id,
                    UserId = x.UserId
                }).FirstOrDefaultAsync();
        }

		public async Task MakeOrderAsync(string id, string userId, string email)
		{
            var cart = await repository.AllReadOnly<ShoppingCart>().Where(x => x.Id == id).FirstOrDefaultAsync();
            var order = new Order()
            {
                UserId = userId,
                Email = email
            };
            await repository.AddAsync<Order>(order);
            await repository.SaveChangesAsync();
            foreach (var cartItem in cart.ShoppingCartItems)
            {
                var movie = await repository.AllReadOnly<Movie>().Where(x => x.Id == cartItem.MovieId).FirstOrDefaultAsync();
                var orderItem = new OrderItem()
                {
                    Amount = cartItem.Amount,
                    MovieId = cartItem.MovieId,
                    OrderId = order.Id,
                    Price = movie.Price
                };

				await repository.AddAsync<OrderItem>(orderItem);
				await repository.SaveChangesAsync();
                await repository.DeleteAsync(cartItem);
			}
            await repository.DeleteAsync(cart);

		}

		public async Task<bool> OrderWithIdExists(int id)
        {
            return await repository.AllReadOnly<Order>().AnyAsync(x => x.Id == id);
        }
    }
}
