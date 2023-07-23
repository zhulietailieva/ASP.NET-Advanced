namespace TrailVenturesSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    [Authorize]
    public class GuideController : Controller
    {
        public async Task<IActionResult> Become()
        {
            return View();
        }
    }
}
