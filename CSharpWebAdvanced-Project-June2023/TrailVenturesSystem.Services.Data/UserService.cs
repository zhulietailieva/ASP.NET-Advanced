namespace TrailVenturesSystem.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TrailVenturesSystem.Data;
    using TrailVenturesSystem.Data.Models;
    using TrailVenturesSystem.Services.Data.Interfaces;
    //using TrailVenturesSystem.Services.Mapping;
    using TrailVenturesSystem.Web.ViewModels.User;

    public class UserService : IUserService
    {
        private readonly TrailVenturesDbContext dbContext;
       
        public UserService(TrailVenturesDbContext dbContext )
        {
            this.dbContext = dbContext;           
        }

        public async Task AddPersonalInfoAsync(string userId,string personalInfo)
        {
            var user = await this.dbContext
                .Users
                .FirstAsync(u => u.Id.ToString() == userId);

            user.PersonalInfo = personalInfo;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserViewModel>> AllASync()
        {
            List<UserViewModel> allUsers =await this.dbContext
                .Users
                .Select(u => new UserViewModel()
                {
                    Id = u.Id.ToString(),
                    Email = u.Email,
                    FullName = u.FirstName + " " + u.LastName
                }).ToListAsync();

            foreach(UserViewModel user in allUsers)
            {
                Guide? guide = this.dbContext
                    .Guides
                    .FirstOrDefault(g => g.UserId.ToString() == user.Id);

                if(guide != null)
                {
                    user.PhoneNumber = guide.PhoneNumber;
                }
                else
                {
                    user.PhoneNumber = string.Empty;
                }
            }

            return allUsers;
           /* IEnumerable<UserViewModel> guides = await this.dbContext
                .Guides
                .Include(g => g.User)
                .To<UserViewModel>()
                .ToArrayAsync();
            allUsers.AddRange(guides);*/
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

        public async Task<string> GetFullNameByIdAsync(string userId)
        {
            ApplicationUser? user = await this.dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Id.ToString() == userId);

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
