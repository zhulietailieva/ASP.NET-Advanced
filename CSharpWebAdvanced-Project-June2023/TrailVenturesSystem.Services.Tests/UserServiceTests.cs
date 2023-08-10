namespace TrailVenturesSystem.Services.Tests
{
    using Microsoft.EntityFrameworkCore;

    using Data.Interfaces;
    using TrailVenturesSystem.Data;
    using TrailVenturesSystem.Data.Models;
    using Web.ViewModels.Guide;

    using static DatabaseSeeder;
    using TrailVenturesSystem.Services.Data;

    public class UserServiceTests
    {
        private DbContextOptions<TrailVenturesDbContext> dbOptions;
        private TrailVenturesDbContext dbContext;

        private IUserService userService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<TrailVenturesDbContext>()
                .UseInMemoryDatabase("TrailVenturesInMemorty" + Guid.NewGuid().ToString()).Options;

            this.dbContext = new TrailVenturesDbContext(this.dbOptions, false);

            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.userService = new UserService(this.dbContext);

        }

        [Test]
        public async Task AddInfoShouldUpdateUserInDatabase()
        {
            await this.userService.AddPersonalInfoAsync(HikersUsers[0].Id.ToString(), "test");

            Assert.IsNotNull(HikersUsers[0].PersonalInfo);
        }

        [Test]
        public async Task GetFullNameByEmailShouldReturnCorrectValue()
        {
            string result =await this.userService
                .GetFullNameByEmailAsync(HikersUsers[0].Email);

            Assert.That(result, Is.EqualTo(HikersUsers[0].FirstName + ' ' + HikersUsers[0].LastName));

        }

        [Test]
        public async Task GetFullNameByUserIdShouldReturnCorrectValue()
        {
            string result = await this.userService
                .GetFullNameByIdAsync(GuideUser.Id.ToString());

            Assert.That(result, Is.EqualTo(GuideUser.FirstName + " " + GuideUser.LastName));

        }

    }
}
