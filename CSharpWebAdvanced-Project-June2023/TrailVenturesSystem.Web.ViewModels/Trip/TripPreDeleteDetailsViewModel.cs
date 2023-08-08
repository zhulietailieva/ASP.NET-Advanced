namespace TrailVenturesSystem.Web.ViewModels.Trip
{
    using System.ComponentModel.DataAnnotations;

    public class TripPreDeleteDetailsViewModel
    {
        public string Title { get; set; } = null!;

        [DataType(DataType.Date)]
        [Display(Name ="Start date")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Return date")]
        public DateTime ReturnDate { get; set; }

    }
}
