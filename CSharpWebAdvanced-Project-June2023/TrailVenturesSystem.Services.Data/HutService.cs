namespace TrailVenturesSystem.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TrailVenturesSystem.Data;
    using TrailVenturesSystem.Data.Models;
    using TrailVenturesSystem.Services.Data.Interfaces;
    using TrailVenturesSystem.Web.ViewModels.Hut;
    using TrailVenturesSystem.Web.ViewModels.Mountain;

    public class HutService : IHutService
    {
        private readonly TrailVenturesDbContext dbContext;

        public HutService(TrailVenturesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<TripSelectHutFormModel>> AllHutsAync()
        {
            IEnumerable<TripSelectHutFormModel> allHuts = await this.dbContext
                .Huts
                .Where(h=>h.IsActive)
                .AsNoTracking()
                .Select(h => new TripSelectHutFormModel
                {
                    Id = h.Id,
                    Name = h.Name,
                    MountainId=h.MountainId

                }).ToArrayAsync();

            return allHuts;
        }

        public async Task<IEnumerable<TripSelectHutFormModel>> AllHutsByMountainIdAsync(string mountainId)
        {
            IEnumerable<TripSelectHutFormModel> allHuts = await this.dbContext
                .Huts
                .Where(h => h.IsActive && h.MountainId.ToString()== mountainId)
                .AsNoTracking()
                .Select(h => new TripSelectHutFormModel
                {
                    Id = h.Id,
                    Name = h.Name,
                    MountainId=h.MountainId
                }).ToArrayAsync();

            return allHuts;
        }

        public async Task<IEnumerable<string>> AllHutsNamesAsync()
        {
            IEnumerable<string> allNames = await this.dbContext
                .Huts
                .Where(h => h.IsActive)
                .Select(h => h.Name)
                .ToArrayAsync();

            return allNames;

        }

        public async Task<bool> ExistsByIdAsync(int hutId)
        {
            bool result =await this.dbContext
                .Huts
                .AnyAsync(h => h.Id == hutId);

            return result;
        }

        public async Task<Hut> GetHutByIdAsync(int hutId)
        {
            Hut result = await this.dbContext
                .Huts.FirstAsync(h => h.Id == hutId);

            return result;
        }
    }
}
