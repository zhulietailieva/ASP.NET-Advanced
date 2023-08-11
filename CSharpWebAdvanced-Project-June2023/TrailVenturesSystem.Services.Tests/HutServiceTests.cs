namespace TrailVenturesSystem.Services.Tests
{
    using Microsoft.EntityFrameworkCore;

    using Data.Interfaces;
    using TrailVenturesSystem.Data;
    using TrailVenturesSystem.Data.Models;
    using Web.ViewModels.Guide;

    using static DatabaseSeeder;
    using TrailVenturesSystem.Services.Data;
    using TrailVenturesSystem.Web.ViewModels.Trip;

    public class HutServiceTests
    {
        private DbContextOptions<TrailVenturesDbContext> dbOptions;
        private TrailVenturesDbContext dbContext;

        private IHutService hutService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<TrailVenturesDbContext>()
                .UseInMemoryDatabase("TrailVenturesInMemorty" + Guid.NewGuid().ToString()).Options;

            this.dbContext = new TrailVenturesDbContext(this.dbOptions, false);

            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.hutService = new HutService(this.dbContext);
        }

        [Test]
        public async Task AllNamesMethodShouldRetrieveNamesCorrectly()
        {
            string[] names = (string[])
                await this.hutService.AllHutsNamesAsync();

            Assert.That(names[0], Is.EqualTo("Hut1"));
            Assert.That(names[1], Is.EqualTo("Hut2"));
        }

        [Test]
        public async Task DeleteShouldSetIsActiveToFalse()
        {
            await this.hutService.DeleteHutByIdAsync(2);

            Assert.That(hut2.IsActive, Is.EqualTo(false));
        }

        [Test]

        public async Task ExistsByIdShouldReturnTrueIfHutExists()
        {
            bool result = await this.hutService
                .ExistsByIdAsync(hut1.Id);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task ExistsByIdShouldReturnFalseIfHutNotExists()
        {
            bool result = await this.hutService
                .ExistsByIdAsync(-1);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task GetHutByIdShouldReturnCorrectHut()
        {
            Hut result = await this.hutService
                .GetHutByIdAsync(hut1.Id);

            Assert.AreEqual(result, hut1);
        }
    }
}
