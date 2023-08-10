namespace TrailVenturesSystem.Services.Tests
{
    using Microsoft.EntityFrameworkCore;

    using Data.Interfaces;
    using TrailVenturesSystem.Data;
    using TrailVenturesSystem.Data.Models;
    using Web.ViewModels.Guide;

    using static DatabaseSeeder;
    using TrailVenturesSystem.Services.Data;

    public class AgentServiceTests
    {
        //First way is using InMemory Database
        //Pros: Testing flow is the closest to the production scenario
        //Cons: Not a good UNIT test because we're also testing EF Core, it is also hard to arrange scenario
        
        //Second way: Using Mock of IRepository
        //Pros: Good unit testing, tests a single unit and easy push test data
        //Cons: We need repository pattern

        private  DbContextOptions<TrailVenturesDbContext> dbOptions;
        private  TrailVenturesDbContext dbContext;

        private IGuideService guideService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<TrailVenturesDbContext>()
                .UseInMemoryDatabase("TrailVenturesInMemorty" + Guid.NewGuid().ToString()).Options;

            this.dbContext = new TrailVenturesDbContext(this.dbOptions,false);

            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.guideService = new GuideService(this.dbContext);
       
        }


        [Test]
        public async Task GuideExistsByUserIdAsyncShouldReturnTrueWhenExists()
        {
            string existingGuideUserId = GuideUser.Id.ToString();

            bool result = await this.guideService.GuideExistsByUserIdAsync(existingGuideUserId);

            Assert.IsTrue(result);
        }

        [Test]

        public async Task GuideExistsByUserIdShouldReturnFalseWhenNotExists()
        {
            string existingGuideUserId = HikersUsers[0].Id.ToString();

            bool result = await this.guideService.GuideExistsByUserIdAsync(existingGuideUserId);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task GuideExistsByPhoneNumberShouldReturnTrueWhenExists()
        {
            string existingGuideUserNumber = GuideGuide.PhoneNumber;

            bool result = await this.guideService.GuideExistsByPhoneNumberAsync(existingGuideUserNumber);

            Assert.IsTrue(result);
        }
        [Test]
        public async Task GuideExistsByPhoneNumberShouldReturnFalseWhenNoyExist()
        {
            string existingGuideUserNumber = HikersUsers[0].PhoneNumber;

            bool result = await this.guideService.GuideExistsByPhoneNumberAsync(existingGuideUserNumber);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task GetFullNameByUserIdShoulReturnCorrectValue()
        {
            string guideId = GuideGuide.Id.ToString();
            string expectedName = GuideUser.FirstName + " " + GuideUser.LastName;

            string result = await this.guideService.GetFullNameByIdAsync(guideId);

            Assert.That(result, Is.EqualTo(expectedName));
        }

        [Test]
        public async Task GetGuideUserIdByPhoneNumberShouldReturnCorrectValue()
        {
            string phoneNumber = GuideGuide.PhoneNumber;

            string expectedGuideUserId = await this.guideService
                .GetGuideUserIdByPhoneNumberAsync(phoneNumber);

            Assert.That(expectedGuideUserId,Is.EqualTo(GuideGuide.UserId.ToString()));
        }

        [Test]
        public async Task HasTripsByUserIdShouldBeFalseWhenNoTrips()
        {
            bool hasTrips = await this.guideService
                .HasTripsByUserIdAsync(GuideGuide.UserId.ToString());

            Assert.IsFalse(hasTrips);
        }

        [Test]
        public async Task HasTripsByUserIdShouldBeTrueWhenTripsExist()
        {
            Guide guideResult = GuideGuideWithTrips;
            bool hasTrips = await this.guideService
                .HasTripsByUserIdAsync(HikersUsers[0].Id.ToString());
            Assert.IsTrue(hasTrips);
        }

        [Test]
        public async Task HasTripWithExistingIdReturnCorrectValue()
        {
            bool result=await this.guideService
                .HasTripWithIdAsync(GuideGuideWithTrips.UserId.ToString(), RegisteredTrip.Id.ToString());

            Assert.IsTrue(result);
        }

        [Test]
        public async Task HasTripWithNotExistingGuideShouldReturnCorrectValue()
        {
            bool result = await this.guideService
                .HasTripWithIdAsync(GuideGuide.UserId.ToString(), RegisteredTrip.Id.ToString());

            Assert.IsFalse(result);
        }
    }
}