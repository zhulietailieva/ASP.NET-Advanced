namespace TrailVenturesSystem.Services.Data
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TrailVenturesSystem.Data;
    using TrailVenturesSystem.Data.Models;
    using TrailVenturesSystem.Services.Data.Interfaces;
    using TrailVenturesSystem.Services.Data.Models.Statistics;
    using TrailVenturesSystem.Services.Data.Models.Trip;
    using TrailVenturesSystem.Services.Mapping;
    using TrailVenturesSystem.Web.ViewModels.Guide;
    using TrailVenturesSystem.Web.ViewModels.Home;
    using TrailVenturesSystem.Web.ViewModels.Trip;
    using TrailVenturesSystem.Web.ViewModels.Trip.Enums;

    public class TripService : ITripService
    {
        //we are now in a service, so we can use the DbContext
        //Services communicate with the database

        private readonly TrailVenturesDbContext dbContext;

        public TripService(TrailVenturesDbContext dbContext)
        {
            this.dbContext = dbContext;
            
        }

        public async Task<AllTripsFilteredAndPagedServiceModel> AllAsync(AllTripsQueryModel queryModel)
        {
            IQueryable<Trip> tripsQuery = this.dbContext
                .Trips
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryModel.Mountain))
            {
                tripsQuery = tripsQuery
                    .Where(t => t.Mountain.Name == queryModel.Mountain);
            }

            if (!string.IsNullOrWhiteSpace(queryModel.SearchString))
            {
                string wildCard = $"%{queryModel.SearchString.ToLower()}%";

                tripsQuery = tripsQuery
                    .Where(t => EF.Functions.Like(t.Title, wildCard) ||
                                EF.Functions.Like(t.Description, wildCard));
            }

            //sorting
            tripsQuery = queryModel.TripSorting switch
            {
                TripSorting.Newest => tripsQuery
                    .OrderByDescending(t => t.CreatedOn),
                TripSorting.Oldest => tripsQuery
                    .OrderBy(t => t.CreatedOn),
                TripSorting.SoonestStartDate => tripsQuery
                    .OrderByDescending(t=>t.StartDate),
                TripSorting.PriceAscending => tripsQuery
                    .OrderBy(t => t.PricePerPerson),
                TripSorting.PriceDescending => tripsQuery
                    .OrderByDescending(t => t.PricePerPerson),
                //default query
                _ => tripsQuery
                    .OrderBy(t => t.Hikers.Count < t.GroupMaxSize)
                    .ThenByDescending(t => t.CreatedOn)
            };

            //pagination
            IEnumerable<TripAllViewModel> allTrips =await tripsQuery
                .Where(t=>t.IsActive)
                .Skip((queryModel.CurrentPage - 1) * queryModel.TripsPerPage)
                .Take(queryModel.TripsPerPage)
                .Select(t => new TripAllViewModel()
                {
                    Id = t.Id.ToString(),
                    Title = t.Title,
                    StartDate = t.StartDate,
                    PricePerPerson = t.PricePerPerson,
                    NotFull = t.Hikers.Count < t.GroupMaxSize,
                    CurrentGroupSize=t.Hikers.Count,
                    MaxGroupSize=t.GroupMaxSize
                }).ToArrayAsync(); //this is where the query is materialized

            int totalTrips = tripsQuery.Count();

            return new AllTripsFilteredAndPagedServiceModel()
            {
                TotalTripsCount = totalTrips,
                Trips = allTrips
            };
        }

        public async Task<IEnumerable<TripAllViewModel>> AllByGuideIdAsync(string guideId)
        {
            IEnumerable<TripAllViewModel> allGuideTrips = await this.dbContext
                .Trips
                .Where(t =>t.IsActive && t.GuideId.ToString() == guideId)
                .Select(t => new TripAllViewModel()
                {
                    Id = t.Id.ToString(),
                    Title = t.Title,
                    StartDate = t.StartDate,
                    PricePerPerson = t.PricePerPerson,
                    NotFull = t.Hikers.Count < t.GroupMaxSize,
                    CurrentGroupSize=t.Hikers.Count,
                    MaxGroupSize=t.GroupMaxSize
                }).ToArrayAsync();

            return allGuideTrips;
        }

        public async Task<IEnumerable<TripAllViewModel>> AllByUserIdAsync(string userId)
        {
            IEnumerable<TripAllViewModel> allUserTrips = await this.dbContext
                .Trips
                .Where(t =>t.IsActive && t.Hikers.Count>0 && t.Hikers.Any(h=>h.Id.ToString()==userId))
                .Select(t => new TripAllViewModel()
                {
                    Id = t.Id.ToString(),
                    Title = t.Title,
                    StartDate = t.StartDate,
                    PricePerPerson = t.PricePerPerson,
                    NotFull = t.Hikers.Count < t.GroupMaxSize,
                    CurrentGroupSize=t.Hikers.Count,
                    MaxGroupSize=t.GroupMaxSize
                    
                }).ToArrayAsync();

            return allUserTrips;
        }

        public async Task<string> CreateAndReturnIdAsync(TripFormModel formModel,string guideId)
        {
            //no need for validation here
            /*
            Trip newTrip = new Trip
            {
                Title = formModel.Title,
                StartDate = formModel.StartDate,
                ReturnDate = formModel.ReturnDate,
                Description = formModel.Description,
                PricePerPerson = formModel.PricePerPerson,
                GroupMaxSize = formModel.GroupMaxSize,
                MountainId = formModel.MountainId,
                GuideId = Guid.Parse(guideId)
            };
            */

            //using AutoMapper instead of the above shown method of creating a trip

            Trip newTrip = AutoMapperConfig.MapperInstance.Map<Trip>(formModel);
            newTrip.GuideId = Guid.Parse(guideId);

            await this.dbContext.Trips.AddAsync(newTrip);
            await this.dbContext.SaveChangesAsync();

            return newTrip.Id.ToString();
        }

        public async Task DeleteTripByIdAsync(string tripId)
        {
            Trip tripToDelete =await this.dbContext
                .Trips
                .Where(t => t.IsActive)
                .FirstAsync(t => t.Id.ToString() == tripId);

            //soft delete

            tripToDelete.IsActive = false;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task EditTripByIdAndFormModelAsync(string tripId, TripFormModel formModel)
        {
            Trip trip = await this.dbContext
                 .Trips
                 .Where(t => t.IsActive)
                 .FirstAsync(t => t.Id.ToString() == tripId);

            trip.Title = formModel.Title;
            trip.StartDate = formModel.StartDate;
            trip.ReturnDate = formModel.ReturnDate;
            trip.Description = formModel.Description;
            trip.PricePerPerson = formModel.PricePerPerson;
            trip.GroupMaxSize = formModel.GroupMaxSize;
            trip.MountainId = formModel.MountainId;

            await this.dbContext.SaveChangesAsync();

        }

        public async Task<bool> ExistsByIdAsync(string tripId)
        {
            bool result =await dbContext
                .Trips
                .Where(t => t.IsActive)
                .AnyAsync(t => t.Id.ToString() == tripId);

            return result;
        }

        public async Task<TripDetailsViewModel> GetDetailsByIdAsync(string tripId)
        {
            Trip trip = await this.dbContext
                .Trips
                .Include(t=>t.Mountain)
                .Include(t=>t.Guide)
                .ThenInclude(g=>g.User)
                .Where(t => t.IsActive)
                .FirstAsync(t => t.Id.ToString() == tripId);


            return new TripDetailsViewModel
            {
                Id = trip.Id.ToString(),
                Title = trip.Title,
                StartDate = trip.StartDate,
                PricePerPerson = trip.PricePerPerson,
                NotFull = trip.Hikers.Count < trip.GroupMaxSize,
                Mountain = trip.Mountain.Name,
                Description = trip.Description,
                ReturnDate = trip.ReturnDate,
                Guide = new GuideInfoOnTripViewModel()
                {
                    Email = trip.Guide.User.Email,
                    PhoneNumber = trip.Guide.PhoneNumber
                }
            };
        }

        public async Task<StatisticsServiceModel> GetStatisticsAsync()
        {
            return new StatisticsServiceModel()
            {
                TotalTrips =
                    await this.dbContext.Trips.CountAsync(),
                TotalTripsAvailableToJoin =
                    await this.dbContext.Trips.Where(t => t.Hikers.Count < t.GroupMaxSize).CountAsync()
            };
        }

        public async Task<TripPreDeleteDetailsViewModel> GetTripForDeleteByIdAsync(string tripId)
        {
            Trip trip = await dbContext
                .Trips
                .Where(t => t.IsActive)
                .FirstAsync(t => t.Id.ToString() == tripId);

            return new TripPreDeleteDetailsViewModel
            {
                Title = trip.Title,
                StartDate = trip.StartDate,
                ReturnDate = trip.ReturnDate
            };
        }

        public async Task<TripFormModel> GetTripForEditByIdAsync(string tripId)
        {
            Trip trip = await this.dbContext
               .Trips
               .Include(t => t.Mountain)
               .Where(t => t.IsActive)
               .FirstAsync(t => t.Id.ToString() == tripId);

            return new TripFormModel
            {
                Title = trip.Title,
                StartDate = trip.StartDate,
                ReturnDate = trip.ReturnDate,
                Description = trip.Description,
                PricePerPerson = trip.PricePerPerson,
                GroupMaxSize = trip.GroupMaxSize,
                MountainId = trip.MountainId
            };
        }

        public async Task<bool> IsFullByIdAsync(string tripId)
        {
            Trip trip =await this.dbContext
                .Trips
                .FirstAsync(t => t.Id.ToString() == tripId);

            return trip.Hikers.Count >= trip.GroupMaxSize;
        }

        public async Task<bool> IsGuideWithIdCreatorOfTripWithIdAsync(string tripId, string guideId)
        {
            Trip trip = await this.dbContext
                .Trips
                .Where(t => t.IsActive)
                .FirstAsync(t => t.Id.ToString() == tripId);

            return trip.GuideId.ToString() == guideId;
        }

        public async Task<bool> IsUserWithIdPartOfTripByIdAsync(string tripId, string userId)
        {
            Trip trip = await this.dbContext
                .Trips
                .Include(t=>t.Hikers)
                .FirstAsync(t => t.Id.ToString() == tripId);

            return trip.Hikers.Count>0 &&
                trip.Hikers.Any(h => h.Id.ToString() == userId);
        }

        public async Task JoinTripAsync(string tripId, string userId)
        {
            //Services rely on the fact that controllers check if trip, user, guide etc with given ids exist!

            ApplicationUser userToJoin = await this.dbContext
                .Users
                .FirstAsync(u => u.Id.ToString() == userId);

            Trip trip = await this.dbContext
                .Trips
                .FirstAsync(t => t.Id.ToString() == tripId);

            //add the current user to the lists of hikers for the current trip
                

            trip.Hikers.Add(userToJoin);

            //should i add to the User ApplicationUserTripTable???

            await this.dbContext.SaveChangesAsync();           

        }

        public async Task<IEnumerable<IndexViewModel>> LastFiveTripsAsync()
        {
            //display the 5 latest PLANNED trips
            IEnumerable<IndexViewModel> lastfiveTrips = await this.dbContext
                .Trips
                .Where(t=>t.IsActive)
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

        public async Task LeaveTripAsync(string tripId,string userId)
        {

            ApplicationUser userToLeave = await this.dbContext
                .Users
                .FirstAsync(u => u.Id.ToString() == userId);

            Trip trip = await this.dbContext
                .Trips
                .FirstAsync(t => t.Id.ToString() == tripId);

            trip.Hikers.Remove(userToLeave);

            userToLeave.EnrolledTrips.Remove(trip);

            //should i remove from ApplicationUserTripTable???

            

            await this.dbContext.SaveChangesAsync();

        }
    }
}
