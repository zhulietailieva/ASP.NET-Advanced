namespace TrailVenturesSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TrailVenturesSystem.Services.Data.Interfaces;
    using TrailVenturesSystem.Web.Infrastructure.Extensions;
    using TrailVenturesSystem.Web.ViewModels.Mountain;

    using static Common.NotificationMessagesConstants;

    [Authorize]
    public class MountainController : Controller
    {
        private readonly IMountainService mountainService;
        public MountainController(IMountainService mountainService)
        {
            this.mountainService = mountainService;
        }
        public async Task<IActionResult> All()
        {
            IEnumerable<AllMountainsViewModel> viewModel =
                await this.mountainService.AllMountainsForListAsync();

            return View(viewModel);
        }

        public async Task<IActionResult> Details(int id,string information)
        {
            bool mountainExists = await mountainService.ExistsByIdAsync(id);
            if (!mountainExists)
            {
                return NotFound();
            }

            MountainDetailsViewModel viewModel =
                await mountainService.GetDetailsByIdAsync(id);

            if (viewModel.GetUrlInformation() != information)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            if (!User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must be an administrator in order to add ountains!";
                return this.RedirectToAction("All", "Mountain");
            }

            try
            {
                MountainFormModel formModel = new MountainFormModel()
                {

                };
                return View(formModel);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
        }

        [HttpPost]

        public async Task<IActionResult> Add(MountainFormModel model)
        {
            if (!User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must be an administrator in order to add ountains!";
                return this.RedirectToAction("All", "Mountain");
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }
            try
            {
                int mountainId = await this.mountainService.CreateAndReturnIdAsync(model);

                this.TempData[SuccessMessage] = "Mountain was added successfully!";
                return this.RedirectToAction("All", "Mountain");

            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Error!";
                this.ModelState.AddModelError(string.Empty,
                    "Unexpected error occured while trying to add new mountain! Please try again later.");
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
