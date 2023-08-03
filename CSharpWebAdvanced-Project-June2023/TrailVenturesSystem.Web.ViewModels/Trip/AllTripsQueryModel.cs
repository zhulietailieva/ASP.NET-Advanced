namespace TrailVenturesSystem.Web.ViewModels.Trip
{
    using System.ComponentModel.DataAnnotations;
    using TrailVenturesSystem.Web.ViewModels.Trip.Enums;

    using static Common.GeneralApplicationConstants;

    public class AllTripsQueryModel
    {
        public AllTripsQueryModel()
        {
            this.CurrentPage = DefaultPage;
            this.TripsPerPage = EntitiesPerPage;
            this.Mountains = new HashSet<string>();
            this.Huts = new HashSet<string>();
            this.Trips = new HashSet<TripAllViewModel>();
            
        }
        public string? Mountain { get; set; }

        public string? Hut { get; set; }

        [Display(Name ="Search by word")]
        public string? SearchString { get; set; }

        [Display(Name ="Sort trips by")]
        public TripSorting TripSorting { get; set; }

        public int CurrentPage { get; set; }

        [Display(Name ="Trips on page")]
        public int TripsPerPage { get; set; }
        
        public int TotalTrips { get; set; }
        public IEnumerable<string> Mountains { get; set; } = null!;

        public IEnumerable<string> Huts { get; set; }

        public IEnumerable<TripAllViewModel> Trips { get; set; }

    }
}
