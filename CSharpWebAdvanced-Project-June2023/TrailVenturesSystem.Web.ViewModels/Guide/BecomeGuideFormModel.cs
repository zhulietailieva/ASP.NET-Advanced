namespace TrailVenturesSystem.Web.ViewModels.Guide
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Guide;

    public class BecomeGuideFormModel
    {
        [Required]
        [StringLength(PhoneNumberMaxLength,MinimumLength =PhoneNumberMinLength)]
        [Phone]
        [Display(Name ="Phone number")]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [Range(YearsOfExperienceMinValue,YearsOfExperienceMaxValue)]
        [Display(Name="Years of experience")]
        public int YearsOfExperience { get; set; }
    }
}
