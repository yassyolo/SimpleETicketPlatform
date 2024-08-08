using Microsoft.EntityFrameworkCore;
using SimpleETicketPlatform.Core.Contacts;
using SimpleETicketPlatform.Core.Models.Actors;
using SimpleETicketPlatform.Core.Services;
using SimpleETicketPlatform.Infrastructure.Data;
using SimpleETicketPlatform.Infrastructure.Data.Models;
using SimpleETicketPlatform.Infrastructure.Repository;
using NUnit.Framework; 

namespace SimpleETicketPlatform.Tests
{
    [TestFixture]
    public class ActorsServiceTests
    {
        private IRepository repository;
        private IActorsService actorsService;
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
            actorsService = new ActorsService(repository);
        }
        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Dispose();
        }
        [Test]
        public async Task AddNewActorAsync_ShouldAddActor()
        {
            var model = new ActorFormViewModel()
            {
                Biography = "Test",
                FullName = "Test Test",
                ProfilePictureURL = "test"
            };
            await actorsService.AddNewActorAsync(model);
            var actor = await repository.GetByIdAsync<Actor>(1);
            Assert.AreEqual(1, await repository.AllReadOnly<Actor>().CountAsync());
            Assert.AreEqual("Test", actor.Biography);
            Assert.AreEqual("Test Test", actor.FullName);
            Assert.AreEqual("test", actor.ProfilePictureURL);
        }
        [Test]
        public async Task ActorExistsByIdAsyncShouldReturnTrue()
        {
            var actor = new Actor { Id = 1 };
            await repository.AddAsync(actor);
            await repository.SaveChangesAsync();
            var result = await actorsService.ActorExistsByIdAsync(1);
            Assert.IsTrue(result);
        }
        [Test]
        public async Task ActorExistsByIdAsyncShouldReturnFalse()
        {
            var actor = new Actor { Id = 1 };
            await repository.AddAsync(actor);
            await repository.SaveChangesAsync();
            var result = await actorsService.ActorExistsByIdAsync(2);
            Assert.IsFalse(result);
        }
        [Test]
        public async Task DeleteActorAsync_ShoulDeleteActor()
        {
            var actor = new Actor { Id = 1 };
            await repository.AddAsync(actor);
            await repository.SaveChangesAsync();
            await actorsService.DeleteActorAsync(1);
            var Deletedctor = await repository.GetByIdAsync<Actor>(1);
            Assert.AreEqual(0, await repository.AllReadOnly<Actor>().CountAsync());
            Assert.IsNull(Deletedctor);
        }
        [Test]
        public async Task EditActorAsync_ShouldEditActor()
        {
            var model = new ActorFormViewModel()
            {
                Biography = "Test",
                FullName = "Test Test",
                ProfilePictureURL = "test"
            };
            await actorsService.AddNewActorAsync(model);
            var modelToEdit = new ActorFormViewModel()
            {
                Biography = "Test1",
                FullName = "Test1 Test1",
                ProfilePictureURL = "test1"
            };
            await actorsService.EditActorAsync(1, modelToEdit);
            var actor = await repository.GetByIdAsync<Actor>(1);
            Assert.AreEqual(1, await repository.AllReadOnly<Actor>().CountAsync());
            Assert.AreEqual("Test1", actor.Biography);
            Assert.AreEqual("Test1 Test1", actor.FullName);
            Assert.AreEqual("test1", actor.ProfilePictureURL);
        }
        [Test]
        public async Task GetActorForDeleteAsync_ShouldReturnActorIndexViewModel()
        {
            var model = new ActorFormViewModel()
            {
                Biography = "Test",
                FullName = "Test Test",
                ProfilePictureURL = "test"
            };
            await actorsService.AddNewActorAsync(model);

            var result = await actorsService.GetActorForDeleteAsync(1);
            Assert.AreEqual("Test Test", result.FullName);
            Assert.AreEqual(1, result.Id);
        }
        [Test]
        public async Task GetActorForEditAsync_ShouldReturnActorFormViewModel()
        {
            var model = new ActorFormViewModel()
            {
                Biography = "Test",
                FullName = "Test Test",
                ProfilePictureURL = "test"
            };
            await actorsService.AddNewActorAsync(model);

            var result = await actorsService.GetActorForEditAsync(1);
            Assert.AreEqual("Test Test", result.FullName);
            Assert.AreEqual("test", result.ProfilePictureURL);
            Assert.AreEqual("Test", result.Biography);
            Assert.AreEqual(1, result.Id);
        }
        [Test]
        public async Task GetDetailsForActorAsync_ShouldReturnActorDetailsViewModel()
        {
            var model = new ActorFormViewModel()
            {
                Biography = "Test",
                FullName = "Test Test",
                ProfilePictureURL = "test"
            };
            await actorsService.AddNewActorAsync(model);

            var result = await actorsService.GetDetailsForActorAsync(1);
            Assert.AreEqual("Test Test", result.FullName);
            Assert.AreEqual("test", result.ProfilePictureURL);
            Assert.AreEqual("Test", result.Biography);
            Assert.AreEqual(1, result.Id);
        }
        [Test]
        public async Task GetActorsNamesAsync_ShouldReturnIEnumerableActorNamesViewModel()
        {
            var model = new ActorFormViewModel()
            {
                FullName = "Test Test",
            };
            var model2 = new ActorFormViewModel()
            {
                FullName = "Test1 Test",
            };
            await actorsService.AddNewActorAsync(model);
            await actorsService.AddNewActorAsync(model2);
            var result = await actorsService.GetActorsNamesAsync();

            Assert.AreEqual("Test", result.First().FirstName);
            Assert.AreEqual("Test1", result.Skip(1).First().FirstName);
            Assert.AreEqual(2, result.Count());
        }
        [Test]
        public async Task GetAllActorsAsync_ShouldReturnFilteredActorsViewModelWithoutSearchTerm()
        {
            var model = new ActorFormViewModel()
            {
                FullName = "Test Test",
            };
            var model2 = new ActorFormViewModel()
            {
                FullName = "Test1 Test",
            };
            await actorsService.AddNewActorAsync(model);
            await actorsService.AddNewActorAsync(model2);
            var result = await actorsService.GetAllActorsAsync(string.Empty);

            Assert.AreEqual("Test Test", result.Actors.First().FullName);
            Assert.AreEqual("Test1 Test", result.Actors.Skip(1).First().FullName);
            Assert.AreEqual(2, result.ActorsMatched);
        }
        [Test]
        public async Task GetAllActorsAsync_ShouldReturnFilteredActorsViewModelWithSearchTerm()
        {
            var model = new ActorFormViewModel()
            {
                FullName = "A",
            };
            var model2 = new ActorFormViewModel()
            {
                FullName = "B",
            };
            await actorsService.AddNewActorAsync(model);
            await actorsService.AddNewActorAsync(model2); 
            var result = await actorsService.GetAllActorsAsync("A");

            Assert.AreEqual("A", result.Actors.First().FullName);
            Assert.AreEqual(1, result.ActorsMatched);
        }

    }
}