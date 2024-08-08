using Microsoft.EntityFrameworkCore;
using SimpleETicketPlatform.Core.Contacts;
using SimpleETicketPlatform.Core.Models.Producers;
using SimpleETicketPlatform.Core.Services;
using SimpleETicketPlatform.Infrastructure.Data;
using SimpleETicketPlatform.Infrastructure.Data.Models;
using SimpleETicketPlatform.Infrastructure.Repository;
using NUnit.Framework;

namespace SimpleETicketPlatform.Tests
{
    [TestFixture]
    public class ProducersServiceTests
    {
        private IRepository repository;
        private IProducersService producersService;
        private ApplicationDbContext dbContext;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("TestProducersDb").Options;
            dbContext = new ApplicationDbContext(options);
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            repository = new Repository(dbContext);
            producersService = new ProducersService(repository);
        }
        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Dispose();
        }
        [Test]
        public async Task GetProducerDetailsAsync_ShouldReturnProducerDetailsViewModel()
        {
            dbContext.Database.EnsureDeleted();
            var model = new ProducerFormViewModel
            {
                FullName = "Test Test",
                Biography = "Test",
                ProfilePictureURL = "test"
            };
            await producersService.AddProducerAsync(model);
            var result = await producersService.GetProducerDetailsAsync(1);
            Assert.AreEqual("Test", result.Biography);
            Assert.AreEqual("Test Test", result.FullName);
            Assert.AreEqual("test", result.ProfilePictureURL);
        }
        [Test]
        public async Task ProducerExistsByIdAsync_ShouldReturnTrue()
        {
            dbContext.Database.EnsureDeleted();
            var model = new ProducerFormViewModel
            {
                FullName = "Test Test",
                Biography = "Test",
                ProfilePictureURL = "test"
            };
            await producersService.AddProducerAsync(model);
            var result = await producersService.ProducerExistsByIdAsync(1);
            Assert.IsTrue(result);
        }
        [Test]
        public async Task ProducerExistsByIdAsync_ShouldReturnFalse()
        {
            dbContext.Database.EnsureDeleted();
            var model = new ProducerFormViewModel
            {
                FullName = "Test Test",
                Biography = "Test",
                ProfilePictureURL = "test"
            };
            await producersService.AddProducerAsync(model);
            var result = await producersService.ProducerExistsByIdAsync(2);
            Assert.IsFalse(result);
        }
        [Test]
        public async Task AddProducerAsync_ShouldAddProducer()
        {
            dbContext.Database.EnsureDeleted();
            var model = new ProducerFormViewModel
            {
                FullName = "Test Test",
                Biography = "Test",
                ProfilePictureURL = "test"
            };
            await producersService.AddProducerAsync(model);
            var result = await repository.GetByIdAsync<Producer>(1);
            Assert.AreEqual(1, await repository.AllReadOnly<Producer>().CountAsync());
            Assert.AreEqual("Test", result.Biography);
            Assert.AreEqual("Test Test", result.FullName);
            Assert.AreEqual("test", result.ProfilePictureURL);
        }
        [Test]
        public async Task GetProducerForEditAsync_ShouldReturnProducerFormViewModel()
        {
            dbContext.Database.EnsureDeleted();
            var model = new ProducerFormViewModel
            {
                FullName = "Test Test",
                Biography = "Test",
                ProfilePictureURL = "test"
            };
            await producersService.AddProducerAsync(model);
            var result = await producersService.GetProducerForEditAsync(1);
            Assert.AreEqual("Test", result.Biography);
            Assert.AreEqual("Test Test", result.FullName);
            Assert.AreEqual("test", result.ProfilePictureURL);
        }
        [Test]
        public async Task EditProducerAsync_ShouldEditProducer()
        {
            dbContext.Database.EnsureDeleted();
            var model = new ProducerFormViewModel
            {
                FullName = "Test Test",
                Biography = "Test",
                ProfilePictureURL = "test"
            };
            await producersService.AddProducerAsync(model);
            var modelToEdit = new ProducerFormViewModel
            {
                FullName = "Test1 Test1",
                Biography = "Test1",
                ProfilePictureURL = "test1"
            };
            await producersService.EditProducerAsync(1, modelToEdit);
            var result = await repository.GetByIdAsync<Producer>(1);
            Assert.AreEqual("Test1", result.Biography);
            Assert.AreEqual("Test1 Test1", result.FullName);
            Assert.AreEqual("test1", result.ProfilePictureURL);
        }
        [Test]
        public async Task DeleteProducerAsync_ShouldDeleteProducer()
        {
            dbContext.Database.EnsureDeleted();
            var model = new ProducerFormViewModel
            {
                FullName = "Test Test",
                Biography = "Test",
                ProfilePictureURL = "test"
            };
            await producersService.AddProducerAsync(model);
            await producersService.DeleteProducerAsync(1);
            var result = await repository.GetByIdAsync<Producer>(1);
            Assert.AreEqual(0, await repository.AllReadOnly<Producer>().CountAsync());
            Assert.IsNull(result);
        }
        [Test]
        public async Task GetProducerForDeleteAsync_ShouldReturnProducerIndexViewModel()
        {
            dbContext.Database.EnsureDeleted();
            var model = new ProducerFormViewModel
            {
                FullName = "Test Test",
                Biography = "Test",
                ProfilePictureURL = "test"
            };
            await producersService.AddProducerAsync(model);
            var result = await producersService.GetProducerForDeleteAsync(1);
            Assert.AreEqual("Test Test", result.FullName);
            Assert.AreEqual(1, result.Id);
        }
        [Test]
        public async Task GetProducerNamesAsync_ShouldReturnIEnumerableProducersNameViewModel()
        {
            dbContext.Database.EnsureDeleted();
            var model = new ProducerFormViewModel
            {
                FullName = "Test Test",
            };
            var model2 = new ProducerFormViewModel
            {
                FullName = "Test1 Test1",
            };
            await producersService.AddProducerAsync(model);
            await producersService.AddProducerAsync(model2);
            var result = await producersService.GetProducerNamesAsync();
            Assert.AreEqual("Test",result.First().FirstName);
            Assert.AreEqual("Test1", result.Skip(1).Take(1).FirstOrDefault().FirstName);
            Assert.AreEqual(2, result.Count());
        }
        [Test]
        public async Task GetAllProducersAsync_ShouldReturnFilteredProducersViewModelWithoutSearchTerm()
        {
            dbContext.Database.EnsureDeleted();
            var model = new ProducerFormViewModel
            {
                FullName = "Test Test",
                Biography = "Test",
                ProfilePictureURL = "test"
            };
            var model2 = new ProducerFormViewModel
            {
                FullName = "Test1 Test",
                Biography = "Test1",
                ProfilePictureURL = "test1"
            };
            await producersService.AddProducerAsync(model);
            await producersService.AddProducerAsync(model2);
            var result = await producersService.GetAllProducersAsync(string.Empty);
            Assert.AreEqual("Test Test", result.Producers.First().FullName);
            Assert.AreEqual("Test1 Test", result.Producers.Skip(1).First().FullName);
            Assert.AreEqual(2, result.ProducersMatched);
        }
        [Test]
        public async Task GetAllProducersAsync_ShouldReturnFilteredProducersViewModelWithSearchTerm()
        {
            dbContext.Database.EnsureDeleted();
            var model = new ProducerFormViewModel
            {
                FullName = "A",
                Biography = "Test",
                ProfilePictureURL = "test"
            };
            var model2 = new ProducerFormViewModel
            {
                FullName = "B",
                Biography = "Test1",
                ProfilePictureURL = "test1"
            };
            await producersService.AddProducerAsync(model);
            await producersService.AddProducerAsync(model2);
            var result = await producersService.GetAllProducersAsync("A");
            Assert.AreEqual("A", result.Producers.First().FullName);
            Assert.AreEqual(1, result.ProducersMatched);
        }
    }
}
