namespace TrailVenturesSystem.Services.Data.Interfaces
{
    using TrailVenturesSystem.Services.Data.Models.Trip;
    using TrailVenturesSystem.Web.ViewModels.Home;
    using TrailVenturesSystem.Web.ViewModels.Trip;

    public interface ITripService
    {
        Task<IEnumerable<IndexViewModel>> LastFiveTripsAsync();

        Task<string> CreateAndReturnIdAsync(TripFormModel formModel,string guideId);

        Task<AllTripsFilteredAndPagedServiceModel> AllAsync(AllTripsQueryModel queryModel);

        Task<IEnumerable<TripAllViewModel>> AllByGuideIdAsync(string guideId);

        Task<IEnumerable<TripAllViewModel>> AllByUserIdAsync(string userId);

        Task<bool> ExistsByIdAsync(string tripId);

        Task<TripFormModel> GetTripForEditByIdAsync(string tripId);

        Task<TripDetailsViewModel> GetDetailsByIdAsync(string tripId);

        Task<bool> IsGuideWithIdCreatorOfTripWithIdAsync(string tripId, string guideId);

        Task EditTripByIdAndFormModelAsync(string tripId, TripFormModel formModel);

        Task<TripPreDeleteDetailsViewModel> GetTripForDeleteByIdAsync(string tripId);

        Task DeleteTripByIdAsync(string tripId);

        Task<bool> IsFullByIdAsync(string tripId);

        Task JoinTripAsync(string tripId, string userId);

        Task<bool> IsUserWithIdPartOfTripByIdAsync(string tripId, string userId);

        Task LeaveTripAsync(string tripId, string userId);
    }
}
