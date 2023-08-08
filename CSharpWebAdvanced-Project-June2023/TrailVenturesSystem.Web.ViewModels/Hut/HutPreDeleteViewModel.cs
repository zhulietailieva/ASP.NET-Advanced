namespace TrailVenturesSystem.Web.ViewModels.Hut
{
    public class HutPreDeleteViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public int Altitude { get; set; }

        public string? ReturnUrl { get; set; }
    }
}
