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

    public class MountainServiceTests
    {
        private DbContextOptions<TrailVenturesDbContext> dbOptions;
        private TrailVenturesDbContext dbContext;

        private IMountainService mountainService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<TrailVenturesDbContext>()
                .UseInMemoryDatabase("TrailVenturesInMemorty" + Guid.NewGuid().ToString()).Options;

            this.dbContext = new TrailVenturesDbContext(this.dbOptions, false);

            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.mountainService = new MountainService(this.dbContext);

        }

        [Test]
        public async Task AllNamesShoulReturnCorrectValues()
        {
            string[] names = (string[])
                await this.mountainService.AllMountainNamesAsync();

            Assert.That(names[0], Is.EqualTo("Vitosha"));
            Assert.That(names[1], Is.EqualTo("Rila"));
        }

        [Test]
        public async Task ExistsByIdShoulReturnTrueIfExists()
        {
            bool result = await this.mountainService
                .ExistsByIdAsync(mount1.Id);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task ExistsByIdShoulReturnFalseIfNotExists()
        {
            bool result = await this.mountainService
                .ExistsByIdAsync(-1);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task GetNameByIdShouldReturnCorrectName()
        {
            string result = await this.mountainService
                .GetNameByIdAsync(mount2.Id);

            Assert.That(result, Is.EqualTo("Rila"));
        }
    }          

}
