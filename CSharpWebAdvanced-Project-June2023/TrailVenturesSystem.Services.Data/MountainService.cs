namespace TrailVenturesSystem.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using TrailVenturesSystem.Data;
    using TrailVenturesSystem.Services.Data.Interfaces;
    using TrailVenturesSystem.Web.ViewModels.Mountain;

    public class MountainService : IMountainService
    {
        private readonly TrailVenturesDbContext dbContext;
        public MountainService(TrailVenturesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<TripSelectMountainFormModel>> AllMountainsAsync()
        {
            IEnumerable<TripSelectMountainFormModel> allMountains =await this.dbContext
                .Mountains
                .AsNoTracking()
                .Select(m=>new TripSelectMountainFormModel()
                {
                    Id=m.Id,
                    Name=m.Name
                })
                .ToArrayAsync();

            return allMountains;
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            bool result =await this.dbContext
                .Mountains
                .AnyAsync(m => m.Id == id);

            return result;
        }
    }
}
