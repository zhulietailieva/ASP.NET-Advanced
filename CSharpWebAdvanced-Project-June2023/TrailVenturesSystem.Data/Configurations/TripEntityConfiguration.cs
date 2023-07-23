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

            builder.HasData(this.GenerateTrips());
        }
        //seed some trips

        private Trip[] GenerateTrips()
        {
            ICollection<Trip> trips = new HashSet<Trip>();

            Trip trip;

            trip = new Trip
            {
                Title = "Pesho\'s first created trip",
                Mountain = "Stara Planina",
                StartDate = new DateTime(2023, 6, 30),
                ReturnDate=new DateTime(2023, 6, 30),
                Description= "Embark on a thrilling adventure in Bulgaria's majestic Stara Planina with the Mount Botev hike. Ascend through lush forests and rocky terrain to reach the summit, where breathtaking panoramic views await. Immerse yourself in the beauty of the Balkans and discover the intriguing legends surrounding this mystical peak. A memorable journey for nature enthusiasts and explorers alike.",
                PricePerPerson=10.00M,
                GuideId=Guid.Parse("3352A20E-6FA8-43B3-A919-5BD557363F5A"),
                //TODO: Add application user in the hikers property through method called getUserById?
            };
            trips.Add(trip);

            trip = new Trip
            {
                Title = "Pesho\'s second created trip",
                Mountain = "Pirin",
                StartDate = new DateTime(2023, 7, 15),
                ReturnDate = new DateTime(2023, 7, 15),
                Description = "Experience the awe-inspiring beauty of Bulgaria's Pirin Mountains on the Mount Vihren hike. Trek through pristine alpine landscapes, passing crystal-clear lakes and wildflower meadows. As you ascend towards the summit, be captivated by sweeping vistas of rugged peaks and glacial valleys below. A challenging yet rewarding adventure, perfect for hikers seeking breathtaking natural wonders in the heart of the Balkans.",
                PricePerPerson = 15.00M,
                GuideId = Guid.Parse("3352A20E-6FA8-43B3-A919-5BD557363F5A")
            };
            trips.Add(trip);

            return trips.ToArray();
        }
    }
}
