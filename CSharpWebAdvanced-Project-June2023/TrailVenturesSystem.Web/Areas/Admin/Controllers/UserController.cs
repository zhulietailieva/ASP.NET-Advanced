namespace TrailVenturesSystem.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;
    using TrailVenturesSystem.Services.Data.Interfaces;
    using TrailVenturesSystem.Web.ViewModels.User;

    using static Common.GeneralApplicationConstants;
    public class UserController : BaseAdminController
    {

        private readonly IUserService userService;
        private readonly IMemoryCache memoryCache;

        public UserController(IUserService userService, IMemoryCache memoryCache)
        {
            this.userService = userService;
            this.memoryCache = memoryCache;
        }

        [Route("User/All")]
        [ResponseCache(Duration =30)]
        public async Task<IActionResult> All()
        {
            IEnumerable<UserViewModel> users =
                this.memoryCache.Get<IEnumerable<UserViewModel>>(UsersCacheKey);

            if (users == null)
            {
                users = await this.userService.AllASync();

                MemoryCacheEntryOptions cacheOptions =
                    new MemoryCacheEntryOptions()
                        .SetAbsoluteExpiration(TimeSpan.FromMinutes(UsersCacheDurationMinutes));

                this.memoryCache.Set(UsersCacheKey, users, cacheOptions);
            }

            return View(users);

        }
    }
}
