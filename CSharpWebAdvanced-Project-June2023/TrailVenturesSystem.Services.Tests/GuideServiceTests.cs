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
    }
}