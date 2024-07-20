
using Microsoft.AspNetCore.Http;
using SimpleETicketPlatform.Core.Models.Cart;
using SimpleETicketPlatform.Infrastructure.Data.Models;

namespace SimpleETicketPlatform.Core.Contacts
{
    public interface IShoppingCartService
    {
        Task AddMovieToCartAsync(int id, string cartId);
        Task DeleteFromCartAsync(int id, string cartId);
        Task<CartIndexViewModel> GetCartDetailsAsync(string id);
        Task<ShoppingCart> GetShoppingCart();
    }
}
