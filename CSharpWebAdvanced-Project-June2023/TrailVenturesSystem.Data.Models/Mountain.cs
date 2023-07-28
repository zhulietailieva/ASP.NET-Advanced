namespace TrailVenturesSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Mountain;
    public class Mountain
    {
        public Mountain()
        {
            Trips = new HashSet<Trip>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Trip> Trips { get; set; }
    }
}
