namespace TrailVenturesSystem.Web.ViewModels.Hut
{
    public class HutInfoOnTripViewModel
    {
        public int Id { get; set; } = -1;
        public string Name { get; set; } = null!;

        public string HostPhoneNumber { get; set; } = null!;

        public int Altitude { get; set; }

        public decimal PricePerNight { get; set; }

    }
}
