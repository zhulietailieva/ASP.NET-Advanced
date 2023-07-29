namespace TrailVenturesSystem.Services.Data.Models.Trip
{
    using TrailVenturesSystem.Web.ViewModels.Trip;

    public class AllTripsFilteredAndPagedServiceModel
    {
        public AllTripsFilteredAndPagedServiceModel()
        {
            this.Trips = new HashSet<TripAllViewModel>();
        }
        public int TotalTripsCount { get; set; }

        public IEnumerable<TripAllViewModel> Trips { get; set; }
    }
}
