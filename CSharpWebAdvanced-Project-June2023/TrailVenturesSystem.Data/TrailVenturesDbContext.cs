namespace TrailVenturesSystem.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using TrailVenturesSystem.Data.Configurations;
    using TrailVenturesSystem.Data.Models;

    public class TrailVenturesDbContext : IdentityDbContext<ApplicationUser,IdentityRole<Guid>,Guid>
    {

        private readonly bool seedDb;

        public TrailVenturesDbContext(DbContextOptions<TrailVenturesDbContext> options,bool seedDb=true)
            : base(options)
        {
            this.seedDb = seedDb; 
        }

        public DbSet<Trip> Trips { get; set; } = null!;

        public DbSet<Guide> Guides { get; set; } = null!;

        public DbSet<Mountain> Mountains { get; set; } = null!;

        public DbSet<Hut> Huts { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder builder)
        {
            /*Assembly configAssembly = Assembly.GetAssembly(typeof(TrailVenturesDbContext)) ??
                                      Assembly.GetExecutingAssembly();
            builder.ApplyConfigurationsFromAssembly(configAssembly);
            */
            builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
            builder.ApplyConfiguration(new TripEntityConfiguration());

            if (this.seedDb)
            {
                builder.ApplyConfiguration(new MountainEntityConfiguration());
                builder.ApplyConfiguration(new SeedTripsEntityConfiguration());
            }
            base.OnModelCreating(builder);
        }
    }
}