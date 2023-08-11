namespace TrailVenturesSystem.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;
    using TrailVenturesSystem.Data;
    using TrailVenturesSystem.Data.Models;
    using TrailVenturesSystem.Services.Data.Interfaces;
    using TrailVenturesSystem.Web.ViewModels.Guide;

    public class GuideService : IGuideService
    {
        private readonly TrailVenturesDbContext dbContext;

        public GuideService(TrailVenturesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Create(string userId, BecomeGuideFormModel model)
        {
            Guide newGuide = new Guide
            {
                PhoneNumber = model.PhoneNumber,
                YearsOfExperience=model.YearsOfExperience,
                UserId = Guid.Parse(userId),

            };
            await this.dbContext.Guides.AddAsync(newGuide);
            await this.dbContext.SaveChangesAsync();

        }

        public async Task<string> GetFullNameByIdAsync(string guideId)
        {
            Guide guide = await this.dbContext
                .Guides
                .FirstAsync(g => g.Id.ToString() == guideId);

            var currentUser = await this.dbContext
               .Users
               .FirstAsync(u => u.Id.ToString() == guide.UserId.ToString());

            return currentUser.FirstName + " " + currentUser.LastName;
        }

        public async Task<string?> GetGuideIdByUserIdAsync(string userId)
        {
            Guide? guide = await this.dbContext
                .Guides
                .FirstOrDefaultAsync(g => g.UserId.ToString() == userId);

            if (guide == null)
            {
                return null;
            }

            return guide.Id.ToString();
        }

        public async Task<string> GetGuideUserIdByPhoneNumberAsync(string phoneNumber)
        {
            Guide guide = await this.dbContext
                .Guides
                .FirstAsync(g => g.PhoneNumber == phoneNumber);

            return guide.UserId.ToString();
        }

        public async Task<bool> GuideExistsByPhoneNumberAsync(string phoneNumber)
        {
            bool result = await dbContext
               .Guides
               .AnyAsync(g => g.PhoneNumber==phoneNumber);

            return result;
        }

        public async Task<bool> GuideExistsByUserIdAsync(string userId)
        {
            bool result = await dbContext
                .Guides
                .AnyAsync(g => g.UserId.ToString() == userId);

            return result;
        }

        public async Task<bool> HasTripsByUserIdAsync(string userId)
        {
            ApplicationUser? user =await this.dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Id.ToString() == userId);

            if (user == null)
            {
                return false;
            }
            return user.EnrolledTrips.Any();
        }

        public async Task<bool> HasTripWithIdAsync(string? userId, string tripId)
        {
            Guide? guide =await this.dbContext
                .Guides
                .Include(g=>g.CreatedTrips)
                .FirstOrDefaultAsync(g => g.UserId.ToString() == userId);

            if (guide == null)
            {
                return false;
            }

            tripId = tripId.ToLower();
            return guide.CreatedTrips.Any(t => t.Id.ToString() == tripId);

        }
    }
}
