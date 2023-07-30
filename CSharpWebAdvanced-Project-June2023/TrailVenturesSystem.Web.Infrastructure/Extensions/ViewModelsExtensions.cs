namespace TrailVenturesSystem.Web.Infrastructure.Extensions
{
    using TrailVenturesSystem.Web.ViewModels.Mountain.Interfaces;

    public static class ViewModelsExtensions
    {
        public static string GetUrlInformation(this IMountainDetailsModel model)
        {
            return model.Name.Replace(" ", "-");
        }
    }
}
