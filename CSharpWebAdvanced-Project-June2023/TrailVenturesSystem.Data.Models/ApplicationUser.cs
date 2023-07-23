namespace TrailVenturesSystem.Data.Models
{
    using Microsoft.AspNetCore.Identity;

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
        //Navigation property
        public virtual ICollection<Trip> EnrolledTrips { get; set; }
        
        //TODO: Add more properties for a user
    }
}
