﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrailVenturesSystem.Data.Migrations
{
    public partial class AddedHutsTableToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: new Guid("0b6ed284-ac40-43ee-81fc-680271a51709"));

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: new Guid("5ba5e650-86bc-45c4-986f-8e74e83662dc"));

            migrationBuilder.AddColumn<int>(
                name: "HutId",
                table: "Trips",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonalInfo",
                table: "AspNetUsers",
                type: "nvarchar(1500)",
                maxLength: 1500,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Huts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    HostPhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    PricePerNight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Altitude = table.Column<int>(type: "int", nullable: false),
                    MountainId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Huts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Huts_Mountains_MountainId",
                        column: x => x.MountainId,
                        principalTable: "Mountains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Huts",
                columns: new[] { "Id", "Altitude", "HostPhoneNumber", "MountainId", "Name", "PricePerNight" },
                values: new object[,]
                {
                    { 1, 1500, "+359888123456", 5, "Mountain Paradise Hut", 7m },
                    { 2, 1800, "+359877987654", 5, "EcoHut Balkan", 10m },
                    { 3, 2000, "+359878111222", 2, "Alpine Retreat Hut", 8m },
                    { 4, 12, "+359889333444", 2, "Mountain Vista Hut", 2200m },
                    { 5, 9, "+359877555666", 1, "Rila Peak Hut", 2400m },
                    { 6, 1900, "+359878777888", 1, "Forest Haven Hut", 10m }
                });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "Description", "GroupMaxSize", "GuideId", "HutId", "MountainId", "PricePerPerson", "ReturnDate", "StartDate", "Title" },
                values: new object[,]
                {
                    { new Guid("52cc6a72-9026-48b3-a0e8-822bc49420a4"), "Welcome to an unforgettable expedition to the breathtaking Mount Vihren, nestled in the pristine Pirin National Park of Bulgaria. This thrilling journey is set to commence on the morning of 29th March 2023, offering a unique opportunity to explore the awe-inspiring landscapes of Pirin, conquer the mighty Mount Vihren, and forge lifelong memories. So, gather your spirit of adventure, and let's embark on an extraordinary quest to reach the summit of Mount Vihren!\r\n\r\nMeeting Place:\r\nOur exhilarating adventure begins in the charming town of Bansko, located at the foothills of the Pirin Mountains. On 29th March 2023, at 9:00 AM, we will assemble at the Bansko Adventure Center, situated in the heart of the town. There, our experienced and knowledgeable guide, Elena, will welcome us warmly, introduce the itinerary, and conduct a safety briefing to ensure a smooth and secure journey to Mount Vihren.\r\n\r\nDuration of the Trip:\r\nThe expedition to Mount Vihren will span three days and two nights, providing ample time to savor the beauty of Pirin National Park and conquer the mighty summit. The itinerary has been thoughtfully crafted to accommodate adventurers of varying experience levels, promising a rewarding and memorable experience for all participants.\r\n\r\nWhat to Pack:\r\nPacking the right gear and essentials is crucial to ensure comfort, safety, and enjoyment during the journey. Here's a comprehensive list of items each participant should carry in their bags:\r\n\r\nBackpack: Choose a durable, comfortable backpack with sufficient capacity to carry your belongings throughout the trip.\r\n\r\nClothing:\r\n\r\nHiking Boots: Invest in sturdy, waterproof hiking boots with excellent ankle support to navigate the uneven terrain.\r\nMoisture-Wicking Layers: Pack lightweight, moisture-wicking shirts and pants to stay dry and comfortable during the trek.\r\nInsulating Layers: Bring a warm fleece or down jacket, as temperatures can vary, especially at higher altitudes.\r\nWaterproof Jacket and Pants: Prepare for unexpected weather changes with reliable waterproof outerwear.\r\nHat and Gloves: Shield yourself from the sun and cold with a wide-brimmed hat and insulated gloves.\r\nExtra Socks: Carry extra pairs of moisture-wicking socks to keep your feet dry and blister-free.\r\nSleeping Gear:\r\n\r\nSleeping Bag: Select a lightweight and compact sleeping bag suitable for the springtime temperatures in Pirin.\r\nCamping Gear:\r\n\r\nTent: If you prefer camping, a lightweight, weatherproof tent will provide a cozy shelter during the nights.\r\nHydration and Nutrition:\r\n\r\nWater: Bring a reusable water bottle or a hydration system to stay hydrated during the hike.\r\nSnacks: Pack energy-boosting snacks, such as granola bars, nuts, and dried fruits, to keep you energized on the trail.\r\nPersonal Essentials:\r\n\r\nPersonal Identification: Carry your identification documents in a secure pouch.\r\nFirst Aid Kit: Include band-aids, pain relievers, antiseptic wipes, and any personal medications you may need.\r\nSunscreen and Sunglasses: Protect your skin and eyes from the sun's rays at higher altitudes.\r\nClothing Tips:\r\nAs we venture into Pirin's wilderness, follow these clothing tips to ensure your comfort and safety:\r\n\r\nLayering: Dress in multiple layers, so you can adjust your clothing according to changing weather conditions.\r\n\r\nBreathable Fabrics: Choose moisture-wicking and breathable fabrics to stay comfortable during exertion.\r\n\r\nProper Footwear: Wear well-fitted, broken-in hiking boots to prevent blisters and ensure stability on uneven terrain.\r\n\r\nConservative Dress: Respect local customs and culture by dressing modestly when visiting villages or towns.", 5, new Guid("3352a20e-6fa8-43b3-a919-5bd557363f5a"), null, 2, 15.00m, new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vihren's Summit Serenade: A Tale of Triumph in Pirin's Pristine Wilderness" },
                    { new Guid("9f524405-48dd-4dee-baaf-c15dc9e2d90e"), "Welcome to an exhilarating journey of a lifetime as we embark on a challenging trek to conquer the majestic Mount Botev in the stunning Stara Planina mountain range of Bulgaria. This thrilling expedition is set to begin on the morning of 21st July 2023, promising an unforgettable experience for all participants. So, lace up your boots, pack your bags, and get ready for an adventure like no other!\r\n\r\nMeeting Place:\r\nOur exciting adventure will commence at the picturesque town of Kalofer, located in the foothills of Stara Planina. On the morning of 21st July 2023, at precisely 8:00 AM, we will gather at the town's central square, where our experienced guide, Dimitar, will introduce the itinerary and provide essential safety instructions. Kalofer's charm and warm hospitality make it an ideal starting point for our unforgettable journey to Mount Botev.\r\n\r\nDuration of the Trip:\r\nThe trek to Mount Botev will span over four days and three nights. Each day, we will conquer different segments of the trail, relishing the diverse beauty of Stara Planina and gradually making our way to the summit of Mount Botev. The journey is designed to challenge and inspire adventurers of all levels, making it a remarkable experience for everyone involved.\r\n\r\nWhat to Pack:\r\nPacking the right gear and essentials is crucial for a successful and comfortable trip. Here's a comprehensive list of items each participant should carry in their bags:\r\n\r\nBackpack: Choose a sturdy and comfortable backpack with enough capacity to hold your essentials for the entire journey.\r\n\r\nClothing: Pack lightweight, moisture-wicking shirts and pants suitable for trekking. Ensure you have a warm, waterproof jacket and thermal layers for the higher altitudes where the weather can be unpredictable.\r\n\r\nFootwear: Invest in a pair of reliable, well-fitted hiking boots with ankle support. Break them in before the trip to avoid blisters.\r\n\r\nRain Gear: Don't forget a reliable raincoat or a poncho to keep you dry in case of sudden showers.\r\n\r\nHeadwear: A wide-brimmed hat or a cap will protect you from the sun during the day, while a warm beanie will be essential for the chilly nights.\r\n\r\nGloves: Lightweight gloves are ideal for protecting your hands during the hike.\r\n\r\nSocks: Pack moisture-wicking, comfortable socks to prevent blisters.\r\n\r\nSleeping Bag: Bring a compact, lightweight sleeping bag suitable for summer temperatures.\r\n\r\nTent: If you prefer camping, a lightweight and waterproof tent will be essential.\r\n\r\nHydration System: Carry a refillable water bottle or a hydration pack to stay hydrated throughout the journey.\r\n\r\nSnacks and Food: Bring energy bars, trail mix, and other lightweight snacks to keep you energized during the hike. Our guide will also arrange for meals at designated spots.\r\n\r\nPersonal First Aid Kit: Include band-aids, pain relievers, and any personal medications you might need.\r\n\r\nSunscreen and Insect Repellent: Protect your skin from the sun's rays and insect bites.\r\n\r\nClothing Tips:\r\nAs we venture into the wilderness of Stara Planina, it's essential to follow these clothing tips to ensure comfort and safety:\r\n\r\nLayering: Dress in layers so you can add or remove clothing as the temperature changes.\r\n\r\nBreathable Fabrics: Opt for clothing made from breathable materials to stay comfortable during the hike.\r\n\r\nDrying Clothes: Bring extra plastic bags to store wet or dirty clothes separately from clean ones.\r\n\r\nConservative Dress: When visiting local villages or towns, please be respectful of the local culture and dress modestly.", 10, new Guid("3352a20e-6fa8-43b3-a919-5bd557363f5a"), null, 5, 10.00m, new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Botev's Quest: Conquering the Summit of Stara Planina" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trips_HutId",
                table: "Trips",
                column: "HutId");

            migrationBuilder.CreateIndex(
                name: "IX_Huts_MountainId",
                table: "Huts",
                column: "MountainId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Huts_HutId",
                table: "Trips",
                column: "HutId",
                principalTable: "Huts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Huts_HutId",
                table: "Trips");

            migrationBuilder.DropTable(
                name: "Huts");

            migrationBuilder.DropIndex(
                name: "IX_Trips_HutId",
                table: "Trips");

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: new Guid("52cc6a72-9026-48b3-a0e8-822bc49420a4"));

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: new Guid("9f524405-48dd-4dee-baaf-c15dc9e2d90e"));

            migrationBuilder.DropColumn(
                name: "HutId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "PersonalInfo",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "CreatedOn", "Description", "GroupMaxSize", "GuideId", "IsActive", "MountainId", "PricePerPerson", "ReturnDate", "StartDate", "Title" },
                values: new object[] { new Guid("0b6ed284-ac40-43ee-81fc-680271a51709"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Welcome to an exhilarating journey of a lifetime as we embark on a challenging trek to conquer the majestic Mount Botev in the stunning Stara Planina mountain range of Bulgaria. This thrilling expedition is set to begin on the morning of 21st July 2023, promising an unforgettable experience for all participants. So, lace up your boots, pack your bags, and get ready for an adventure like no other!\r\n\r\nMeeting Place:\r\nOur exciting adventure will commence at the picturesque town of Kalofer, located in the foothills of Stara Planina. On the morning of 21st July 2023, at precisely 8:00 AM, we will gather at the town's central square, where our experienced guide, Dimitar, will introduce the itinerary and provide essential safety instructions. Kalofer's charm and warm hospitality make it an ideal starting point for our unforgettable journey to Mount Botev.\r\n\r\nDuration of the Trip:\r\nThe trek to Mount Botev will span over four days and three nights. Each day, we will conquer different segments of the trail, relishing the diverse beauty of Stara Planina and gradually making our way to the summit of Mount Botev. The journey is designed to challenge and inspire adventurers of all levels, making it a remarkable experience for everyone involved.\r\n\r\nWhat to Pack:\r\nPacking the right gear and essentials is crucial for a successful and comfortable trip. Here's a comprehensive list of items each participant should carry in their bags:\r\n\r\nBackpack: Choose a sturdy and comfortable backpack with enough capacity to hold your essentials for the entire journey.\r\n\r\nClothing: Pack lightweight, moisture-wicking shirts and pants suitable for trekking. Ensure you have a warm, waterproof jacket and thermal layers for the higher altitudes where the weather can be unpredictable.\r\n\r\nFootwear: Invest in a pair of reliable, well-fitted hiking boots with ankle support. Break them in before the trip to avoid blisters.\r\n\r\nRain Gear: Don't forget a reliable raincoat or a poncho to keep you dry in case of sudden showers.\r\n\r\nHeadwear: A wide-brimmed hat or a cap will protect you from the sun during the day, while a warm beanie will be essential for the chilly nights.\r\n\r\nGloves: Lightweight gloves are ideal for protecting your hands during the hike.\r\n\r\nSocks: Pack moisture-wicking, comfortable socks to prevent blisters.\r\n\r\nSleeping Bag: Bring a compact, lightweight sleeping bag suitable for summer temperatures.\r\n\r\nTent: If you prefer camping, a lightweight and waterproof tent will be essential.\r\n\r\nHydration System: Carry a refillable water bottle or a hydration pack to stay hydrated throughout the journey.\r\n\r\nSnacks and Food: Bring energy bars, trail mix, and other lightweight snacks to keep you energized during the hike. Our guide will also arrange for meals at designated spots.\r\n\r\nPersonal First Aid Kit: Include band-aids, pain relievers, and any personal medications you might need.\r\n\r\nSunscreen and Insect Repellent: Protect your skin from the sun's rays and insect bites.\r\n\r\nClothing Tips:\r\nAs we venture into the wilderness of Stara Planina, it's essential to follow these clothing tips to ensure comfort and safety:\r\n\r\nLayering: Dress in layers so you can add or remove clothing as the temperature changes.\r\n\r\nBreathable Fabrics: Opt for clothing made from breathable materials to stay comfortable during the hike.\r\n\r\nDrying Clothes: Bring extra plastic bags to store wet or dirty clothes separately from clean ones.\r\n\r\nConservative Dress: When visiting local villages or towns, please be respectful of the local culture and dress modestly.", 10, new Guid("3352a20e-6fa8-43b3-a919-5bd557363f5a"), false, 5, 10.00m, new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Botev's Quest: Conquering the Summit of Stara Planina" });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "CreatedOn", "Description", "GroupMaxSize", "GuideId", "IsActive", "MountainId", "PricePerPerson", "ReturnDate", "StartDate", "Title" },
                values: new object[] { new Guid("5ba5e650-86bc-45c4-986f-8e74e83662dc"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Welcome to an unforgettable expedition to the breathtaking Mount Vihren, nestled in the pristine Pirin National Park of Bulgaria. This thrilling journey is set to commence on the morning of 29th March 2023, offering a unique opportunity to explore the awe-inspiring landscapes of Pirin, conquer the mighty Mount Vihren, and forge lifelong memories. So, gather your spirit of adventure, and let's embark on an extraordinary quest to reach the summit of Mount Vihren!\r\n\r\nMeeting Place:\r\nOur exhilarating adventure begins in the charming town of Bansko, located at the foothills of the Pirin Mountains. On 29th March 2023, at 9:00 AM, we will assemble at the Bansko Adventure Center, situated in the heart of the town. There, our experienced and knowledgeable guide, Elena, will welcome us warmly, introduce the itinerary, and conduct a safety briefing to ensure a smooth and secure journey to Mount Vihren.\r\n\r\nDuration of the Trip:\r\nThe expedition to Mount Vihren will span three days and two nights, providing ample time to savor the beauty of Pirin National Park and conquer the mighty summit. The itinerary has been thoughtfully crafted to accommodate adventurers of varying experience levels, promising a rewarding and memorable experience for all participants.\r\n\r\nWhat to Pack:\r\nPacking the right gear and essentials is crucial to ensure comfort, safety, and enjoyment during the journey. Here's a comprehensive list of items each participant should carry in their bags:\r\n\r\nBackpack: Choose a durable, comfortable backpack with sufficient capacity to carry your belongings throughout the trip.\r\n\r\nClothing:\r\n\r\nHiking Boots: Invest in sturdy, waterproof hiking boots with excellent ankle support to navigate the uneven terrain.\r\nMoisture-Wicking Layers: Pack lightweight, moisture-wicking shirts and pants to stay dry and comfortable during the trek.\r\nInsulating Layers: Bring a warm fleece or down jacket, as temperatures can vary, especially at higher altitudes.\r\nWaterproof Jacket and Pants: Prepare for unexpected weather changes with reliable waterproof outerwear.\r\nHat and Gloves: Shield yourself from the sun and cold with a wide-brimmed hat and insulated gloves.\r\nExtra Socks: Carry extra pairs of moisture-wicking socks to keep your feet dry and blister-free.\r\nSleeping Gear:\r\n\r\nSleeping Bag: Select a lightweight and compact sleeping bag suitable for the springtime temperatures in Pirin.\r\nCamping Gear:\r\n\r\nTent: If you prefer camping, a lightweight, weatherproof tent will provide a cozy shelter during the nights.\r\nHydration and Nutrition:\r\n\r\nWater: Bring a reusable water bottle or a hydration system to stay hydrated during the hike.\r\nSnacks: Pack energy-boosting snacks, such as granola bars, nuts, and dried fruits, to keep you energized on the trail.\r\nPersonal Essentials:\r\n\r\nPersonal Identification: Carry your identification documents in a secure pouch.\r\nFirst Aid Kit: Include band-aids, pain relievers, antiseptic wipes, and any personal medications you may need.\r\nSunscreen and Sunglasses: Protect your skin and eyes from the sun's rays at higher altitudes.\r\nClothing Tips:\r\nAs we venture into Pirin's wilderness, follow these clothing tips to ensure your comfort and safety:\r\n\r\nLayering: Dress in multiple layers, so you can adjust your clothing according to changing weather conditions.\r\n\r\nBreathable Fabrics: Choose moisture-wicking and breathable fabrics to stay comfortable during exertion.\r\n\r\nProper Footwear: Wear well-fitted, broken-in hiking boots to prevent blisters and ensure stability on uneven terrain.\r\n\r\nConservative Dress: Respect local customs and culture by dressing modestly when visiting villages or towns.", 5, new Guid("3352a20e-6fa8-43b3-a919-5bd557363f5a"), false, 2, 15.00m, new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vihren's Summit Serenade: A Tale of Triumph in Pirin's Pristine Wilderness" });
        }
    }
}
