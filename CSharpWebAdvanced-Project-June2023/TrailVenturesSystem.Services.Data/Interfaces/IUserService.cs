namespace TrailVenturesSystem.Services.Data.Interfaces
{
    using TrailVenturesSystem.Web.ViewModels.User;

    public interface IUserService
    {
        Task<string> GetFullNameByEmailAsync(string email);

        Task<string> GetFullNameByIdAsync(string userId);

        Task<IEnumerable<UserViewModel>> AllASync();

        Task<ProfileViewModel> GetUserDataForProfileAsync(string userId);

        Task AddPersonalInfoAsync(string userId, string personalInfo);

        

    }
}
