namespace TrailVenturesSystem.Common
{
    /// <summary>
    /// hollds all constant for web app
    /// </summary>
    public static class GeneralApplicationConstants
    {
        public const int ReleaseYear = 2023;

        public const int DefaultPage = 1;
        public const int EntitiesPerPage = 3;

        public const string AdminAreaName = "Admin";
        public const string AdminRoleName = "Administator";
        public const string DevelopmentAdminEmail = "admin@trailventures.bg";

        public const string UsersCacheKey = "UsersCache";
        public const int UsersCacheDurationMinutes = 5;
    }
}