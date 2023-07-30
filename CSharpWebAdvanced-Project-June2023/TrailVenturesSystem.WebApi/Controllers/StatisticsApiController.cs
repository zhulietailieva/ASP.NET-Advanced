namespace TrailVenturesSystem.WebApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Net;
    using TrailVenturesSystem.Services.Data.Interfaces;
    using TrailVenturesSystem.Services.Data.Models.Statistics;

    [Route("api/statistics")]
    [ApiController]
    public class StatisticsApiController : ControllerBase
    {
        private readonly ITripService tripService;

        public StatisticsApiController(ITripService tripService)
        {
            this.tripService = tripService;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(200,Type=typeof(StatisticsServiceModel))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetStatistics()
        {
            try
            {
                StatisticsServiceModel serviceModel=
                    await this.tripService.GetStatisticsAsync();

                return this.Ok(serviceModel);
            }
            catch (Exception)
            {
                return this.BadRequest();
            }
        }
    }
}
