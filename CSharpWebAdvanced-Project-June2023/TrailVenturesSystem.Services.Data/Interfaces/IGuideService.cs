namespace TrailVenturesSystem.Services.Data.Interfaces
{
    using TrailVenturesSystem.Web.ViewModels.Guide;

    public interface IGuideService
    {
        Task<bool> GuideExistsByUserIdAsync(string userId);

        Task<bool> GuideExistsByPhoneNumberAsync(string phoneNumber);

        Task<bool> HasTripsByUserIdAsync(string userId);

        Task Create(string userId, BecomeGuideFormModel model);

        Task<string?> GetGuideIdByUserIdAsync(string userId);

        Task<bool> HasTripWithIdAsync(string? userId,string tripId);
    }
}
