﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrailVenturesSystem.Data.Migrations
{
    public partial class AddCreatedOnColumnToTrip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: new Guid("0d9f4cdf-2ff2-4efa-abb1-248455241931"));

            migrationBuilder.DeleteData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: new Guid("b188dcce-3377-4283-8522-a3394f021e65"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Trips",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 23, 21, 59, 0, 293, DateTimeKind.Utc).AddTicks(7650));

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "Description", "GuideId", "Mountain", "PricePerPerson", "ReturnDate", "StartDate", "Title" },
                values: new object[] { new Guid("b3efbe07-8d1b-4408-a2b0-f9c9aa2dcb84"), "Experience the awe-inspiring beauty of Bulgaria's Pirin Mountains on the Mount Vihren hike. Trek through pristine alpine landscapes, passing crystal-clear lakes and wildflower meadows. As you ascend towards the summit, be captivated by sweeping vistas of rugged peaks and glacial valleys below. A challenging yet rewarding adventure, perfect for hikers seeking breathtaking natural wonders in the heart of the Balkans.", new Guid("3352a20e-6fa8-43b3-a919-5bd557363f5a"), "Pirin", 15.00m, new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pesho's second created trip" });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "Description", "GuideId", "Mountain", "PricePerPerson", "ReturnDate", "StartDate", "Title" },
                values: new object[] { new Guid("e830e7bb-63b3-4d0f-a398-1e72f37bfd60"), "Embark on a thrilling adventure in Bulgaria's majestic Stara Planina with the Mount Botev hike. Ascend through lush forests and rocky terrain to reach the summit, where breathtaking panoramic views await. Immerse yourself in the beauty of the Balkans and discover the intriguing legends surrounding this mystical peak. A memorable journey for nature enthusiasts and explorers alike.", new Guid("3352a20e-6fa8-43b3-a919-5bd557363f5a"), "Stara Planina", 10.00m, new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pesho's first created trip" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "CreatedOn",
                table: "Trips");

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "Description", "GuideId", "Mountain", "PricePerPerson", "ReturnDate", "StartDate", "Title" },
                values: new object[] { new Guid("0d9f4cdf-2ff2-4efa-abb1-248455241931"), "Embark on a thrilling adventure in Bulgaria's majestic Stara Planina with the Mount Botev hike. Ascend through lush forests and rocky terrain to reach the summit, where breathtaking panoramic views await. Immerse yourself in the beauty of the Balkans and discover the intriguing legends surrounding this mystical peak. A memorable journey for nature enthusiasts and explorers alike.", new Guid("3352a20e-6fa8-43b3-a919-5bd557363f5a"), "Stara Planina", 10.00m, new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pesho's first created trip" });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "Description", "GuideId", "Mountain", "PricePerPerson", "ReturnDate", "StartDate", "Title" },
                values: new object[] { new Guid("b188dcce-3377-4283-8522-a3394f021e65"), "Experience the awe-inspiring beauty of Bulgaria's Pirin Mountains on the Mount Vihren hike. Trek through pristine alpine landscapes, passing crystal-clear lakes and wildflower meadows. As you ascend towards the summit, be captivated by sweeping vistas of rugged peaks and glacial valleys below. A challenging yet rewarding adventure, perfect for hikers seeking breathtaking natural wonders in the heart of the Balkans.", new Guid("3352a20e-6fa8-43b3-a919-5bd557363f5a"), "Pirin", 15.00m, new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pesho's second created trip" });
        }
    }
}
