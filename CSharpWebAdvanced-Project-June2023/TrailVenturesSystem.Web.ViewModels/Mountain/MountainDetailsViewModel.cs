namespace TrailVenturesSystem.Web.ViewModels.Mountain
{
    using TrailVenturesSystem.Web.ViewModels.Mountain.Interfaces;

    public class MountainDetailsViewModel : IMountainDetailsModel
    {
        public int Id { get; set; } 
        public string Name { get; set; } = null!;
    }
}
