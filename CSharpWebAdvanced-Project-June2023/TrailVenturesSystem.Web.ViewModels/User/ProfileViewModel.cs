namespace TrailVenturesSystem.Web.ViewModels.User
{
    using System.ComponentModel.DataAnnotations;

    public class ProfileViewModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        public string? GuideId { get; set; }

        public string? PhoneNumber { get; set; }

        public int? YearsOfExperience { get; set; }
    }
}
