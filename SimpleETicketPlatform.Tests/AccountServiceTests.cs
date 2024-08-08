using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using SimpleETicketPlatform.Core.Contacts;
using SimpleETicketPlatform.Core.Services;
using SimpleETicketPlatform.Infrastructure.Data;
using SimpleETicketPlatform.Infrastructure.Data.Models;
using SimpleETicketPlatform.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleETicketPlatform.Tests
{
    [TestFixture]
    public class AccountServiceTests
    {
        private IRepository repository;
        private IAccountService accountService;
        private ApplicationDbContext dbContext;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("TestAccountDb").Options;
            dbContext = new ApplicationDbContext(options);
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            repository = new Repository(dbContext);
            accountService = new AccountService(repository);
        }
        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Dispose();
        }
        [Test]
        public async Task FindAccountByEmailAsync_ShouldReturnApplicationUser()
        {
            dbContext.Database.EnsureDeleted();
            var user = new ApplicationUser()
            {
                Email = "email",
                FullName= "Test"
            };
            await repository.AddAsync<ApplicationUser>(user);
            await repository.SaveChangesAsync();
            var result = await accountService.FindAccountByEmailAsync("email");
            Assert.IsNotNull(result);
            Assert.AreEqual("Test", result.FullName);
        }
        [Test]
        public async Task GetPersonalInfoAsync_ShouldReturnPersonalAccountViewModel()
        {
            dbContext.Database.EnsureDeleted();
            var stringId = Guid.NewGuid().ToString();
            var user = new ApplicationUser()
            {
                Email = "email",
                FullName = "Test",
                Id = stringId
            };
            await repository.AddAsync<ApplicationUser>(user);
            await repository.SaveChangesAsync();
            var result = await accountService.GetPersonalInfoAsync(stringId);
            Assert.IsNotNull(result);
            Assert.AreEqual("Test", result.FullName);
            Assert.AreEqual("email", result.Email);
        }
    }
}
