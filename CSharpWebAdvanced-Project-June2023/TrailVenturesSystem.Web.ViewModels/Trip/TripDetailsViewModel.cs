namespace TrailVenturesSystem.Web.ViewModels.Trip
{
    using System.ComponentModel.DataAnnotations;
    using TrailVenturesSystem.Web.ViewModels.Guide;

    public class TripDetailsViewModel : TripAllViewModel
    {
        public string Mountain { get; set; } = null!;

        public string Description { get; set; } = null!;

        [Display(Name ="Return date")]
        public DateTime ReturnDate  { get; set; }

        public GuideInfoOnTripViewModel Guide { get; set; } = null!;

    }
}
