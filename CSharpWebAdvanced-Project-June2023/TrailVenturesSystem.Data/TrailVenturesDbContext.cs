namespace TrailVenturesSystem.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;
    using TrailVenturesSystem.Data.Models;

    //:IdentityDbContext<user,role,key>
    public class TrailVenturesDbContext : IdentityDbContext<ApplicationUser,IdentityRole<Guid>,Guid>
    {
        public TrailVenturesDbContext(DbContextOptions<TrailVenturesDbContext> options)
            : base(options)
        {

        }

        public DbSet<Trip> Trips { get; set; } = null!;

        public DbSet<Guide> Guides { get; set; } = null!;

        public DbSet<Mountain> Mountains { get; set; } = null!;

        public DbSet<Hut> Huts { get; set; } = null!;

        //no DbSet for ApplicationUser because IdentityDbContext injects it automatically

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Assembly configAssembly = Assembly.GetAssembly(typeof(TrailVenturesDbContext)) ??
                                      Assembly.GetExecutingAssembly();
            builder.ApplyConfigurationsFromAssembly(configAssembly);

            base.OnModelCreating(builder);
        }
    }
}