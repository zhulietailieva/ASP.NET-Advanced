namespace TrailVenturesSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Trip;
    public class Trip
    {
        public Trip()
        {
            this.Id = Guid.NewGuid();
            Hikers = new HashSet<ApplicationUser>();
        }
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        /*[Required]
        [MaxLength(MountainMaxLength)]
        public string Mountain { get; set; } = null!;
        */

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime ReturnDate { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        public decimal PricePerPerson { get; set; }

        [Required]
        public int GroupMaxSize { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsActive { get; set; }

        public int MountainId { get; set; }

        public virtual Mountain Mountain { get; set; } = null!;

        public Guid GuideId { get; set; }

        public virtual Guide Guide { get; set; } = null!;

        public virtual ICollection<ApplicationUser> Hikers { get; set; }

    }
}