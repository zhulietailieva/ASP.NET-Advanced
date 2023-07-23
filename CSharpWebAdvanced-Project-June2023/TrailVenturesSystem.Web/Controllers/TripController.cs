namespace TrailVenturesSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class TripController : Controller
    {
        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            return View();
        }
    }
}
