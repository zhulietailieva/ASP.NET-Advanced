namespace TrailVenturesSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using TrailVenturesSystem.Services.Data.Interfaces;
    using TrailVenturesSystem.Web.ViewModels.Home;

    public class HomeController : Controller
    {
        private readonly ITripService tripService;

        public HomeController(ITripService tripService)
        {
            this.tripService = tripService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<IndexViewModel> viewModel =
                await this.tripService.LastFiveTripsAsync();

            return View(viewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}