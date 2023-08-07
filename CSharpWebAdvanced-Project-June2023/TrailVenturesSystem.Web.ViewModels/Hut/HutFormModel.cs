namespace TrailVenturesSystem.Web.ViewModels.Hut
{
    using System.ComponentModel.DataAnnotations;
    using TrailVenturesSystem.Web.ViewModels.Mountain;
    using static Common.EntityValidationConstants.Hut;

    public class HutFormModel
    {
        public HutFormModel()
        {
            this.Mountains = new HashSet<TripSelectMountainFormModel>();
        }

        [Required]
        [StringLength(NameMaxLength,MinimumLength =NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [Phone]
        [StringLength(PhoneNumberMaxLength,MinimumLength =PhoneNumberMinLength)]
        [Display(Name = "Host phone number")]
        public string HostPhoneNumber { get; set; } = null!;

        [Required]
        [Display(Name="Price per night")]
        [Range(typeof(decimal),pricePerPersonMinValue,pricePerPersonMaxValue)]
        public decimal PricePerNight { get; set; }

        [Range(altitudeMinValue,altitudeMaxValue)]
        public int Altitude { get; set; }

        [Display(Name = "Mountain")]
        public int MountainId { get; set; }

        public IEnumerable<TripSelectMountainFormModel> Mountains { get; set; }

        public string? ReturnUrl { get; set; }
    }
}
