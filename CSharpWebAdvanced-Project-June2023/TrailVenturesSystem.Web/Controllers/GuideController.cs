namespace TrailVenturesSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TrailVenturesSystem.Services.Data.Interfaces;
    using TrailVenturesSystem.Web.Infrastructure.Extensions;

    using static Common.NotificationMessagesConstants;

    [Authorize]
    public class GuideController : Controller
    {
        private readonly IGuideService guideService;

        public GuideController(IGuideService guideService)
        {
            this.guideService = guideService;
        }

        [HttpGet]
        public async Task<IActionResult> Become()
        {

            string? userId = this.User.GetId();
            bool isGuide =await this.guideService.GuideExistsByUserIdAsync(userId);

            if (isGuide)
            {
                TempData[ErrorMessage] = "You are already a guide!";

                return this.RedirectToAction("Index", "Home");
            }

            return this.View();
        }
    }
}
