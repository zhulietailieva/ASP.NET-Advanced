﻿namespace TrailVenturesSystem.Services.Data.Interfaces
{
    using TrailVenturesSystem.Web.ViewModels.Mountain;
    //creating a whole service in order for admin to add more Bulgarian (or foreign) mountains in the future
    public interface IMountainService
    {
        Task<int> CreateAndReturnIdAsync(MountainFormModel formModel);

        Task<IEnumerable<TripSelectMountainFormModel>> AllMountainsAsync();

        Task<IEnumerable<AllMountainsViewModel>> AllMountainsForListAsync();
        
        Task<bool> ExistsByIdAsync(int id);

        Task<IEnumerable<string>> AllMountainNamesAsync();

        Task<string> GetNameByIdAsync(int id);

        Task<MountainDetailsViewModel> GetDetailsByIdAsync(int id);

    }
}
