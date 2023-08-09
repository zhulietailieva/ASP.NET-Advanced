namespace TrailVenturesSystem.Services.Data.Interfaces
{
    using TrailVenturesSystem.Web.ViewModels.User;

    public interface IUserService
    {
        Task<string> GetFullNameByEmailAsync(string email);

        Task<ProfileViewModel> GetUserDataForProfileAsync(string userId);

        Task AddPersonalInfoAsync(string userId, string personalInfo);
    }
}
