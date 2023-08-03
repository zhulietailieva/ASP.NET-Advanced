namespace TrailVenturesSystem.Web.ViewModels.Trip
{
    using AutoMapper;
    using System.ComponentModel.DataAnnotations;
    using TrailVenturesSystem.Common;
    using TrailVenturesSystem.Data.Models;
    using TrailVenturesSystem.Services.Mapping;
    using TrailVenturesSystem.Web.ViewModels.Hut;
    using TrailVenturesSystem.Web.ViewModels.Mountain;

    using static Common.EntityValidationConstants.Trip;
   

    public class TripFormModel :IMapTo<Trip>,IHaveCustomMappings
    {
        public TripFormModel()
        {
            this.Mountains = new HashSet<TripSelectMountainFormModel>();
            this.Huts = new HashSet<TripSelectHutFormModel>();
        }

        [Required]
        [StringLength(TitleMaxLength,MinimumLength =TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [DataType(DataType.Date)]
        [ValidateBeforeToday(ErrorMessage ="Start date must be after today!")]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; } = DateTime.UtcNow.Date;

        [Required]
        [DataType(DataType.Date)]
        [ValidateBeforeToday(ErrorMessage = "Return date must be after today!")]
        [Display(Name = "Return Date")]
        public DateTime ReturnDate { get; set; } = DateTime.UtcNow.Date;

        //public DateOnly TestDate { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength,MinimumLength =DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        [Display(Name = "Price per person")]
        [Range(typeof(decimal),PricePerPersonMinValue,PricePerPersonMaxValue)]
        public decimal PricePerPerson { get; set; }

        [Required]
        [Display(Name ="Max size of the group")]
        [Range(GroupMinSizePeople,GroupsMaxSizePeople)]
        public int GroupMaxSize { get; set; }
        
        //selected mountain by user
        [Display(Name = "Mountain")]
        public int MountainId { get; set; }

        public IEnumerable<TripSelectMountainFormModel> Mountains { get; set; }

        //hut info
        [Display(Name = "Hut")]
        public int HutId { get; set; }
        public IEnumerable<TripSelectHutFormModel> Huts { get; set; }

        //multiple days

        [Display(Name = "Is your trip more than one day long?")]
        public bool IsMoreThanOneDay { get; set; } = false;

  
        public void CreateMappings(IProfileExpression configuration)
        {
            //custom configuration for mapper to ignore GuideId
            configuration.CreateMap<TripFormModel, Trip>()
                .ForMember(d => d.GuideId, opt => opt.Ignore());
        }
    }
}
