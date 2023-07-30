namespace TrailVenturesSystem.Web.ViewModels.Trip
{
    using System.ComponentModel.DataAnnotations;

    public class TripPreDeleteDetailsViewModel
    {
        public string Title { get; set; } = null!;

        [Display(Name ="Start date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Return date")]
        public DateTime ReturnDate { get; set; }

    }
}
