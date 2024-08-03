using SimpleETicketPlatform.Core.Models.Account;
using SimpleETicketPlatform.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleETicketPlatform.Core.Contacts
{
    public interface IAccountService
    {
        Task<ApplicationUser?> FindAccountByEmailAsync(string email);
        Task<PersonalAccountViewModel?> GetPersonalInfoAsync(string userId);
    }
}
