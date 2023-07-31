namespace TrailVenturesSystem.Web.ViewModels.Guide
{
    using System.ComponentModel.DataAnnotations;

    public class GuideInfoOnTripViewModel
    {

        public string FullName { get; set; } = null!;

        public string Email { get; set; }

        [Display(Name ="Phone number")]
        public string PhoneNumber { get; set; }
    }
}
