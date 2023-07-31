namespace TrailVenturesSystem.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.User;

    /// <summary>
    /// Custom user class that works with the default ASP.NET Core Identity.
    /// Additional info could be added to the build-in useers.
    /// </summary>
    public class ApplicationUser :IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
            this.EnrolledTrips = new HashSet<Trip>();
        }

        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; } = null!;
        //Navigation property
        public virtual ICollection<Trip> EnrolledTrips { get; set; }
        
        
    }
}
