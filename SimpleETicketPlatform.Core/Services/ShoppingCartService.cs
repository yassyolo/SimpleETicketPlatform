using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SimpleETicketPlatform.Core.Contacts;
using SimpleETicketPlatform.Core.Models.Cart;
using SimpleETicketPlatform.Infrastructure.Data.Models;
using SimpleETicketPlatform.Infrastructure.Repository;

namespace SimpleETicketPlatform.Core.Services
{
    public class ShoppingCartService : IShoppingCartService
	{
		private readonly IRepository repository;
        private readonly IHttpContextAccessor httpContextAccessor;


        public ShoppingCartService(IRepository repository, IHttpContextAccessor httpContextAccessor) 
        {
            this.httpContextAccessor = httpContextAccessor;
            this.repository = repository;
        }

        public async Task AddMovieToCartAsync(int movieId, string cartId)
        {
            var cart = await repository.GetByIdAsync<ShoppingCart>(cartId);
            if (cart == null)
            {
                throw new InvalidOperationException("Shopping cart does not exist.");
            }

            var cartItem = await repository.All<ShoppingCartItem>()
                .Where(x => x.MovieId == movieId && x.ShoppingCartId == cartId)
                .FirstOrDefaultAsync();

            if (cartItem == null)
            {
                var itemToAdd = new ShoppingCartItem
                {
                    ShoppingCartId = cartId,
                    Amount = 1,
                    MovieId = movieId
                };
                await repository.AddAsync(itemToAdd);
            }
            else
            {
                cartItem.Amount++;
                await repository.SaveChangesAsync();
            }

            await repository.SaveChangesAsync();
        }

        public async Task<bool> CartWithIdExists(string id)
        {
            return await repository.AllReadOnly<ShoppingCart>().Where(x => x.Id == id).AnyAsync();
        }

        public async Task DeleteFromCartAsync(int id, string cartId)
        {
            var cartItem = await repository.AllReadOnly<ShoppingCartItem>()
                .Where(x => x.Id == id && x.ShoppingCartId == cartId).FirstOrDefaultAsync();
            if (cartItem.Amount > 1)
            {
                cartItem.Amount--;
            }
            else
            {
                await repository.DeleteAsync(cartItem);
            }
        }

        public async Task<CartIndexViewModel> GetCartDetailsAsync(string id)
        {
            var cart = await repository.AllReadOnly<ShoppingCart>().Where(x => x.Id == id)
                .Select(x => new CartIndexViewModel()
                {
                    Id = x.Id, 
                })
                .FirstOrDefaultAsync();
            var cartItems =  repository.AllReadOnly<ShoppingCartItem>().Where(x => x.ShoppingCartId == id);
            foreach (var item in cartItems)
            {
                var movie = await repository.GetByIdAsync<Movie>(item.MovieId);
                var shoppingItem = new CartItemViewModel()
                {
                    Id = item.Id,
                    Name = movie.Name,
                    Price = movie.Price,
                    Amount = item.Amount,
                    SubTotal = item.Amount * movie.Price
                };
                cart.Items.Add(shoppingItem);
            }
            cart.TotalPrice = cart.Items.Select(x => x.SubTotal).Sum();
            return cart;           
        }

        public async Task<CartSummaryViewModel?> GetCartSummaryAsync(string id)
        {
            var cart = await repository.AllReadOnly<ShoppingCart>().Where(x => x.Id == id)
               .Select(x => new CartSummaryViewModel()
               {
                   Id = x.Id,
               })
               .FirstOrDefaultAsync();
            var cartItems = repository.AllReadOnly<ShoppingCartItem>().Where(x => x.ShoppingCartId == id);
            foreach (var item in cartItems)
            {
                var movie = await repository.GetByIdAsync<Movie>(item.MovieId);
                var shoppingItem = new CartItemViewModel()
                {
                    Id = item.Id,
                    Name = movie.Name,
                    Price = movie.Price,
                    Amount = item.Amount,
                    SubTotal = item.Amount * movie.Price,
                    PhotoURL =movie.PhotoURL
                };
                cart.Items.Add(shoppingItem);
            }
            cart.Price = cart.Items.Select(x => x.SubTotal).Sum();
            cart.Tax = cart.Price * (20 / 100);
            cart.TotalPrice = cart.Price + cart.Tax;
            return cart;
        }

        public async Task<ShoppingCart> GetShoppingCart()
        {
            var context = httpContextAccessor.HttpContext;
            ISession session = context.Session;
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            var cart = await repository.GetByIdAsync<ShoppingCart>(cartId);
            if (cart == null)
            {
                cart = new ShoppingCart { Id = cartId };
                await repository.AddAsync(cart);
                await repository.SaveChangesAsync();
            }

            return cart;
        }

        public async Task<bool> ShoppingCartItemExists(int itemId, string cartId)
        {
            return await repository.AllReadOnly<ShoppingCartItem>().Where(x => x.Id == itemId && x.ShoppingCartId == cartId).AnyAsync();
        }
    }
}
