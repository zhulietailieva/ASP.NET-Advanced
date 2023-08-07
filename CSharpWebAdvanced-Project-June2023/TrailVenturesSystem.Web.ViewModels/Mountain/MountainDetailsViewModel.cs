namespace TrailVenturesSystem.Web.ViewModels.Mountain
{
    using TrailVenturesSystem.Web.ViewModels.Hut;
    using TrailVenturesSystem.Web.ViewModels.Mountain.Interfaces;

    public class MountainDetailsViewModel : IMountainDetailsModel
    {
        public MountainDetailsViewModel()
        {
            Huts = new HashSet<HutInfoOnTripViewModel>();
        }
        public int Id { get; set; } 
        public string Name { get; set; } = null!;
        public ICollection<HutInfoOnTripViewModel> Huts { get; set; }
    }
}
