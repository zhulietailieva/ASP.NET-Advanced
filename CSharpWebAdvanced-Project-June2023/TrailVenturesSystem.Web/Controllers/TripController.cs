namespace TrailVenturesSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TrailVenturesSystem.Services.Data.Interfaces;
    using TrailVenturesSystem.Services.Data.Models.Trip;
    using TrailVenturesSystem.Web.Infrastructure.Extensions;
    using TrailVenturesSystem.Web.ViewModels.Trip;

    using static Common.NotificationMessagesConstants;

    [Authorize]
    public class TripController : Controller
    {
        private readonly IMountainService mountainService;
        private readonly IGuideService guideService;
        private readonly ITripService tripService;
        public TripController(IMountainService mountainService, IGuideService guideService,
            ITripService tripService)
        {
            this.mountainService = mountainService;
            this.guideService = guideService;
            this.tripService = tripService;

        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery]AllTripsQueryModel queryModel)
        {
            AllTripsFilteredAndPagedServiceModel serviceModel =
                await this.tripService.AllAsync(queryModel);

            queryModel.Trips = serviceModel.Trips;
            queryModel.TotalTrips = serviceModel.TotalTripsCount;
            queryModel.Mountains = await this.mountainService.AllMountainNamesAsync();


            return this.View(queryModel);
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
        [HttpPost]
        public async Task<IActionResult> Add(TripFormModel model)
        {
            bool isGuide = await this.guideService.GuideExistsByUserIdAsync(this.User.GetId()!);

            if (!isGuide)
            {
                this.TempData[ErrorMessage] = "You must become a guide in order to create a trip!";
                return this.RedirectToAction("Become", "Guide");
            }

            //user can change the category through inspector and submit faulty data
            bool mountainExists = await this.mountainService.ExistsByIdAsync(model.MountainId);

            if (!mountainExists)
            {
                //Adding model error to ModelState automatically makes ModelState invalid
                this.ModelState.AddModelError(nameof(model.MountainId), "You selected a mountain that does not exist!");
            }

            if (!this.ModelState.IsValid)
            {
                model.Mountains = await this.mountainService.AllMountainsAsync();

                //Will visualize all errors with correct mountains
                return this.View(model);
            }
            //it is preferable that all operations including inserting in database are in try-catch blocks
            try
            {
                //! after the GetId() method means result cannot be null
                string? guideId =await this.guideService.GetGuideIdByUserIdAsync(this.User.GetId()!);
                await this.tripService.CreateAsync(model, guideId!);
            }
            catch (Exception _)
            {

                this.ModelState.AddModelError(string.Empty, "Unexpected error occured while trying to add your new trip! Please try again later or contact administrator.");
                
                model.Mountains = await this.mountainService.AllMountainsAsync();
                return this.View(model);
            }
            return this.RedirectToAction("All", "Trip");
        }
    }
}
