namespace TrailVenturesSystem.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using TrailVenturesSystem.Data;
    using TrailVenturesSystem.Data.Models;
    using TrailVenturesSystem.Services.Data.Interfaces;
    using TrailVenturesSystem.Web.ViewModels.Hut;
    using TrailVenturesSystem.Web.ViewModels.Mountain;

    public class MountainService : IMountainService
    {
        private readonly TrailVenturesDbContext dbContext;
        
        public MountainService(TrailVenturesDbContext dbContext)
        {
            this.dbContext = dbContext;           
        }

        public async Task<IEnumerable<string>> AllMountainNamesAsync()
        {
            IEnumerable<string> allNames = await this.dbContext
                .Mountains
                .Select(m => m.Name)
                .ToArrayAsync();

            return allNames;
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

        public async Task<IEnumerable<AllMountainsViewModel>> AllMountainsForListAsync()
        {
            IEnumerable<AllMountainsViewModel> allMountains = await this.dbContext
                .Mountains
                .AsNoTracking()
                .Select(m => new AllMountainsViewModel()
                {
                    Id = m.Id,
                    Name = m.Name
                })
                .ToArrayAsync();

            return allMountains;  
        }

        public async Task<int> CreateAndReturnIdAsync(MountainFormModel formModel)
        {
           
            Mountain mountain = new Mountain
            {            
                Name = formModel.Name
            };

            await this.dbContext.Mountains.AddAsync(mountain);
            await this.dbContext.SaveChangesAsync();

            return mountain.Id;
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            bool result =await this.dbContext
                .Mountains
                .AnyAsync(m => m.Id == id);

            return result;
        }

        public async Task<MountainDetailsViewModel> GetDetailsByIdAsync(int id)
        {
            Mountain mountain = await dbContext
                .Mountains
                .Include(m=>m.Huts)
                .FirstAsync(m => m.Id == id);

            MountainDetailsViewModel viewModel = new MountainDetailsViewModel()
            {
                Id=mountain.Id,
                Name=mountain.Name
            };
            
            HashSet<HutInfoOnTripViewModel> hutsDetails = new HashSet<HutInfoOnTripViewModel>();

            if (mountain.Huts.Count != 0)
            {
                foreach(Hut hut in mountain.Huts)
                {
                    //only add to list if hut is active
                    if (hut.IsActive)
                    {
                        HutInfoOnTripViewModel hutDetails = new HutInfoOnTripViewModel()
                        {
                            Id=hut.Id,
                            Name = hut.Name,
                            HostPhoneNumber = hut.HostPhoneNumber,
                            Altitude = hut.Altitude,
                            PricePerNight = hut.PricePerNight
                        };

                        hutsDetails.Add(hutDetails);
                    }
                    
                }
            }
            viewModel.Huts = hutsDetails;

            return viewModel;
        }

        public async Task<string> GetNameByIdAsync(int id)
        {
            Mountain result = await this.dbContext
                .Mountains
                .FirstAsync(m => m.Id == id);

            return result.Name;
        }
    }
}
