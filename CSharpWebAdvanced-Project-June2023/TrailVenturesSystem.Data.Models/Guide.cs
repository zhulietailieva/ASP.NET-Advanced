namespace TrailVenturesSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Guide;
    public class Guide
    {
        public Guide()
        {
            this.Id = Guid.NewGuid();
            this.CreatedTrips = new HashSet<Trip>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        public int YearsOfExperience { get; set; }

        public Guid UserId { get; set; }
        public virtual ApplicationUser User { get; set; } = null!;

        public virtual ICollection<Trip> CreatedTrips { get; set; }
    }
}
