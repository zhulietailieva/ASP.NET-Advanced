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

            try
            {
                TripFormModel formModel = new TripFormModel()
                {
                    Mountains =await this.mountainService.AllMountainsAsync()
                };

                return View(formModel);

            }
            catch (Exception)
            {
                return this.GeneralError();
            }
            
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
            catch (Exception )
            {
                this.ModelState.AddModelError(string.Empty, "Unexpected error occured while trying to add your new trip! Please try again later or contact administrator.");
                
                model.Mountains = await this.mountainService.AllMountainsAsync();
                return this.View(model);
            }
            return this.RedirectToAction("All", "Trip");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            bool tripExists = await this.tripService
                .ExistsByIdAsync(id);
            if (!tripExists)
            {
                this.TempData[ErrorMessage] = "Trip with the provided id does not exist!";

                return this.RedirectToAction("Trip", "All");
            }

            try
            {
                TripDetailsViewModel viewModel = await this.tripService
                    .GetDetailsByIdAsync(id);

                return View(viewModel);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
           
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            bool tripExists = await this.tripService
               .ExistsByIdAsync(id);
            if (!tripExists)
            {
                this.TempData[ErrorMessage] = "Trip with the provided id does not exist!";

                return this.RedirectToAction("All", "Trip");
            }

            //should also check if user is guide
            

            bool isUserGuide =await this.guideService
                .GuideExistsByUserIdAsync(this.User.GetId()!);

            if (!isUserGuide)
            {
                this.TempData[ErrorMessage] = "You must become a guide in order to edit trip info!";

                return this.RedirectToAction("Become", "Guide");
            }

            //guide should only be able to edit their own trips

            string? guideId = await this.guideService
                .GetGuideIdByUserIdAsync(this.User.GetId()!);

            bool isGuideCreator = await this.tripService
                .IsGuideWithIdCreatorOfTripWithIdAsync(id, guideId!);

            if (!isGuideCreator)
            {
                this.TempData[ErrorMessage] = "You must be the creator in order to edit this trip!";

                return this.RedirectToAction("Mine", "Trip");
            }
            try
            {
                TripFormModel formModel = await this.tripService
                    .GetTripForEditByIdAsync(id);

                formModel.Mountains = await this.mountainService.AllMountainsAsync();

                return this.View(formModel);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error occured! Please try again later or contact administator.";

                return this.RedirectToAction("Index", "Home");
            }

            

        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id,TripFormModel model)
        {
            if (!this.ModelState.IsValid)
            {
                model.Mountains = await this.mountainService.AllMountainsAsync();
                return this.View(model);
            }

            bool tripExists = await this.tripService
               .ExistsByIdAsync(id);
            if (!tripExists)
            {
                this.TempData[ErrorMessage] = "Trip with the provided id does not exist!";

                return this.RedirectToAction("All", "Trip");
            }

            //should also check if user is guide


            bool isUserGuide = await this.guideService
                .GuideExistsByUserIdAsync(this.User.GetId()!);

            if (!isUserGuide)
            {
                this.TempData[ErrorMessage] = "You must become a guide in order to edit trip info!";

                return this.RedirectToAction("Become", "Guide");
            }

            //guide should only be able to edit their own trips

            string? guideId = await this.guideService
                .GetGuideIdByUserIdAsync(this.User.GetId()!);

            bool isGuideCreator = await this.tripService
                .IsGuideWithIdCreatorOfTripWithIdAsync(id, guideId!);

            if (!isGuideCreator)
            {
                this.TempData[ErrorMessage] = "You must be the creator in order to edit this trip!";

                return this.RedirectToAction("Mine", "Trip");
            }

            try
            {
                await this.tripService.EditTripByIdAndFormModel(id, model);
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "Unexpected error occured while trying to update the trip! Please try again later or contact administrator.");

                model.Mountains = await this.mountainService.AllMountainsAsync();

                return this.View(model);
            }

            return this.RedirectToAction("Details", "Trip", new { id });

        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            List<TripAllViewModel> myTrips =
                new List<TripAllViewModel>();

            string userId = this.User.GetId()!;
            bool isGuide = await this.guideService
                .GuideExistsByUserIdAsync(userId);
            try
            {
                if (isGuide)
                {
                    //if user is guide => show all of their created trips
                    string? guideId =
                        await this.guideService.GetGuideIdByUserIdAsync(userId);

                    myTrips.AddRange(await this.tripService.AllByGuideIdAsync(guideId!));
                }
                else
                {
                    //if user is not a guide => show al of their enrolled trips
                    myTrips.AddRange(await this.tripService.AllByUserIdAsync(userId));
                }

                return this.View(myTrips);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
            

        }

        private IActionResult GeneralError()
        {
            this.TempData[ErrorMessage] = "Unexpected error occured! Please try again later or contact administator.";

            return this.RedirectToAction("Index", "Home");
        }
    }
}
