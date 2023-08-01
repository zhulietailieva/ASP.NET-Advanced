namespace TrailVenturesSystem.Web.ViewModels.Trip
{
    using AutoMapper;
    using System.ComponentModel.DataAnnotations;
    using TrailVenturesSystem.Data.Models;
    using TrailVenturesSystem.Services.Mapping;
    using TrailVenturesSystem.Web.ViewModels.Mountain;

    using static Common.EntityValidationConstants.Trip;

    public class TripFormModel :IMapTo<Trip>,IHaveCustomMappings
    {
        public TripFormModel()
        {
            this.Mountains = new HashSet<TripSelectMountainFormModel>();
        }

        [Required]
        [StringLength(TitleMaxLength,MinimumLength =TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [Display(Name ="Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "Return Date")]
        public DateTime ReturnDate { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength,MinimumLength =DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        [Display(Name = "Price Per Person")]
        [Range(typeof(decimal),PricePerPersonMinValue,PricePerPersonMaxValue)]
        public decimal PricePerPerson { get; set; }

        [Required]
        [Display(Name ="Max size of the group")]
        [Range(GroupMinSizePeople,GroupsMaxSizePeople)]
        public int GroupMaxSize { get; set; }

        //selected mountain by user
        [Display(Name ="Mountain")]
        public int MountainId { get; set; }
        public IEnumerable<TripSelectMountainFormModel> Mountains { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            //custom configuration for mapper to ignore GuideId
            configuration.CreateMap<TripFormModel, Trip>()
                .ForMember(d => d.GuideId, opt => opt.Ignore());
        }
    }
}
