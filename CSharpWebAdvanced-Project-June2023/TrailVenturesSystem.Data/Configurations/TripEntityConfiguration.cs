namespace TrailVenturesSystem.Data.Configurations
{
   
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.Extensions.Configuration;
    using TrailVenturesSystem.Data.Models;
    /// <summary>
    /// configuring the fluent API for Trip
    /// </summary>
    public class TripEntityConfiguration : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder
                .HasOne(t => t.Guide)
                .WithMany(g => g.CreatedTrips)
                .HasForeignKey(t => t.GuideId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                 .HasMany(t => t.Hikers)
                 .WithMany(h => h.EnrolledTrips);
        }
    }
}
