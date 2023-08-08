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

        public async Task<int> CreateAndReturnIdAsync(HutFormModel formModel)
        {
            Hut hut = new Hut
            {
                Name=formModel.Name,
                HostPhoneNumber=formModel.HostPhoneNumber,
                PricePerNight=formModel.PricePerNight,
                Altitude=formModel.Altitude,
                MountainId=formModel.MountainId
            };

            await this.dbContext.Huts.AddAsync(hut);
            await this.dbContext.SaveChangesAsync();

            return hut.Id;
        }

        public async Task DeleteHutByIdAsync(int hutId)
        {
            Hut hutToDelete = await this.dbContext
                 .Huts
                 .Where(h => h.IsActive)
                 .FirstAsync(h => h.Id == hutId);

            //implementing soft delete
            hutToDelete.IsActive = false;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task EditHutByIdAndFormModelAsync(int hutId, HutFormModel formModel)
        {
            Hut hut = await this.dbContext
                .Huts
                .Where(h => h.IsActive)
                .FirstAsync(h => h.Id == hutId);

            hut.Name = formModel.Name;
            hut.PricePerNight = formModel.PricePerNight;
            hut.HostPhoneNumber = formModel.HostPhoneNumber;
            hut.Altitude = formModel.Altitude;

            await this.dbContext.SaveChangesAsync();
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

        public async Task<HutFormModel> GetHutForEditByIdAsync(int hutId)
        {
            Hut hut = await this.dbContext
                .Huts
                .Include(h => h.Mountain)
                .Where(h => h.IsActive)
                .FirstAsync(h => h.Id == hutId);

            return new HutFormModel
            {
                Name=hut.Name,
                HostPhoneNumber=hut.HostPhoneNumber,
                PricePerNight=hut.PricePerNight,
                Altitude=hut.Altitude,
                MountainId=hut.MountainId
            };
        }

        public async Task<HutPreDeleteViewModel> GetTripForDeleteByIdAsync(int hutId)
        {
            Hut hut = await this.dbContext
                .Huts
                .FirstAsync(h => h.Id == hutId);

            return new HutPreDeleteViewModel{
                Id=hutId,
                Name=hut.Name,
                Altitude=hut.Altitude
            };
        }

    }
}
