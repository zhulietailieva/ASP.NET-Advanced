namespace TrailVenturesSystem.Services.Tests
{
    using TrailVenturesSystem.Data;
    using TrailVenturesSystem.Data.Models;

    public static class DatabaseSeeder
    {
        public static ApplicationUser GuideUser;
        public static Guide GuideGuide;
        public static List<ApplicationUser> HikersUsers;
        
       public static ApplicationUser GuideUserWithTrips;
       public static Guide GuideGuideWithTrips;

        public static Trip RegisteredTrip;



        public static void SeedDatabase(TrailVenturesDbContext dbContext)
        {
            RegisteredTrip = new Trip()
            {
                Title = "Botev's Quest: Conquering the Summit of Stara Planina",
                MountainId = 5,
                StartDate = new DateTime(2023, 6, 30),
                ReturnDate = new DateTime(2023, 6, 30),
                Description = "Welcome to an exhilarating journey of a lifetime as we embark on a challenging trek to conquer the majestic Mount Botev in the stunning Stara Planina mountain range of Bulgaria. This thrilling expedition is set to begin on the morning of 21st July 2023, promising an unforgettable experience for all participants. So, lace up your boots, pack your bags, and get ready for an adventure like no other!\r\n\r\nMeeting Place:\r\nOur exciting adventure will commence at the picturesque town of Kalofer, located in the foothills of Stara Planina.",
                GroupMaxSize = 10,
                PricePerPerson = 10.00M,
                Guide=GuideGuideWithTrips,
                IsActive = true
            };

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

           GuideUserWithTrips = new ApplicationUser()
            {
                UserName = "futureAgent@agents.com",
                NormalizedUserName = "FUTUREAGENT@AGENTS.COM",
                Email = "futureAgent@agents.com",
                NormalizedEmail = "FUTUREAGENT@AGENTS.COM",
                EmailConfirmed = true,
                PasswordHash = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
                ConcurrencyStamp = "fe179edc-814b-4c77-95a3-3c3c10a5128b",
                SecurityStamp = "130fee45-a4f9-48a7-97af-00537530f970",
                TwoFactorEnabled = false,
                FirstName = "Future",
                LastName = "Agent"
            };

            GuideGuideWithTrips = new Guide()
            {
                PhoneNumber = "+359888887777",
                User = GuideUserWithTrips,
                YearsOfExperience = 1,
                CreatedTrips = new List<Trip>()
                {
                    RegisteredTrip
                }                
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
                    LastName = "Goshev",
                    EnrolledTrips=new List<Trip>()
                    {
                        RegisteredTrip
                    }
                }
            };

            GuideGuide = new Guide()
            {
                PhoneNumber = "+359888888888",
                User = GuideUser,
                YearsOfExperience = 2
            };
                         

            dbContext.Users.Add(GuideUser);
            dbContext.Users.Add(HikersUsers[0]);
            dbContext.Guides.Add(GuideGuide);

           dbContext.Guides.Add(GuideGuideWithTrips);
           dbContext.Users.Add(GuideUserWithTrips);
            dbContext.Trips.Add(RegisteredTrip);

            dbContext.SaveChanges();


        }
    }
}
