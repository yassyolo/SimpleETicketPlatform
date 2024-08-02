using Microsoft.EntityFrameworkCore;
using SimpleETicketPlatform.Core.Contacts;
using SimpleETicketPlatform.Infrastructure.Data.Models;
using SimpleETicketPlatform.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
