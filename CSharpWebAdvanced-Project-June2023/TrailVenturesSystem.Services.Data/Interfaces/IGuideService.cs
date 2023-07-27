namespace TrailVenturesSystem.Services.Data.Interfaces
{
    using TrailVenturesSystem.Web.ViewModels.Guide;

    public interface IGuideService
    {
        Task<bool> GuideExistsByUserIdAsync(string userId);

        Task<bool> GuideExistsByPhoneNumberAsync(string phoneNumber);

        Task<bool> HasTripsByUserIdAsync(string userId);

        Task Create(string userId, BecomeGuideFormModel model);
    }
}
