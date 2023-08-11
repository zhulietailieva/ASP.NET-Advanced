namespace TrailVenturesSystem.Web.ViewModels.Trip
{
    using System.ComponentModel.DataAnnotations;

    public class TripAllViewModel
    {
        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;

        [Display(Name ="Start date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Return date")]
        public DateTime ReturnDate { get; set; }

        [Display(Name = "Price per person")]
        public decimal PricePerPerson { get; set; }

        [Display(Name = "Available places")]
        public bool NotFull { get; set; }

        [Display(Name ="Current group size")]
        public int CurrentGroupSize { get; set; }

        [Display(Name = "Max group size")]
        public int MaxGroupSize { get; set; }

    }
}
