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
               
                if (!string.IsNullOrEmpty(returnUrl))
                {
                    return Redirect(returnUrl);
                }

                return RedirectToAction("All", "Mountain");

            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "Unexpected error occured while trying to register this hut! Please try again later or contact administrator.");

                model.Mountains = await this.mountainService.AllMountainsAsync();
                return this.View(model);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            bool hutExists = await this.hutService.ExistsByIdAsync(id);

            if (!hutExists)
            {
                this.TempData[ErrorMessage] = "Hut with the provided id does not exist! ";

                return this.RedirectToAction("All", "Mountain");
            }


            bool isUserGuide = await this.guideService
                .GuideExistsByUserIdAsync(this.User.GetId()!);

            if (!isUserGuide && !this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must become a guide in order to edit hut info!";

                return this.RedirectToAction("Become", "Guide");
            }


            try
            {
                HutFormModel formModel = await this.hutService
                    .GetHutForEditByIdAsync(id);

                formModel.ReturnUrl = HttpContext.Request.Headers["Referer"].ToString();

                return this.View(formModel);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error occured! Please try again later or contact administator.";

                return this.RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, HutFormModel model, string returnUrl)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            bool hutExists = await this.hutService
                .ExistsByIdAsync(id);

            if (!hutExists)
            {
                this.TempData[ErrorMessage] = "Hut with the provided id does not exist! ";

                return this.RedirectToAction("All", "Mountain");
            }

            bool isUserGuide = await this.guideService
                .GuideExistsByUserIdAsync(this.User.GetId()!);

            if (!isUserGuide && !this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must become a guide in order to edit hut info!";

                return this.RedirectToAction("Become", "Guide");
            }

            try
            {
                await this.hutService.EditHutByIdAndFormModelAsync(id, model);

                this.TempData[SuccessMessage] = "Hut was edited successfully!";

                if (!string.IsNullOrEmpty(returnUrl))
                {
                    return Redirect(returnUrl);
                }

                return RedirectToAction("All", "Mountain");
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "Unexpected error occured while trying to update the hut! Please try again later or contact administrator.");
                this.TempData[ErrorMessage] = "Error";

                return this.View(model);
            }
            
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            bool hutExists = await this.hutService.ExistsByIdAsync(id);

            if (!hutExists)
            {
                this.TempData[ErrorMessage] = "Hut with the provided id does not exist! ";

                return this.RedirectToAction("All", "Mountain");
            }

            if ( !this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must be the administrator in order to delete huts!";

                return this.RedirectToAction("Index", "Home");
            }
            try
            {
                HutPreDeleteViewModel viewModel =
                    await this.hutService.GetTripForDeleteByIdAsync(id);
                
                viewModel.ReturnUrl = HttpContext.Request.Headers["Referer"].ToString();

                return this.View(viewModel);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(HutPreDeleteViewModel viewModel, string returnUrl)
        {
            bool hutExists = await this.hutService.ExistsByIdAsync(viewModel.Id);

            if (!hutExists)
            {
                this.TempData[ErrorMessage] = "Hut with the provided id does not exist!"+ viewModel.Id;

                return this.RedirectToAction("All", "Mountain");
            }


            if (!this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must be the administrator in order to delete huts!";

                return this.RedirectToAction("Index", "Home");
            }

            try
            {
                await this.hutService
                    .DeleteHutByIdAsync(viewModel.Id);

                this.TempData[SuccessMessage] = "Hut was successfully deleted!";

                if (!string.IsNullOrEmpty(returnUrl))
                {
                    return Redirect(returnUrl);
                }

                return RedirectToAction("All", "Mountain");

            }
            catch (Exception)
            {
                return GeneralError();
            }
        }
        private IActionResult GeneralError()
        {
            this.TempData[ErrorMessage] = "Unexpected error occured! Please try again later or contact administator.";

            return this.RedirectToAction("Index", "Home");
        }
    }
}
