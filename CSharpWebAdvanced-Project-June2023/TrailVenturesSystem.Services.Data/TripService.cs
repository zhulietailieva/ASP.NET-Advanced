namespace TrailVenturesSystem.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TrailVenturesSystem.Data;
    using TrailVenturesSystem.Services.Data.Interfaces;
    using TrailVenturesSystem.Web.ViewModels.Home;

    public class TripService : ITripService
    {
        //we are now in a service, so we can use the DbContext
        //Services communicate with the database

        private readonly TrailVenturesDbContext dbContext;
        public TripService(TrailVenturesDbContext dbContext)
        {
            this.dbContext = dbContext; 
        }
        public async Task<IEnumerable<IndexViewModel>> LastFiveTripsAsync()
        {
            //display the 5 latest PLANNED trips
            IEnumerable<IndexViewModel> lastfiveTrips = await this.dbContext
                .Trips
                .OrderByDescending(t => t.StartDate)
                .Take(5)
                .Select(t => new IndexViewModel()
                {
                    Id = t.Id.ToString(),
                    Title = t.Title,
                    //Mountain = t.Mountain,
                    StartDate = t.StartDate.ToString()
                })
                .ToArrayAsync();    //always async when we retrieve from the database

            return lastfiveTrips;
        }
    }
}
