namespace TrailVenturesSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TrailVenturesSystem.Data.Models;

    public class SeedTripsEntityConfiguration : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            //builder.HasData(this.GenerateTrips());
        }

        private Trip[] GenerateTrips()
        {
            ICollection<Trip> trips = new HashSet<Trip>();

            Trip trip;

            trip = new Trip
            {
                Title = "Botev's Quest: Conquering the Summit of Stara Planina",
                MountainId = 5,
                StartDate = new DateTime(2023, 6, 30),
                ReturnDate = new DateTime(2023, 6, 30),
                Description="Meeting Point is Panorama Lodge Parking Lot at 70:00AM\r\n\r\nSchedule is as follows: \r\n\r\n7:00 AM - Meeting and Introduction:\r\nGather at the Panorama Lodge parking lot, where our experienced guide will provide an overview of the day's hike and safety instructions.\r\n\r\n7:30 AM - Start of the Hike:\r\nEmbark on the scenic trail to Mount Botev. The trail will lead us through lush forests, rocky terrain, and captivating landscapes.\r\n\r\n10:30 AM - Rest Stop:\r\nPause for a well-deserved break and snack. Enjoy the stunning panoramic views and capture some memorable photos.\r\n\r\n12:30 PM - Summit Approach:\r\nAs we ascend further, the trail becomes steeper and more challenging. Our guide will lead the way, ensuring everyone's safety.\r\n\r\n2:00 PM - Summit Victory:\r\nReach the summit of Mount Botev and relish in the accomplishment. Marvel at the breathtaking 360-degree views of the Balkan Mountains and beyond.\r\n\r\n2:30 PM - Lunch at the Summit:\r\nEnjoy a packed lunch while basking in the beauty of the summit. Take your time to soak in the serenity and grandeur of the surroundings.\r\n\r\n3:30 PM - Descent Begins:\r\nStart the descent back down the trail, retracing our steps while still savoring the natural wonders around us.\r\n\r\n6:00 PM - Return to Panorama Lodge:\r\nArrive back at the Panorama Lodge, where you can freshen up and reflect on the day's incredible adventure.\r\n\r\n6:30 PM - Farewell and Departure:\r\nBid farewell to fellow hikers and our guide, with memories of an unforgettable day on Mount Botev in the Balkans.\r\n\r\nImportant Notes:\r\nThis hike requires a moderate level of fitness and proper hiking gear.\r\nAll participants are expected to follow the guide's instructions for safety.\r\nWeather conditions can change, so come prepared with appropriate clothing and footwear.\r\nRemember to bring water, snacks, sunscreen, a hat, and a camera to capture the stunning vistas.\r\nJoin us for an exhilarating day of exploration, challenge, and natural beauty on Mount Botev!",                GroupMaxSize = 10,
                PricePerPerson = 10.00M,
                GuideId = Guid.Parse("3352A20E-6FA8-43B3-A919-5BD557363F5A"),
            };
            trips.Add(trip);

            trip = new Trip
            {
                Title = "Vihren's Summit Serenade: A Tale of Triumph in Pirin's Pristine Wilderness",
                MountainId = 2,
                StartDate = new DateTime(2023, 7, 15),
                ReturnDate = new DateTime(2023, 7, 15),
                GroupMaxSize = 5,
                Description= "Meeting Point:\r\nBansko Visitor Center\r\n\r\nMeeting Time:\r\n6:30 AM\r\n\r\nItinerary:\r\n\r\n6:30 AM - Meeting and Registration:\r\nGather at the Bansko Visitor Center, where our experienced mountain guide will provide a brief orientation, distribute any necessary permits, and ensure everyone is prepared for the hike.\r\n\r\n7:00 AM - Departure to Base Camp:\r\nTravel by minibus to the trailhead, located near Vihren Hut, the starting point of the hike.\r\n\r\n8:00 AM - Start of the Hike:\r\nBegin the ascent from Vihren Hut. The trail offers stunning views of the surrounding Pirin National Park, with diverse landscapes ranging from alpine meadows to rocky terrains.\r\n\r\n10:00 AM - Alpine Lake Break:\r\nReach the picturesque Bunderitsa Lake, a serene alpine lake nestled amidst the mountains. Take a break to enjoy the scenery and have a snack.\r\n\r\n12:00 PM - Summit Approach:\r\nContinue the hike, gradually gaining altitude as you approach the summit of Mount Vihren. The trail becomes steeper, requiring careful footing and determination.\r\n\r\n1:30 PM - Summit Triumph:\r\nArrive at the summit of Mount Vihren, the highest peak in the Pirin Mountains. Revel in the panoramic vistas that stretch across the entire region.\r\n\r\n2:00 PM - Summit Lunch:\r\nEnjoy a well-deserved packed lunch while taking in the breathtaking views from the top of Mount Vihren.\r\n\r\n3:00 PM - Descent Begins:\r\nBegin the descent back down the trail, marveling at the changing scenery and relishing the accomplishments of the day.\r\n\r\n5:30 PM - Return to Vihren Hut:\r\nArrive back at Vihren Hut, where you can rest, rehydrate, and reflect on the day's adventure.\r\n\r\n6:00 PM - Return to Bansko:\r\nTravel back to Bansko by minibus, sharing stories and memories from the hike with fellow adventurers.\r\n\r\n7:30 PM - Arrival at Bansko Visitor Center:\r\nReach the Bansko Visitor Center, where you can bid farewell to your guide and fellow hikers, enriched by the experience of conquering Mount Vihren.\r\n\r\nImportant Notes:\r\n\r\nParticipants should have a good level of physical fitness and wear appropriate hiking gear.\r\nFollow the guide's instructions for safety during the hike.\r\nBe prepared for changing weather conditions; bring warm clothing, rain gear, sturdy footwear, and sunscreen.\r\nCarry sufficient water, snacks, a camera, and any personal medications.\r\nJoin us for an unforgettable day exploring the majestic beauty of Pirin National Park and summiting the iconic Mount Vihren!",                PricePerPerson = 15.00M,
                GuideId = Guid.Parse("3352A20E-6FA8-43B3-A919-5BD557363F5A")
            };
            trips.Add(trip);

            return trips.ToArray();
        }
    }
}
