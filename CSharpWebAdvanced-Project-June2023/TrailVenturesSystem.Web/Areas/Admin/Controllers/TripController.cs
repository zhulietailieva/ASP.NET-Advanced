namespace TrailVenturesSystem.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using TrailVenturesSystem.Services.Data.Interfaces;
    using TrailVenturesSystem.Web.Areas.Admin.ViewModels.Trip;
    using TrailVenturesSystem.Web.Infrastructure.Extensions;

    public class TripController : BaseAdminController
    {

        private IGuideService guideService;
        private ITripService tripService;

        public TripController(IGuideService guideService, ITripService tripService)
        {
            this.guideService = guideService;
            this.tripService = tripService;
        }
        public async Task<IActionResult> Mine()
        {
            string? guideId =
                await this.guideService.GetGuideIdByUserIdAsync(this.User.GetId()!);

            MyTripsViewModel viewModel = new MyTripsViewModel()
            {
                AddedTrips = await this.tripService.AllByGuideIdAsync(guideId!),
                JoinedTrips = await this.tripService.AllByUserIdAsync(this.User.GetId()!)
            };

            return this.View(viewModel);
        }
    }
}
