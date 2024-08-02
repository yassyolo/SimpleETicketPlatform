using SimpleETicketPlatform.Core.Models.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleETicketPlatform.Core.Contacts
{
    public interface IOrdersService
    {
        Task<SuccessfullOrderViewModel?> GetSuccesfulOrderByIdAsync(int id);
		Task MakeOrderAsync(string id, string userId, string email);
		Task<bool> OrderWithIdExists(int id);
    }
}
