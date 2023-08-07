namespace TrailVenturesSystem.Web.Controllers
{
    using static Common.NotificationMessagesConstants;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using TrailVenturesSystem.Services.Data.Interfaces;
    using TrailVenturesSystem.Web.Infrastructure.Extensions;
    using TrailVenturesSystem.Web.ViewModels.Hut;

    [Authorize]
    public class HutController : Controller
    {
        private readonly IGuideService guideService;
        private readonly IMountainService mountainService;
        private readonly IHutService hutService;

        public HutController(IGuideService guideService, IMountainService mountainService,
            IHutService hutService)
        {
            this.guideService = guideService;
            this.mountainService = mountainService;
            this.hutService = hutService;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {

            bool isGuide = await this.guideService.GuideExistsByUserIdAsync(this.User.GetId()!);

            if(!isGuide && !this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must become a guide in order to register a hut!";
                return this.RedirectToAction("Become", "Guide");
            }

            try
            {
                HutFormModel formModel = new HutFormModel()
                {
                    Mountains = await this.mountainService.AllMountainsAsync(),
                    //testing
                    ReturnUrl= HttpContext.Request.Headers["Referer"].ToString()
                };              

                return View(formModel);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
        }
        [HttpPost]

        //getting the url for later redirect
        public async Task<IActionResult> Add(HutFormModel model, string returnUrl)
        {
            bool isGuide = await this.guideService.GuideExistsByUserIdAsync(this.User.GetId()!);

            if (!isGuide && !this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must become a guide in order to register a hut!";
                return this.RedirectToAction("Become", "Guide");
            }
            bool mountainExists = await this.mountainService.ExistsByIdAsync(model.MountainId);

            if (!mountainExists)
            {
                //Adding model error to ModelState automatically makes ModelState invalid
                this.ModelState.AddModelError(nameof(model.MountainId), "You selected a mountain that does not exist!");
            }

            if (!this.ModelState.IsValid)
            {
                model.Mountains = await this.mountainService.AllMountainsAsync();
                return this.View(model);
            }
            try
            {
                int hutId = await this.hutService.CreateAndReturnIdAsync(model);

                this.TempData[SuccessMessage] = "Hut was registered successfully!";
               
                //redirecting url to the previous page
                if (!string.IsNullOrEmpty(returnUrl))
                {
                    return Redirect(returnUrl);
                }

                // If the referer URL is not available or invalid, redirect to a default action
                return RedirectToAction("All", "Mountain");

            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "Unexpected error occured while trying to register this hut! Please try again later or contact administrator.");

                model.Mountains = await this.mountainService.AllMountainsAsync();
                return this.View(model);
            }
        }
        private IActionResult GeneralError()
        {
            this.TempData[ErrorMessage] = "Unexpected error occured! Please try again later or contact administator.";

            return this.RedirectToAction("Index", "Home");
        }
    }
}
