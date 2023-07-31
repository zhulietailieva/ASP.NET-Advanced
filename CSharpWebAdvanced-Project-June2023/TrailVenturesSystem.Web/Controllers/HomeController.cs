﻿namespace TrailVenturesSystem.Web.Controllers
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

        public IActionResult Sample()
        {
            return View("SamplePage");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode==400 || statusCode == 404)
            {
                return this.View("Error404");
            }

            if (statusCode == 401)
            {
                return this.View("Error401");
            }
            return View();
        }
    }
}