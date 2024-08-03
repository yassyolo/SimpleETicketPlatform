using Microsoft.EntityFrameworkCore;
using SimpleETicketPlatform.Core.Contacts;
using SimpleETicketPlatform.Core.Models.Account;
using SimpleETicketPlatform.Infrastructure.Data.Models;
using SimpleETicketPlatform.Infrastructure.Repository;

namespace SimpleETicketPlatform.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRepository repository;

        public AccountService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ApplicationUser?> FindAccountByEmailAsync(string email)
        {
            return await repository.AllReadOnly<ApplicationUser>().Where(x => x.Email == email).FirstOrDefaultAsync();
        }

        public async Task<PersonalAccountViewModel?> GetPersonalInfoAsync(string userId)
        {
           var account = await repository.AllReadOnly<ApplicationUser>().Where(x => x.Id == userId)
                .Select(x => new PersonalAccountViewModel()
                {
                    FullName = x.FullName,
                    Email = x.Email
                }).FirstOrDefaultAsync();
            account.TotalOrders = await repository.AllReadOnly<Order>().Where(x => x.UserId == userId).CountAsync();
            return account;
        }
    }
}
