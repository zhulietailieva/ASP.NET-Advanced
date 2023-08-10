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

    public class TripServiceTests
    {
        private DbContextOptions<TrailVenturesDbContext> dbOptions;
        private TrailVenturesDbContext dbContext;

        private ITripService tripService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<TrailVenturesDbContext>()
                .UseInMemoryDatabase("TrailVenturesInMemorty" + Guid.NewGuid().ToString()).Options;

            this.dbContext = new TrailVenturesDbContext(this.dbOptions, false);

            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.tripService = new TripService(this.dbContext);

        }

        [Test]

        public async Task AllByGuideIdShouldReturnCorrectNumberOfTrips()
        {
            var result = await this.tripService
                .AllByGuideIdAsync(GuideGuideWithTrips.Id.ToString());

            Assert.That(result.Count, Is.EqualTo(1));
        }

        [Test]
        public async Task AllByUserIdShouldReturnCorrectNumberOfTrips()
        {
            var result = await this.tripService
                .AllByUserIdAsync(HikersUsers[0].Id.ToString());

            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task AssureDeletingTripByIdAsyncWorks()
        {
            await this.tripService.DeleteTripByIdAsync(TripToDelete.Id.ToString());
            this.dbContext.SaveChanges();

            Assert.IsFalse(TripToDelete.IsActive);
        }

        [Test]
        public async Task ExistsByIdShouldReturnTrueIfExists()
        {
            bool result = await this.tripService
                .ExistsByIdAsync(RegisteredTrip.Id.ToString());

            Assert.IsTrue(result);
        }

        [Test]
        public async Task ExistsByIdShouldReturnFalseIfNotExists()
        {
            bool result = await this.tripService
                .ExistsByIdAsync("1");

            Assert.IsFalse(result);
        }

        [Test]
        public async Task IsFullByIdAsyncShouldReturnFalseWhenNotFull()
        {
            bool result = await this.tripService
                .IsFullByIdAsync(RegisteredTrip.Id.ToString());

            Assert.IsFalse(result);
        }

        [Test]
        public async Task IsFullByIdAsyncShouldReturnFalseWhenFull()
        {
            bool result = await this.tripService
                .IsFullByIdAsync(TripToDelete.Id.ToString());

            Assert.IsTrue(result);
        }

        [Test]
        public async Task isGuideWithIdCreatorToTripShouldReturnTrueIfCorrect()
        {
            bool result = await this.tripService
                .IsGuideWithIdCreatorOfTripWithIdAsync(
                    RegisteredTrip.Id.ToString(), GuideGuideWithTrips.Id.ToString());

            Assert.IsTrue(result);
        }

        [Test]
        public async Task isGuideWithIdCreatorToTripShouldReturnFalseIfNotCorrect()
        {
            bool result = await this.tripService
                .IsGuideWithIdCreatorOfTripWithIdAsync(
                    RegisteredTrip.Id.ToString(), GuideGuide.Id.ToString());

            Assert.IsFalse(result);
        }

        [Test]
        public async Task IsUserWithIdPArtOfTripSHouldReturnTrueWhenCorrect()
        {
            bool result = await this.tripService
                .IsUserWithIdPartOfTripByIdAsync(
                TripToDelete.Id.ToString(),HikersUsers[0].Id.ToString());       

            Assert.IsTrue(result);
        }

        [Test]
        public async Task IsUserWithIdPArtOfTripSHouldReturnFalseWhenNotCorrect()
        {
            bool result = await this.tripService
                .IsUserWithIdPartOfTripByIdAsync(
                RegisteredTrip.Id.ToString(), GuideUserWithDeletedTrip.Id.ToString());

            Assert.IsFalse(result);
        }

    }
}
