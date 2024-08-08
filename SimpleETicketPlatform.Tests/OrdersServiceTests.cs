using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using SimpleETicketPlatform.Core.Contacts;
using SimpleETicketPlatform.Core.Models.Actors;
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
    public class OrdersServiceTests
    {
        private IRepository repository;
        private IOrdersService ordersService;
        private ApplicationDbContext dbContext;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            dbContext = new ApplicationDbContext(options);
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureDeleted();
            repository = new Repository(dbContext);
            ordersService = new OrdersService(repository);
        }
        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Dispose();
        }
        [Test]
        public async Task GetOrderByIdAsync_ShouldReturnOrdersId()
        {
            dbContext.Database.EnsureDeleted();
            string userId = Guid.NewGuid().ToString();
            var user = new ApplicationUser()
            {
                Id = userId
            };
            await repository.AddAsync<ApplicationUser>(user);
            await repository.SaveChangesAsync();
            var order = new Order()
            {
                UserId = userId
            };
            await repository.AddAsync<Order>(order);
            await repository.SaveChangesAsync();
            var result = await ordersService.GetOrderByIdAsync(userId);

            Assert.AreEqual(1, result);
            
        }
        [Test]
        public async Task GetSuccesfulOrderByIdAsync_ShouldReturnSuccessfullOrderViewModel()
        {
            dbContext.Database.EnsureDeleted();
            string userId = Guid.NewGuid().ToString();
            var user = new ApplicationUser()
            {
                Id = userId
            };
            await repository.AddAsync<ApplicationUser>(user);
            await repository.SaveChangesAsync();
            var order = new Order()
            {
                UserId = userId
            };
            await repository.AddAsync<Order>(order);
            await repository.SaveChangesAsync();
            var result = await ordersService.GetSuccesfulOrderByIdAsync(1);

            Assert.AreEqual(1, result.Id);
            Assert.AreEqual(userId, result.UserId);
        }
        [Test]
        public async Task OrderWithIdExists_ShouldReturnTrue()
        {
            dbContext.Database.EnsureDeleted();
            var order = new Order()
            {
                Email = "test"
            };
            await repository.AddAsync<Order>(order);
            await repository.SaveChangesAsync();
            var result = await ordersService.OrderWithIdExists(1);
            Assert.IsTrue(result);
        }
        [Test]
        public async Task OrderWithIdExists_ShouldReturnFalse()
        {
            dbContext.Database.EnsureDeleted();
            var order = new Order()
            {
                Email = "test"
            };
            await repository.AddAsync<Order>(order);
            await repository.SaveChangesAsync();
            var result = await ordersService.OrderWithIdExists(2);
            Assert.IsFalse(result);
        }
        [Test]
        public async Task MakeOrderAsync_ShouldMakeOrder()
        {
            dbContext.Database.EnsureDeleted();
            string userId = Guid.NewGuid().ToString();
            var user = new ApplicationUser()
            {
                Id = userId,
                Email = "test"
            };
            await repository.AddAsync<ApplicationUser>(user);
            await repository.SaveChangesAsync();
            string cartId = Guid.NewGuid().ToString();
            var cart = new ShoppingCart()
            {
                Id = cartId
            };
            await repository.AddAsync<ShoppingCart>(cart);
            await repository.SaveChangesAsync();
            var movie = new Movie()
            {
                Name = "Test",
                Price = 12m
            };
            await repository.AddAsync<Movie>(movie);
            await repository.SaveChangesAsync();
            var movie2 = new Movie()
            {
                Name = "Test1",
                Price = 14m
            };
            await repository.AddAsync<Movie>(movie);
            await repository.SaveChangesAsync();
            var shoppingCartItem = new ShoppingCartItem()
            {
                ShoppingCartId = cartId,
                Amount = 2,
                MovieId = movie.Id
            };
            await repository.AddAsync<ShoppingCartItem>(shoppingCartItem);
            await repository.SaveChangesAsync();
            var shoppingCartItem2 = new ShoppingCartItem()
            {
                ShoppingCartId = cartId,
                Amount = 1,
                MovieId = movie2.Id
            };
            await repository.AddAsync<ShoppingCartItem>(shoppingCartItem);
            await repository.SaveChangesAsync();
            await ordersService.MakeOrderAsync(cartId, userId, "test");
            var order = await repository.GetByIdAsync<Order>(1);
            Assert.AreEqual("test", order.Email);
            Assert.AreEqual(DateTime.Now, order.Date);
            Assert.AreEqual(userId, order.UserId);
        }
    }
}
