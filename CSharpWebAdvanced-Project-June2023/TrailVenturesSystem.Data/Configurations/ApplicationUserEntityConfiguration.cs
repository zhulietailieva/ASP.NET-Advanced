namespace TrailVenturesSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TrailVenturesSystem.Data.Models;

    public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder
                .Property(u => u.FirstName)
                .HasDefaultValue("Test");

            builder
                .Property(u => u.LastName)
                .HasDefaultValue("Testov");

            //builder.HasData(GenerateUsers());
        }

        private ApplicationUser[] GenerateUsers()
        {
            ICollection<ApplicationUser> users = new HashSet<ApplicationUser>();

            ApplicationUser user;

            user = new ApplicationUser()
            {
                UserName = "peshoGuide@guides.com",
                NormalizedUserName = "PESHOGUIDE@GUIDES.COM",
                Email = "peshoGuide@guides.com",
                NormalizedEmail = "PESHOGUIDE@GUIDES.COM",
                EmailConfirmed = true,
                PasswordHash = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
                ConcurrencyStamp = "9cc1162e-ad55-4a75-a1b1-e1f3c011f9c9",
                SecurityStamp = "262f7f6f-772f-41bf-b636-34b23ecb2cbb",
                TwoFactorEnabled = false,
                FirstName = "Pesho",
                LastName = "Peshev"
            };

            users.Add(user);

            //admin@trailventures.bg
            user = new ApplicationUser()
            {
                UserName = "admin@trailventures.bg",
                NormalizedUserName = "ADMIN@TRAILVENTURES.BG",
                Email = "admin@trailventures.bg",
                NormalizedEmail = "ADMIN@TRAILVENTURES.BG",
                EmailConfirmed = true,
                PasswordHash = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
                ConcurrencyStamp = "1c7d051d-22e4-42f9-a778-29be4c7b94f9",
                SecurityStamp = "4a0e4860-6119-476e-85ca-2f2a39bb7c1f",
                TwoFactorEnabled = false,
                FirstName = "Admin",
                LastName = "Admin"
            };
            users.Add(user);

            return users.ToArray();

        }
    }
}
