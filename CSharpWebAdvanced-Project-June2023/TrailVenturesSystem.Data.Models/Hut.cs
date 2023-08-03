namespace TrailVenturesSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Hut;
    public class Hut
    {
        public Hut()
        {
            Trips = new HashSet<Trip>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public bool IsActive { get; set; }

        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        public string HostPhoneNumber { get; set; } = null!;

        [Required]
        public decimal PricePerNight { get; set; }

        public int Altitude { get; set; }

        public int MountainId { get; set; }

        public virtual Mountain Mountain { get; set; } = null!;

        public ICollection<Trip> Trips { get; set; }
    }
}
