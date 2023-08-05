namespace TrailVenturesSystem.Web.ViewModels.Trip
{
    using System.ComponentModel.DataAnnotations;
    using TrailVenturesSystem.Web.ViewModels.Guide;
    using TrailVenturesSystem.Web.ViewModels.Hut;

    public class TripDetailsViewModel : TripAllViewModel
    {
        public string Mountain { get; set; } = null!;

        public string Description { get; set; } = null!;

        
        //public DateTime ReturnDate  { get; set; }

        public GuideInfoOnTripViewModel Guide { get; set; } = null!;

        public HutInfoOnTripViewModel? Hut { get; set; }

    }
}
