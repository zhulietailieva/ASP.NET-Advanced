namespace TrailVenturesSystem.Services.Data.Interfaces
{
    using TrailVenturesSystem.Web.ViewModels.Home;

    public interface ITripService
    {
        Task<IEnumerable<IndexViewModel>> LastFiveTripsAsync();
    }
}
