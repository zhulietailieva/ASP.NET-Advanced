namespace TrailVenturesSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TrailVenturesSystem.Services.Data.Interfaces;
    using TrailVenturesSystem.Web.Infrastructure.Extensions;
    using TrailVenturesSystem.Web.ViewModels.Trip;

    using static Common.NotificationMessagesConstants;

    [Authorize]
    public class TripController : Controller
    {
        private readonly IMountainService mountainService;
        private readonly IGuideService guideService;
        public TripController(IMountainService mountainService, IGuideService guideService)
        {
            this.mountainService = mountainService;
            this.guideService = guideService;
        }
        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            //validation if user is guide -> only guides can add trips

            bool isGuide = await this.guideService.GuideExistsByUserIdAsync(this.User.GetId()!);

            if (!isGuide)
            {
                this.TempData[ErrorMessage] = "You must become a guide in order to create a trip!";

                return this.RedirectToAction("Become", "Guide");
            }

            TripFormModel formModel = new TripFormModel()
            {
                Mountains =await this.mountainService.AllMountainsAsync()
            };

            return View(formModel);
        } 
    }
}
