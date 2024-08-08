using SimpleETicketPlatform.Core.Models.Cart;
using SimpleETicketPlatform.Infrastructure.Data.Models;

namespace SimpleETicketPlatform.Core.Contacts
{
    public interface IShoppingCartService
    {
        Task AddMovieToCartAsync(int id, string cartId);
        Task<bool> CartWithIdExists(string id);
        Task DeleteFromCartAsync(int id, string cartId);
        Task<CartIndexViewModel> GetCartDetailsAsync(string id);
        Task<CartSummaryViewModel?> GetCartSummaryAsync(string id);
        Task<ShoppingCart> GetShoppingCart();
        Task<bool> ShoppingCartItemExists(int itemId, string cartId);
    }
}
