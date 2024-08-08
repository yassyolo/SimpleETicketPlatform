using SimpleETicketPlatform.Core.Models.Account;
using SimpleETicketPlatform.Infrastructure.Data.Models;

namespace SimpleETicketPlatform.Core.Contacts
{
    public interface IAccountService
    {
        Task<ApplicationUser?> FindAccountByEmailAsync(string email);
        Task<PersonalAccountViewModel?> GetPersonalInfoAsync(string userId);
    }
}
