namespace TrailVenturesSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TrailVenturesSystem.Web.Infrastructure.Extensions;
    using TrailVenturesSystem.Services.Data.Interfaces;

    [Authorize]
    public class GuideController : Controller
    {
        private readonly IGuideService guideService;

        public GuideController(IGuideService guideService)
        {
            this.guideService = guideService;
        }

       /* [HttpGet]
        public async Task<IActionResult> Become()
        {
            
            string? userId = this.User.GetId();
            bool isGuide =await this.guideService.GuideExistsByUserIdAsync(userId);

            if (isGuide)
            {
                return this.BadRequest();
            }

            return View();
        }*/
    }
}
