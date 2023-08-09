namespace TrailVenturesSystem.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;
    using TrailVenturesSystem.Data;
    using TrailVenturesSystem.Data.Models;
    using TrailVenturesSystem.Services.Data.Interfaces;
    using TrailVenturesSystem.Web.ViewModels.User;

    public class UserService : IUserService
    {
        private readonly TrailVenturesDbContext dbContext;
        private readonly IGuideService guideService;
        public UserService(TrailVenturesDbContext dbContext, IGuideService guideService)
        {
            this.dbContext = dbContext;
            this.guideService = guideService;
        }

        public async Task AddPersonalInfoAsync(string userId,string personalInfo)
        {
            var user = await this.dbContext
                .Users
                .FirstAsync(u => u.Id.ToString() == userId);

            user.PersonalInfo = personalInfo;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<string> GetFullNameByEmailAsync(string email)
        {
            ApplicationUser? user =await this.dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                return string.Empty;
            }

            return $"{user.FirstName} {user.LastName}";
        }

        public async Task<ProfileViewModel> GetUserDataForProfileAsync(string userId)
        {
            var user = await dbContext.Users
                .FirstAsync(u => u.Id.ToString() == userId);

            ProfileViewModel result = new ProfileViewModel
            {
                Id=user.Id.ToString(),
                Email = user.UserName.ToString(),
                FirstName = user.FirstName,
                LastName = user.LastName
            };
            //check if any personal info
            if (user.PersonalInfo != null)
            {
                result.PersonalInformation = user.PersonalInfo;
            }
            //check if user is guide to add addition info
            Guide? guide = await this.dbContext
                .Guides
                .FirstOrDefaultAsync(g => g.UserId.ToString() == userId);

            if (guide != null)
            {
                result.GuideId = guide.Id.ToString();
                result.PhoneNumber = guide.PhoneNumber;
                result.YearsOfExperience = guide.YearsOfExperience;
            }

            return result;
        }
    }
}
