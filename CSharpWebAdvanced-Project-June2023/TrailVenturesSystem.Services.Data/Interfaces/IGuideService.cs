namespace TrailVenturesSystem.Services.Data.Interfaces
{
    public interface IGuideService
    {
        Task<bool> GuideExistsByUserIdAsync(string uiserId);
    }
}
