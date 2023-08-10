namespace TrailVenturesSystem.Services.Tests
{
    using TrailVenturesSystem.Data;
    using TrailVenturesSystem.Data.Models;

    public static class DatabaseSeeder
    {
        public static ApplicationUser GuideUser;
        public static List<ApplicationUser> HikersUsers;
        public static Guide Guide;

        public static void SeedDatabase(TrailVenturesDbContext dbContext)
        {


            GuideUser = new ApplicationUser()
            {
                UserName = "peshoGuide@guides.com",
                NormalizedUserName = "PESHOGUIDE@GUIDES.COM",
                Email = "peshoGuide@guides.com",
                NormalizedEmail = "PESHOGUIDE@GUIDES.COM",
                EmailConfirmed = true,
                PasswordHash = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
                ConcurrencyStamp= "9cc1162e-ad55-4a75-a1b1-e1f3c011f9c9",
                SecurityStamp = "262f7f6f-772f-41bf-b636-34b23ecb2cbb",
                TwoFactorEnabled = false,
                FirstName = "Pesho",
                LastName = "Peshev"
            };

            HikersUsers = new List<ApplicationUser>()
            {
                new ApplicationUser()
                {
                    UserName = "goshoHiker@hikers.com",
                    NormalizedUserName = "GOSHOHIKER@HIKERS.COM",
                    Email = "goshoHiker@hikers.com",
                    NormalizedEmail = "GOSHOHIKER@HIKERS.COM",
                    EmailConfirmed = true,
                    PasswordHash = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
                    ConcurrencyStamp="136571e5-e5cf-4225-a342-a846c96f4b8f",
                    SecurityStamp = "972b62ef-09b5-481b-869d-58a74ba7489e",
                    TwoFactorEnabled = false,
                    FirstName = "Gosho",
                    LastName = "Goshev"
                }
            };

            Guide = new Guide()
            {
                PhoneNumber = "+359888888888",
                User = GuideUser,
                YearsOfExperience = 2
            };

            dbContext.Users.Add(GuideUser);
            dbContext.Users.Add(HikersUsers[0]);
            dbContext.Guides.Add(Guide);

            dbContext.SaveChanges();


        }
    }
}
