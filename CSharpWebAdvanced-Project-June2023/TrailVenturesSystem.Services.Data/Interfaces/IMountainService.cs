namespace TrailVenturesSystem.Services.Data.Interfaces
{
    using TrailVenturesSystem.Web.ViewModels.Mountain;
    //creating a whole service in order for admin to add more Bulgarian (or foreign) mountains in the future
    public interface IMountainService
    {
        Task<IEnumerable<TripSelectMountainFormModel>> AllMountainsAsync();

        Task<IEnumerable<AllMountainsViewModel>> AllMountainsForListAsync();
        
        Task<bool> ExistsByIdAsync(int id);

        Task<IEnumerable<string>> AllMountainNamesAsync();

        Task<MountainDetailsViewModel> GetDetailsByIdAsync(int id);

        Task<string> getNameByIdAsync(int mountainId);
    }
}
