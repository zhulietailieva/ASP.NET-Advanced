using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrailVenturesSystem.Data.Migrations
{
    public partial class AddedMountainsTableToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: new Guid("b3efbe07-8d1b-4408-a2b0-f9c9aa2dcb84"));

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: new Guid("e830e7bb-63b3-4d0f-a398-1e72f37bfd60"));

            migrationBuilder.DropColumn(
                name: "Mountain",
                table: "Trips");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Trips",
                type: "nvarchar(max)",
                maxLength: 8000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(3000)",
                oldMaxLength: 3000);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Trips",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 28, 22, 7, 27, 200, DateTimeKind.Utc).AddTicks(2728),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 23, 21, 59, 0, 293, DateTimeKind.Utc).AddTicks(7650));

            migrationBuilder.AddColumn<int>(
                name: "MountainId",
                table: "Trips",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Mountains",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mountains", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Mountains",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Rila" },
                    { 2, "Pirin" },
                    { 3, "Vitosha" },
                    { 4, "Rhodope Mountains" },
                    { 5, "Balkan Mountains" },
                    { 6, "Strandzha" },
                    { 7, "Osogovo" },
                    { 8, "Sredna Gora" },
                    { 9, "Slavyanka" },
                    { 10, "Belasitsa" }
                });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "Description", "GuideId", "MountainId", "PricePerPerson", "ReturnDate", "StartDate", "Title" },
                values: new object[] { new Guid("6b0714fd-474c-4198-b98b-1254d65df1fe"), "Welcome to an exhilarating journey of a lifetime as we embark on a challenging trek to conquer the majestic Mount Botev in the stunning Stara Planina mountain range of Bulgaria. This thrilling expedition is set to begin on the morning of 21st July 2023, promising an unforgettable experience for all participants. So, lace up your boots, pack your bags, and get ready for an adventure like no other!\r\n\r\nMeeting Place:\r\nOur exciting adventure will commence at the picturesque town of Kalofer, located in the foothills of Stara Planina. On the morning of 21st July 2023, at precisely 8:00 AM, we will gather at the town's central square, where our experienced guide, Dimitar, will introduce the itinerary and provide essential safety instructions. Kalofer's charm and warm hospitality make it an ideal starting point for our unforgettable journey to Mount Botev.\r\n\r\nDuration of the Trip:\r\nThe trek to Mount Botev will span over four days and three nights. Each day, we will conquer different segments of the trail, relishing the diverse beauty of Stara Planina and gradually making our way to the summit of Mount Botev. The journey is designed to challenge and inspire adventurers of all levels, making it a remarkable experience for everyone involved.\r\n\r\nWhat to Pack:\r\nPacking the right gear and essentials is crucial for a successful and comfortable trip. Here's a comprehensive list of items each participant should carry in their bags:\r\n\r\nBackpack: Choose a sturdy and comfortable backpack with enough capacity to hold your essentials for the entire journey.\r\n\r\nClothing: Pack lightweight, moisture-wicking shirts and pants suitable for trekking. Ensure you have a warm, waterproof jacket and thermal layers for the higher altitudes where the weather can be unpredictable.\r\n\r\nFootwear: Invest in a pair of reliable, well-fitted hiking boots with ankle support. Break them in before the trip to avoid blisters.\r\n\r\nRain Gear: Don't forget a reliable raincoat or a poncho to keep you dry in case of sudden showers.\r\n\r\nHeadwear: A wide-brimmed hat or a cap will protect you from the sun during the day, while a warm beanie will be essential for the chilly nights.\r\n\r\nGloves: Lightweight gloves are ideal for protecting your hands during the hike.\r\n\r\nSocks: Pack moisture-wicking, comfortable socks to prevent blisters.\r\n\r\nSleeping Bag: Bring a compact, lightweight sleeping bag suitable for summer temperatures.\r\n\r\nTent: If you prefer camping, a lightweight and waterproof tent will be essential.\r\n\r\nHydration System: Carry a refillable water bottle or a hydration pack to stay hydrated throughout the journey.\r\n\r\nSnacks and Food: Bring energy bars, trail mix, and other lightweight snacks to keep you energized during the hike. Our guide will also arrange for meals at designated spots.\r\n\r\nPersonal First Aid Kit: Include band-aids, pain relievers, and any personal medications you might need.\r\n\r\nSunscreen and Insect Repellent: Protect your skin from the sun's rays and insect bites.\r\n\r\nClothing Tips:\r\nAs we venture into the wilderness of Stara Planina, it's essential to follow these clothing tips to ensure comfort and safety:\r\n\r\nLayering: Dress in layers so you can add or remove clothing as the temperature changes.\r\n\r\nBreathable Fabrics: Opt for clothing made from breathable materials to stay comfortable during the hike.\r\n\r\nDrying Clothes: Bring extra plastic bags to store wet or dirty clothes separately from clean ones.\r\n\r\nConservative Dress: When visiting local villages or towns, please be respectful of the local culture and dress modestly.", new Guid("3352a20e-6fa8-43b3-a919-5bd557363f5a"), 5, 10.00m, new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Botev's Quest: Conquering the Summit of Stara Planina" });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "Description", "GuideId", "MountainId", "PricePerPerson", "ReturnDate", "StartDate", "Title" },
                values: new object[] { new Guid("c9ac83be-b220-470f-aa32-3414cf67ab5a"), "Welcome to an unforgettable expedition to the breathtaking Mount Vihren, nestled in the pristine Pirin National Park of Bulgaria. This thrilling journey is set to commence on the morning of 29th March 2023, offering a unique opportunity to explore the awe-inspiring landscapes of Pirin, conquer the mighty Mount Vihren, and forge lifelong memories. So, gather your spirit of adventure, and let's embark on an extraordinary quest to reach the summit of Mount Vihren!\r\n\r\nMeeting Place:\r\nOur exhilarating adventure begins in the charming town of Bansko, located at the foothills of the Pirin Mountains. On 29th March 2023, at 9:00 AM, we will assemble at the Bansko Adventure Center, situated in the heart of the town. There, our experienced and knowledgeable guide, Elena, will welcome us warmly, introduce the itinerary, and conduct a safety briefing to ensure a smooth and secure journey to Mount Vihren.\r\n\r\nDuration of the Trip:\r\nThe expedition to Mount Vihren will span three days and two nights, providing ample time to savor the beauty of Pirin National Park and conquer the mighty summit. The itinerary has been thoughtfully crafted to accommodate adventurers of varying experience levels, promising a rewarding and memorable experience for all participants.\r\n\r\nWhat to Pack:\r\nPacking the right gear and essentials is crucial to ensure comfort, safety, and enjoyment during the journey. Here's a comprehensive list of items each participant should carry in their bags:\r\n\r\nBackpack: Choose a durable, comfortable backpack with sufficient capacity to carry your belongings throughout the trip.\r\n\r\nClothing:\r\n\r\nHiking Boots: Invest in sturdy, waterproof hiking boots with excellent ankle support to navigate the uneven terrain.\r\nMoisture-Wicking Layers: Pack lightweight, moisture-wicking shirts and pants to stay dry and comfortable during the trek.\r\nInsulating Layers: Bring a warm fleece or down jacket, as temperatures can vary, especially at higher altitudes.\r\nWaterproof Jacket and Pants: Prepare for unexpected weather changes with reliable waterproof outerwear.\r\nHat and Gloves: Shield yourself from the sun and cold with a wide-brimmed hat and insulated gloves.\r\nExtra Socks: Carry extra pairs of moisture-wicking socks to keep your feet dry and blister-free.\r\nSleeping Gear:\r\n\r\nSleeping Bag: Select a lightweight and compact sleeping bag suitable for the springtime temperatures in Pirin.\r\nCamping Gear:\r\n\r\nTent: If you prefer camping, a lightweight, weatherproof tent will provide a cozy shelter during the nights.\r\nHydration and Nutrition:\r\n\r\nWater: Bring a reusable water bottle or a hydration system to stay hydrated during the hike.\r\nSnacks: Pack energy-boosting snacks, such as granola bars, nuts, and dried fruits, to keep you energized on the trail.\r\nPersonal Essentials:\r\n\r\nPersonal Identification: Carry your identification documents in a secure pouch.\r\nFirst Aid Kit: Include band-aids, pain relievers, antiseptic wipes, and any personal medications you may need.\r\nSunscreen and Sunglasses: Protect your skin and eyes from the sun's rays at higher altitudes.\r\nClothing Tips:\r\nAs we venture into Pirin's wilderness, follow these clothing tips to ensure your comfort and safety:\r\n\r\nLayering: Dress in multiple layers, so you can adjust your clothing according to changing weather conditions.\r\n\r\nBreathable Fabrics: Choose moisture-wicking and breathable fabrics to stay comfortable during exertion.\r\n\r\nProper Footwear: Wear well-fitted, broken-in hiking boots to prevent blisters and ensure stability on uneven terrain.\r\n\r\nConservative Dress: Respect local customs and culture by dressing modestly when visiting villages or towns.", new Guid("3352a20e-6fa8-43b3-a919-5bd557363f5a"), 2, 15.00m, new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vihren's Summit Serenade: A Tale of Triumph in Pirin's Pristine Wilderness" });

            migrationBuilder.CreateIndex(
                name: "IX_Trips_MountainId",
                table: "Trips",
                column: "MountainId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Mountains_MountainId",
                table: "Trips",
                column: "MountainId",
                principalTable: "Mountains",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Mountains_MountainId",
                table: "Trips");

            migrationBuilder.DropTable(
                name: "Mountains");

            migrationBuilder.DropIndex(
                name: "IX_Trips_MountainId",
                table: "Trips");

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: new Guid("6b0714fd-474c-4198-b98b-1254d65df1fe"));

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: new Guid("c9ac83be-b220-470f-aa32-3414cf67ab5a"));

            migrationBuilder.DropColumn(
                name: "MountainId",
                table: "Trips");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Trips",
                type: "nvarchar(3000)",
                maxLength: 3000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 8000);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Trips",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 23, 21, 59, 0, 293, DateTimeKind.Utc).AddTicks(7650),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 28, 22, 7, 27, 200, DateTimeKind.Utc).AddTicks(2728));

            migrationBuilder.AddColumn<string>(
                name: "Mountain",
                table: "Trips",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "CreatedOn", "Description", "GuideId", "Mountain", "PricePerPerson", "ReturnDate", "StartDate", "Title" },
                values: new object[] { new Guid("b3efbe07-8d1b-4408-a2b0-f9c9aa2dcb84"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Experience the awe-inspiring beauty of Bulgaria's Pirin Mountains on the Mount Vihren hike. Trek through pristine alpine landscapes, passing crystal-clear lakes and wildflower meadows. As you ascend towards the summit, be captivated by sweeping vistas of rugged peaks and glacial valleys below. A challenging yet rewarding adventure, perfect for hikers seeking breathtaking natural wonders in the heart of the Balkans.", new Guid("3352a20e-6fa8-43b3-a919-5bd557363f5a"), "Pirin", 15.00m, new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pesho's second created trip" });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "CreatedOn", "Description", "GuideId", "Mountain", "PricePerPerson", "ReturnDate", "StartDate", "Title" },
                values: new object[] { new Guid("e830e7bb-63b3-4d0f-a398-1e72f37bfd60"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Embark on a thrilling adventure in Bulgaria's majestic Stara Planina with the Mount Botev hike. Ascend through lush forests and rocky terrain to reach the summit, where breathtaking panoramic views await. Immerse yourself in the beauty of the Balkans and discover the intriguing legends surrounding this mystical peak. A memorable journey for nature enthusiasts and explorers alike.", new Guid("3352a20e-6fa8-43b3-a919-5bd557363f5a"), "Stara Planina", 10.00m, new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pesho's first created trip" });
        }
    }
}
