namespace TrailVenturesSystem.Web.ViewModels.User
{
    using System.ComponentModel.DataAnnotations;

    public class ProfileDetailsFormModel
    {
        [Required]
        [Display(Name ="New Profile bio")]
        public string Info { get; set; } = null!;
    }
}
