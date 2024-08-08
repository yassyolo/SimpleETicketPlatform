using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using SimpleETicketPlatform.Core.Contacts;
using SimpleETicketPlatform.Core.Models.Cinemas;
using SimpleETicketPlatform.Core.Services;
using SimpleETicketPlatform.Infrastructure.Data;
using SimpleETicketPlatform.Infrastructure.Data.Models;
using SimpleETicketPlatform.Infrastructure.Repository;


namespace SimpleETicketPlatform.Tests
{
    [TestFixture]
    public class CinemasServiceTests
    {
        private IRepository repository;
        private ICinemasService cinemasService;
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
            cinemasService = new CinemasService(repository);
        }
        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Dispose();
        }
        [Test]
        public async Task AddCinemaAsync_ShouldAddCinema()
        {
            var model = new CinemaFormViewModel()
            {
                Description = "Test",
                Name = "Test Test",
                Logo = "test"
            };
            await cinemasService.AddCinemaAsync(model);
            var cinema = await repository.GetByIdAsync<Cinema>(1);
            Assert.AreEqual(1, await repository.AllReadOnly<Cinema>().CountAsync());
            Assert.AreEqual("Test", cinema.Description);
            Assert.AreEqual("Test Test", cinema.Name);
            Assert.AreEqual("test", cinema.Logo);
        }
        [Test]
        public async Task CinemaExistsByIdAsyncShouldReturnTrue()
        {
            var cinema = new Cinema { Id = 1 };
            await repository.AddAsync(cinema);
            await repository.SaveChangesAsync();
            var result = await cinemasService.CinemaExistsByIdAsync(1);
            Assert.IsTrue(result);
        }
        [Test]
        public async Task CinemaExistsByIdAsyncShouldReturnFalse()
        {
            var cinema = new Cinema { Id = 1 };
            await repository.AddAsync(cinema);
            await repository.SaveChangesAsync();
            var result = await cinemasService.CinemaExistsByIdAsync(2);
            Assert.IsFalse(result);
        }
        [Test]
        public async Task DeleteCinemaAsync_ShoulDeleteCinema()
        {
            var cinema = new Cinema { Id = 1 };
            await repository.AddAsync(cinema);
            await repository.SaveChangesAsync();
            await cinemasService.DeleteCinemaAsync(1);
            var Deletedcinema = await repository.GetByIdAsync<Cinema>(1);
            Assert.AreEqual(0, await repository.AllReadOnly<Cinema>().CountAsync());
            Assert.IsNull(Deletedcinema);
        }
        [Test]
        public async Task EditCinemaAsync_ShouldEditCinema()
        {
            var model = new CinemaFormViewModel()
            {
                Description = "Test",
                Name = "Test Test",
                Logo = "test"
            };
            await cinemasService.AddCinemaAsync(model);
            var modelToEdit = new CinemaFormViewModel()
            {
                Description = "Test1",
                Name = "Test1 Test",
                Logo = "test1"
            };
            await cinemasService.EditCinemaAsync(1, modelToEdit);
            var cinema = await repository.GetByIdAsync<Cinema>(1);
            Assert.AreEqual(1, await repository.AllReadOnly<Cinema>().CountAsync());
            Assert.AreEqual("Test1", cinema.Description);
            Assert.AreEqual("Test1 Test", cinema.Name);
            Assert.AreEqual("test1", cinema.Logo);
        }
        [Test]
        public async Task GetActorForDeleteAsync_ShouldReturnCinemaIndexViewModel()
        {
            var model = new CinemaFormViewModel()
            {
                Description = "Test",
                Name = "Test Test",
                Logo = "test"
            };
            await cinemasService.AddCinemaAsync(model);

            var result = await cinemasService.GetCinemaForDeleteAsync(1);
            Assert.AreEqual("Test Test", result.Name);
            Assert.AreEqual(1, result.Id);
        }
        [Test]
        public async Task v_ShouldReturnActorFormViewModel()
        {
            var model = new CinemaFormViewModel()
            {
                Description = "Test",
                Name = "Test Test",
                Logo = "test"
            };
            await cinemasService.AddCinemaAsync(model);

            var cinema = await cinemasService.GetCinemaForEditAsync(1);
            Assert.AreEqual("Test", cinema.Description);
            Assert.AreEqual("Test Test", cinema.Name);
            Assert.AreEqual("test", cinema.Logo);
            Assert.AreEqual(1, cinema.Id);
        }
        [Test]
        public async Task GetDetailsForCinemaAsync_ShouldReturnCinemaDetailsViewModel()
        {
            var model = new CinemaFormViewModel()
            {
                Description = "Test",
                Name = "Test Test",
                Logo = "test"
            };
            await cinemasService.AddCinemaAsync(model);

            var cinema = await cinemasService.GetDetailsForCinemaAsync(1);
            Assert.AreEqual("Test", cinema.Description);
            Assert.AreEqual("Test Test", cinema.Name);
            Assert.AreEqual("test", cinema.Logo);
            Assert.AreEqual(1, cinema.Id);
        }
        [Test]
        public async Task GetCinemaNamesAsync_ShouldReturnIEnumerableCinemaIndexViewModel()
        {
            var model = new CinemaFormViewModel()
            {
                Name = "Test",
            };
            var model2= new CinemaFormViewModel()
            {
                Name = "Test1",
            };
            await cinemasService.AddCinemaAsync(model);
            await cinemasService.AddCinemaAsync(model2);

            var result = await cinemasService.GetCinemaNamesAsync();
            Assert.AreEqual("Test", result.First().Name);
            Assert.AreEqual("Test1", result.Skip(1).First().Name);
            Assert.AreEqual(2, result.Count());
        }
        [Test]
        public async Task GetAllCinemasAsync_ShouldReturnFilteredCinemasViewModelWithoutSearchTerm()
        {
            dbContext.Database.EnsureDeleted();
            var model = new CinemaFormViewModel()
            {
                Name = "Test",
            };
            var model2 = new CinemaFormViewModel()
            {
                Name = "Test1",
            };
            await cinemasService.AddCinemaAsync(model);
            await cinemasService.AddCinemaAsync(model2);
            var result = await cinemasService.GetAllCinemasAsync(string.Empty);

            Assert.AreEqual("Test", result.Cinemas.First().Name);
            Assert.AreEqual("Test1", result.Cinemas.Skip(1).First().Name);
            Assert.AreEqual(2, result.CinemasMatched);
        }
        [Test]
        public async Task GetAllCinemasAsync_ShouldReturnFilteredCinemasViewModelWithSearchTerm()
        {
            var model = new CinemaFormViewModel()
            {
                Name = "A",
            };
            var model2 = new CinemaFormViewModel()
            {
                Name = "B",
            };
            await cinemasService.AddCinemaAsync(model);
            await cinemasService.AddCinemaAsync(model2);
            var result = await cinemasService.GetAllCinemasAsync("A");

            Assert.AreEqual("A", result.Cinemas.First().Name);
            Assert.AreEqual(1, result.CinemasMatched);
        }
    }
}
