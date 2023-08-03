namespace TrailVenturesSystem.Services.Data.Interfaces
{
    using TrailVenturesSystem.Web.ViewModels.Hut;
    using TrailVenturesSystem.Web.ViewModels.Mountain;

    public interface IHutService
    {
        Task<IEnumerable<TripSelectHutFormModel>> AllHutsAync();

        Task<IEnumerable<TripSelectHutFormModel>> AllHutsByMountainIdAsync(string mountainId);

        Task<IEnumerable<string>> AllHutsNamesAsync();
    }
}
