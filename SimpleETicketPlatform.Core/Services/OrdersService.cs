using Microsoft.EntityFrameworkCore;
using SimpleETicketPlatform.Core.Contacts;
using SimpleETicketPlatform.Core.Models.Cart;
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

        public async Task<int> GetOrderByIdAsync(string userId)
        {
            return await repository.AllReadOnly<Order>().Where(x => x.UserId == userId).OrderByDescending(x=> x.Id).Select(x => x.Id).Take(1).FirstOrDefaultAsync();
        }

        public async Task<OrdersHistoryViewModel?> GetOrdersHistoryForIdAsync(string userId)
        {
            var username = await repository.AllReadOnly<ApplicationUser>().Where(x => x.Id == userId).Select(x => x.FullName).FirstOrDefaultAsync();
            var orderCount = await repository.AllReadOnly<Order>().Where(x => x.UserId == userId).CountAsync();
            var orders = await repository.AllReadOnly<Order>().Where(x => x.UserId == userId)
                .Select(x => new OrderDetailsViewModel()
                {
                    Id = x.Id,
                    Date = x.Date.ToString("dd-MM-yyyy"),
                }).ToListAsync();
            decimal orderTotalPrice = 0m;
            foreach (var order in orders)
            {
                order.OrderItems = await repository.AllReadOnly<OrderItem>().Where(x => x.OrderId == order.Id)
                    .Select(x => new CartItemViewModel()
                    {
                        Id = x.Id,
                        PhotoURL = x.Movie.PhotoURL,
                        Amount = x.Amount,

                    }).ToListAsync();
            }
            
            
            return new OrdersHistoryViewModel()
            {
                Username = username,
                OrdersCount = orderCount,
                Orders = orders
            };

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
                Email = email,
                Date = DateTime.Now
            };
            await repository.AddAsync<Order>(order);
            await repository.SaveChangesAsync();
            var shoppingCartItems = await repository.AllReadOnly<ShoppingCartItem>().Where(x => x.ShoppingCartId == cart.Id).ToListAsync();
            foreach (var cartItem in shoppingCartItems)
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
