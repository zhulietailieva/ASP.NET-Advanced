namespace TrailVenturesSystem.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;
    using TrailVenturesSystem.Data;
    using TrailVenturesSystem.Services.Data.Interfaces;

    public class GuideService : IGuideService
    {
        private readonly TrailVenturesDbContext dbContext;

        public GuideService(TrailVenturesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<bool> GuideExistsByUserIdAsync(string userId)
        {
            bool result = await dbContext
                .Guides
                .AnyAsync(g => g.UserId.ToString() == userId);

            return result;
        }
    }
}
