namespace TrailVenturesSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TrailVenturesSystem.Services.Data.Interfaces;
    using TrailVenturesSystem.Web.ViewModels.Mountain;

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
    }
}
