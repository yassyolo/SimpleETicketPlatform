using SimpleETicketPlatform.Core.Models.Orders;

namespace SimpleETicketPlatform.Core.Contacts
{
    public interface IOrdersService
    {
        Task<int> GetOrderByIdAsync(string userId);
        Task<OrdersHistoryViewModel?> GetOrdersHistoryForIdAsync(string userId);
        Task<SuccessfullOrderViewModel?> GetSuccesfulOrderByIdAsync(int id);
		Task MakeOrderAsync(string id, string userId, string email);
		Task<bool> OrderWithIdExists(int id);
    }
}
