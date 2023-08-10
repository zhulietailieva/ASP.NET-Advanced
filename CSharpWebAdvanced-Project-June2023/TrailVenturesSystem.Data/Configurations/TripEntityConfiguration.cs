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
                .Property(t => t.CreatedOn)
                .HasDefaultValueSql("GETDATE()");

            builder
                .Property(t => t.IsActive)
                .HasDefaultValue(true);

            builder
                .HasOne(t => t.Guide)
                .WithMany(g => g.CreatedTrips)
                .HasForeignKey(t => t.GuideId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                 .HasMany(t => t.Hikers)
                 .WithMany(h => h.EnrolledTrips);

            builder
                .HasOne(t => t.Mountain)
                .WithMany(m => m.Trips)
                .HasForeignKey(t => t.MountainId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(t => t.Hut)
                .WithMany(h => h.Trips)
                .HasForeignKey(t => t.HutId)
                .OnDelete(DeleteBehavior.Restrict);
        }
       

        
    }
}
