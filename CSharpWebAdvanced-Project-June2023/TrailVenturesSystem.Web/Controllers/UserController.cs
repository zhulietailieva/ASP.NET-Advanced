namespace TrailVenturesSystem.Web.Controllers
{
    using Griesoft.AspNetCore.ReCaptcha;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;
    using TrailVenturesSystem.Data.Models;
    using TrailVenturesSystem.Services.Data;
    using TrailVenturesSystem.Services.Data.Interfaces;
    using TrailVenturesSystem.Web.Infrastructure.Extensions;
    using TrailVenturesSystem.Web.ViewModels.User;

    using static Common.GeneralApplicationConstants;
    using static Common.NotificationMessagesConstants;
    public class UserController : Controller
    {
        //for login
        private readonly SignInManager<ApplicationUser> signInManager;

        //for registration
        private readonly UserManager<ApplicationUser> userManager;

        private readonly IMemoryCache memoryCache;

        private readonly IUserService userService;
        private readonly IGuideService guideService;

        public UserController(SignInManager<ApplicationUser> signInManager,
                                UserManager<ApplicationUser> userManager,
                                IUserService userService,IGuideService guideService, 
                                IMemoryCache memoryCache)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;

            this.userService = userService;
            this.guideService = guideService;

            this.memoryCache = memoryCache;
        }

        [HttpGet]

        //IActionResult (no Task) because there are no async operations
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateRecaptcha(Action=nameof(Register),
            ValidationFailedAction =ValidationFailedAction.ContinueRequest)]
           
        public async Task<IActionResult> Register(RegisterFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            ApplicationUser user = new ApplicationUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
            };

            await this.userManager.SetEmailAsync(user, model.Email);
            await this.userManager.SetUserNameAsync(user, model.Email);

            IdentityResult result =
                await this.userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                foreach(IdentityError error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(model);
            }
            await this.signInManager.SignInAsync(user, false);
            this.memoryCache.Remove(UsersCacheKey);

            return this.RedirectToAction("Index","Home");            
        }

        [HttpGet]
        public async Task<IActionResult> Login(string? returnUrl = null)
        {
            //ensures clear log in process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            LoginFormModel model = new LoginFormModel()
            {
                ReturnUrl = returnUrl
            };

            return this.View(model);
        }

        [HttpPost]

        //we use async Task<> where there are async operations
        public async Task<IActionResult> Login(LoginFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var result=
                await this.signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

            if (!result.Succeeded)
            {
                this.TempData[ErrorMessage] = "There was an error while logging you in! Please try again later or contact administrator.";

                return this.View(model);
            }

            return this.Redirect(model.ReturnUrl ?? "/Home/Index");
        }

        [Authorize]
        public async Task<IActionResult> Profile()
        {
            string userId = this.User.GetId()!;

            ProfileViewModel viewModel = await this.userService.GetUserDataForProfileAsync(userId);

            return View(viewModel);
        }
        //AJAX loading
        public IActionResult AdditionalInfoPartial()
        {
            return PartialView("_AdditionalInfoPartial");
            
        }
        
        [HttpPost]
        public async  Task<IActionResult> SaveAdditionalInfo([FromBody] ProfileDetailsFormModel model)
        {

            if(model == null)
            {
                return this.BadRequest();
            }

            string info = model.Info;

            // Save the additional information to the database or other storage
            try
            {               
                await this.userService.AddPersonalInfoAsync(this.User.GetId(), info);
                TempData[SuccessMessage] = "Successfully updated profile info!";
                return this.RedirectToAction("Profile", "User");
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Error while updating profile info! Please try again!";
                return this.RedirectToAction("Profile","User");
            }
        }

    }
}
