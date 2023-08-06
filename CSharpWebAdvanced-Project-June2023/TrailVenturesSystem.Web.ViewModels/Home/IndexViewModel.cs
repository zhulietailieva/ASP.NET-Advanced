namespace TrailVenturesSystem.Web.ViewModels.Home
{
/// <summary>
/// what is visualized on the landing page for each trip
/// </summary>
    public class IndexViewModel
    {
        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;

        public int MountainId { get; set; } 

        public string GuideId { get; set; } = null!;

        public DateTime StartDate { get; set; } 

        public DateTime? ReturnDate { get; set; }
    }
}
