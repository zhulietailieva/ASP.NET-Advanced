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
        private readonly IUserService userService;
        public TripController(IMountainService mountainService, IGuideService guideService,
            ITripService tripService, IUserService userService)
        {
            this.mountainService = mountainService;
            this.guideService = guideService;
            this.tripService = tripService;
            this.userService = userService;
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


            //validate that start date and return date are not in the past -- done through a custom Validation attribute

            //validate if end date is after start date
            if (model.StartDate > model.ReturnDate && model.ReturnDate > DateTime.Today)
            {
                this.ModelState.AddModelError(nameof(model.ReturnDate), "Return date cannot be before or the same as start date");
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
                string? guideId =await this.guideService
                    .GetGuideIdByUserIdAsync(this.User.GetId()!);

                string tripId=await this.tripService
                    .CreateAndReturnIdAsync(model, guideId!);

                this.TempData[SuccessMessage] = "Trip was created successfully!";
                return this.RedirectToAction("Details", "Trip", new {id=tripId});
            }
            catch (Exception )
            {
                this.ModelState.AddModelError(string.Empty, "Unexpected error occured while trying to add your new trip! Please try again later or contact administrator.");
                
                model.Mountains = await this.mountainService.AllMountainsAsync();
                return this.View(model);
            }
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

                viewModel.Guide.FullName =
                    await this.userService.GetFullNameByEmailAsync(this.User.Identity?.Name!);


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

            if (!isUserGuide && !this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must become a guide in order to edit trip info!";

                return this.RedirectToAction("Become", "Guide");
            }

            //guide should only be able to edit their own trips

            string? guideId = await this.guideService
                .GetGuideIdByUserIdAsync(this.User.GetId()!);

            bool isGuideCreator = await this.tripService
                .IsGuideWithIdCreatorOfTripWithIdAsync(id, guideId!);

            if (!isGuideCreator && !this.User.IsAdmin())
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

            if (!isUserGuide && !this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must become a guide in order to edit trip info!";

                return this.RedirectToAction("Become", "Guide");
            }

            //guide should only be able to edit their own trips

            string? guideId = await this.guideService
                .GetGuideIdByUserIdAsync(this.User.GetId()!);

            bool isGuideCreator = await this.tripService
                .IsGuideWithIdCreatorOfTripWithIdAsync(id, guideId!);

            if (!isGuideCreator && !this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must be the creator in order to edit this trip!";

                return this.RedirectToAction("Mine", "Trip");
            }

            try
            {
                await this.tripService.EditTripByIdAndFormModelAsync(id, model);
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "Unexpected error occured while trying to update the trip! Please try again later or contact administrator.");

                model.Mountains = await this.mountainService.AllMountainsAsync();

                return this.View(model);
            }

            this.TempData[SuccessMessage] = "Trip was edited successfully!";
            return this.RedirectToAction("Details", "Trip", new { id });

        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            bool tripExists = await tripService
               .ExistsByIdAsync(id);
            if (!tripExists)
            {
                this.TempData[ErrorMessage] = "Trip with the provided id does not exist!";

                return this.RedirectToAction("All", "Trip");
            }

            //should also check if user is guide


            bool isUserGuide = await this.guideService
                .GuideExistsByUserIdAsync(this.User.GetId()!);

            if (!isUserGuide && !this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must become a guide in order to edit trip info!";

                return this.RedirectToAction("Become", "Guide");
            }

            //guide should only be able to edit their own trips

            string? guideId = await this.guideService
                .GetGuideIdByUserIdAsync(this.User.GetId()!);

            bool isGuideCreator = await this.tripService
                .IsGuideWithIdCreatorOfTripWithIdAsync(id, guideId!);

            if (!isGuideCreator && !this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must be the creator in order to edit this trip!";

                return this.RedirectToAction("Mine", "Trip");
            }

            try
            {
                TripPreDeleteDetailsViewModel viewModel =
                    await this.tripService.GetTripForDeleteByIdAsync(id);

                return this.View(viewModel);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }

        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id,TripPreDeleteDetailsViewModel model)
        {
            bool tripExists = await tripService
               .ExistsByIdAsync(id);
            if (!tripExists)
            {
                this.TempData[ErrorMessage] = "Trip with the provided id does not exist!";

                return this.RedirectToAction("All", "Trip");
            }

            //should also check if user is guide


            bool isUserGuide = await this.guideService
                .GuideExistsByUserIdAsync(this.User.GetId()!);

            if (!isUserGuide && !this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must become a guide in order to edit trip info!";

                return this.RedirectToAction("Become", "Guide");
            }

            //guide should only be able to edit their own trips

            string? guideId = await this.guideService
                .GetGuideIdByUserIdAsync(this.User.GetId()!);

            bool isGuideCreator = await this.tripService
                .IsGuideWithIdCreatorOfTripWithIdAsync(id, guideId!);

            if (!isGuideCreator && !this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must be the creator in order to edit this trip!";

                return this.RedirectToAction("Mine", "Trip");
            }

            try
            {
                await this.tripService.DeleteTripByIdAsync(id);

                this.TempData[SuccessMessage] = "Your trip was successfully deleted!";

                return this.RedirectToAction("Mine", "Trip");
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
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
                if (this.User.IsAdmin())
                {
                    string? guideId =
                        await this.guideService.GetGuideIdByUserIdAsync(userId);
                    //added houses as a guide
                    myTrips.AddRange(await this.tripService.AllByGuideIdAsync(guideId!));

                    //rented houses as a user
                    myTrips.AddRange(await this.tripService.AllByUserIdAsync(userId));

                    myTrips = myTrips.DistinctBy(t => t.Id).ToList();

                }
                else if (isGuide)
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

        [HttpPost]
        public async Task<IActionResult> Join(string id)
        {
            //does this trup exist?

            bool tripExists = await this.tripService.ExistsByIdAsync(id);

            if (!tripExists)
            {
                this.TempData[ErrorMessage] = "Trip with provided id does not exist!";

                return this.RedirectToAction("All", "Trip");
            }

            bool isTripFull = await this.tripService.IsFullByIdAsync(id);

            if (isTripFull)
            {
                this.TempData[ErrorMessage] = "This trip does not have available places! Please select another trip.";

                return this.RedirectToAction("All", "Trip");
            }

            bool isUserGuide = await this.guideService.GuideExistsByUserIdAsync(this.User.GetId()!);

            if (isUserGuide && !this.User.IsAdmin())
            {
                //guide cannot join other trips (maybe change functionality later?)

                this.TempData[ErrorMessage] = "Guides cannot join trips! Please register as a user.";

                return this.RedirectToAction("Index","Home");
            }

            try
            {
                await this.tripService.JoinTripAsync(id, this.User.GetId()!);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }

            this.TempData[SuccessMessage] = "You successfuly joined this trip!"; 

            return this.RedirectToAction("Mine", "Trip");
        }

        [HttpPost]

        public async Task<IActionResult> Leave(string id)
        {
            //does this trip exist?

            bool tripExists = await this.tripService.ExistsByIdAsync(id);

            if (!tripExists)
            {
                this.TempData[ErrorMessage] = "Trip with provided id does not exist!";

                return this.RedirectToAction("All", "Trip");
            }

            //might not work

            bool hasCurrentUserJoinedTrip = 
                await this.tripService.IsUserWithIdPartOfTripByIdAsync(id, this.User.GetId()!);
           

            if (!hasCurrentUserJoinedTrip)
            {
                
                this.TempData[ErrorMessage] = "You are not in this trips's participants!";

                return this.RedirectToAction("Mine", "Trip");
            }

            try
            {
                await this.tripService.LeaveTripAsync(id, this.User.GetId()!);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }

            this.TempData[SuccessMessage] = "You successfuly left this trip!";

            return this.RedirectToAction("Mine", "Trip");
            
        }
        private IActionResult GeneralError()
        {
            this.TempData[ErrorMessage] = "Unexpected error occured! Please try again later or contact administator.";

            return this.RedirectToAction("Index", "Home");
        }
    }
}
