namespace TrailVenturesSystem.Web.Areas.Admin.ViewModels.Trip
{
    using TrailVenturesSystem.Web.ViewModels.Trip;

    public class MyTripsViewModel
    {
        public IEnumerable<TripAllViewModel> AddedTrips { get; set; } = null!;

        public IEnumerable<TripAllViewModel> JoinedTrips { get; set; } = null!;

    }
}
