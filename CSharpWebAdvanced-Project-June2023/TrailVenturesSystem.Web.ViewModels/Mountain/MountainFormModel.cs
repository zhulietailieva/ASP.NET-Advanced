namespace TrailVenturesSystem.Web.ViewModels.Mountain
{
    using System.ComponentModel.DataAnnotations;

    public class MountainFormModel
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}
