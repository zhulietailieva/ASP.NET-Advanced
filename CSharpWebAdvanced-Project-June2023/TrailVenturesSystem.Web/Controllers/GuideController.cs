namespace TrailVenturesSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TrailVenturesSystem.Services.Data.Interfaces;
    using TrailVenturesSystem.Web.Infrastructure.Extensions;
    using TrailVenturesSystem.Web.ViewModels.Guide;
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
                this.TempData[ErrorMessage] = "You are already a guide!";

                return this.RedirectToAction("Index", "Home");
            }

            return this.View();
        }
        [HttpPost]
        public async Task<IActionResult> Become(BecomeGuideFormModel model)
        {
            string? userId = this.User.GetId();
            bool isGuide = await this.guideService.GuideExistsByUserIdAsync(userId);

            if (isGuide)
            {
                this.TempData[ErrorMessage] = "You are already a guide!";

                return this.RedirectToAction("Index", "Home");
            }

            bool isPhoneNumberTaken = await this.guideService.GuideExistsByPhoneNumberAsync(model.PhoneNumber);
            if (isPhoneNumberTaken)
            {
                //where to add the error, key and error message
                this.ModelState.AddModelError(nameof(model.PhoneNumber), "Guide with provided phone number already exists!");
            }

            if (!this.ModelState.IsValid)
            {
                //return the same view with displayed errors
                return this.View(model);
            }

            bool userHasActiveTrips =await this.guideService
                .HasTripsByUserIdAsync(userId);

            if (userHasActiveTrips)
            {
                this.TempData[ErrorMessage] = "You must not have any active trips in order to become a guide!";

                return this.RedirectToAction("Mine", "Trip");
            }
            try
            {
                await this.guideService.Create(userId, model);
            }
            catch(Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error occured while registering you as a guide! Please try agent later or contact an administrator.";

                return this.RedirectToPage("Index", "Home");

            }
            return this.RedirectToPage("All", "Trip");
            
        }

    }
}
