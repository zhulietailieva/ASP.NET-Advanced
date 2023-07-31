namespace TrailVenturesSystem.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;
    using TrailVenturesSystem.Data;
    using TrailVenturesSystem.Data.Models;
    using TrailVenturesSystem.Services.Data.Interfaces;

    public class UserService : IUserService
    {
        private readonly TrailVenturesDbContext dbContext;
        public UserService(TrailVenturesDbContext dbContext)
        {
            this.dbContext = dbContext;
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
    }
}
