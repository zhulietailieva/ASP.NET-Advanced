namespace TrailVenturesSystem.Services.Data.Interfaces
{
    using TrailVenturesSystem.Data.Models;
    using TrailVenturesSystem.Web.ViewModels.Hut;
    using TrailVenturesSystem.Web.ViewModels.Mountain;

    public interface IHutService
    {
        Task<int> CreateAndReturnIdAsync(HutFormModel formModel);

        Task<IEnumerable<TripSelectHutFormModel>> AllHutsAync();

        Task<IEnumerable<TripSelectHutFormModel>> AllHutsByMountainIdAsync(string mountainId);

        Task<IEnumerable<string>> AllHutsNamesAsync();

        Task<Hut> GetHutByIdAsync(int hutId);

        Task<bool> ExistsByIdAsync(int hutId);


    }
}
