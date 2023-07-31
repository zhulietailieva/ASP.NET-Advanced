﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrailVenturesSystem.Data;

#nullable disable

namespace TrailVenturesSystem.Data.Migrations
{
    [DbContext(typeof(TrailVenturesDbContext))]
    partial class TrailVenturesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ApplicationUserTrip", b =>
                {
                    b.Property<Guid>("EnrolledTripsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("HikersId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("EnrolledTripsId", "HikersId");

                    b.HasIndex("HikersId");

                    b.ToTable("ApplicationUserTrip");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("TrailVenturesSystem.Data.Models.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasDefaultValue("Test");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasDefaultValue("Testov");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("TrailVenturesSystem.Data.Models.Guide", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("YearsOfExperience")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Guides");
                });

            modelBuilder.Entity("TrailVenturesSystem.Data.Models.Mountain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Mountains");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Rila"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Pirin"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Vitosha"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Rhodope Mountains"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Balkan Mountains"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Strandzha"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Osogovo"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Sredna Gora"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Slavyanka"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Belasitsa"
                        });
                });

            modelBuilder.Entity("TrailVenturesSystem.Data.Models.Trip", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(8000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GroupMaxSize")
                        .HasColumnType("int");

                    b.Property<Guid>("GuideId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int>("MountainId")
                        .HasColumnType("int");

                    b.Property<decimal>("PricePerPerson")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("GuideId");

                    b.HasIndex("MountainId");

                    b.ToTable("Trips");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0b6ed284-ac40-43ee-81fc-680271a51709"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Welcome to an exhilarating journey of a lifetime as we embark on a challenging trek to conquer the majestic Mount Botev in the stunning Stara Planina mountain range of Bulgaria. This thrilling expedition is set to begin on the morning of 21st July 2023, promising an unforgettable experience for all participants. So, lace up your boots, pack your bags, and get ready for an adventure like no other!\r\n\r\nMeeting Place:\r\nOur exciting adventure will commence at the picturesque town of Kalofer, located in the foothills of Stara Planina. On the morning of 21st July 2023, at precisely 8:00 AM, we will gather at the town's central square, where our experienced guide, Dimitar, will introduce the itinerary and provide essential safety instructions. Kalofer's charm and warm hospitality make it an ideal starting point for our unforgettable journey to Mount Botev.\r\n\r\nDuration of the Trip:\r\nThe trek to Mount Botev will span over four days and three nights. Each day, we will conquer different segments of the trail, relishing the diverse beauty of Stara Planina and gradually making our way to the summit of Mount Botev. The journey is designed to challenge and inspire adventurers of all levels, making it a remarkable experience for everyone involved.\r\n\r\nWhat to Pack:\r\nPacking the right gear and essentials is crucial for a successful and comfortable trip. Here's a comprehensive list of items each participant should carry in their bags:\r\n\r\nBackpack: Choose a sturdy and comfortable backpack with enough capacity to hold your essentials for the entire journey.\r\n\r\nClothing: Pack lightweight, moisture-wicking shirts and pants suitable for trekking. Ensure you have a warm, waterproof jacket and thermal layers for the higher altitudes where the weather can be unpredictable.\r\n\r\nFootwear: Invest in a pair of reliable, well-fitted hiking boots with ankle support. Break them in before the trip to avoid blisters.\r\n\r\nRain Gear: Don't forget a reliable raincoat or a poncho to keep you dry in case of sudden showers.\r\n\r\nHeadwear: A wide-brimmed hat or a cap will protect you from the sun during the day, while a warm beanie will be essential for the chilly nights.\r\n\r\nGloves: Lightweight gloves are ideal for protecting your hands during the hike.\r\n\r\nSocks: Pack moisture-wicking, comfortable socks to prevent blisters.\r\n\r\nSleeping Bag: Bring a compact, lightweight sleeping bag suitable for summer temperatures.\r\n\r\nTent: If you prefer camping, a lightweight and waterproof tent will be essential.\r\n\r\nHydration System: Carry a refillable water bottle or a hydration pack to stay hydrated throughout the journey.\r\n\r\nSnacks and Food: Bring energy bars, trail mix, and other lightweight snacks to keep you energized during the hike. Our guide will also arrange for meals at designated spots.\r\n\r\nPersonal First Aid Kit: Include band-aids, pain relievers, and any personal medications you might need.\r\n\r\nSunscreen and Insect Repellent: Protect your skin from the sun's rays and insect bites.\r\n\r\nClothing Tips:\r\nAs we venture into the wilderness of Stara Planina, it's essential to follow these clothing tips to ensure comfort and safety:\r\n\r\nLayering: Dress in layers so you can add or remove clothing as the temperature changes.\r\n\r\nBreathable Fabrics: Opt for clothing made from breathable materials to stay comfortable during the hike.\r\n\r\nDrying Clothes: Bring extra plastic bags to store wet or dirty clothes separately from clean ones.\r\n\r\nConservative Dress: When visiting local villages or towns, please be respectful of the local culture and dress modestly.",
                            GroupMaxSize = 10,
                            GuideId = new Guid("3352a20e-6fa8-43b3-a919-5bd557363f5a"),
                            IsActive = false,
                            MountainId = 5,
                            PricePerPerson = 10.00m,
                            ReturnDate = new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Botev's Quest: Conquering the Summit of Stara Planina"
                        },
                        new
                        {
                            Id = new Guid("5ba5e650-86bc-45c4-986f-8e74e83662dc"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Welcome to an unforgettable expedition to the breathtaking Mount Vihren, nestled in the pristine Pirin National Park of Bulgaria. This thrilling journey is set to commence on the morning of 29th March 2023, offering a unique opportunity to explore the awe-inspiring landscapes of Pirin, conquer the mighty Mount Vihren, and forge lifelong memories. So, gather your spirit of adventure, and let's embark on an extraordinary quest to reach the summit of Mount Vihren!\r\n\r\nMeeting Place:\r\nOur exhilarating adventure begins in the charming town of Bansko, located at the foothills of the Pirin Mountains. On 29th March 2023, at 9:00 AM, we will assemble at the Bansko Adventure Center, situated in the heart of the town. There, our experienced and knowledgeable guide, Elena, will welcome us warmly, introduce the itinerary, and conduct a safety briefing to ensure a smooth and secure journey to Mount Vihren.\r\n\r\nDuration of the Trip:\r\nThe expedition to Mount Vihren will span three days and two nights, providing ample time to savor the beauty of Pirin National Park and conquer the mighty summit. The itinerary has been thoughtfully crafted to accommodate adventurers of varying experience levels, promising a rewarding and memorable experience for all participants.\r\n\r\nWhat to Pack:\r\nPacking the right gear and essentials is crucial to ensure comfort, safety, and enjoyment during the journey. Here's a comprehensive list of items each participant should carry in their bags:\r\n\r\nBackpack: Choose a durable, comfortable backpack with sufficient capacity to carry your belongings throughout the trip.\r\n\r\nClothing:\r\n\r\nHiking Boots: Invest in sturdy, waterproof hiking boots with excellent ankle support to navigate the uneven terrain.\r\nMoisture-Wicking Layers: Pack lightweight, moisture-wicking shirts and pants to stay dry and comfortable during the trek.\r\nInsulating Layers: Bring a warm fleece or down jacket, as temperatures can vary, especially at higher altitudes.\r\nWaterproof Jacket and Pants: Prepare for unexpected weather changes with reliable waterproof outerwear.\r\nHat and Gloves: Shield yourself from the sun and cold with a wide-brimmed hat and insulated gloves.\r\nExtra Socks: Carry extra pairs of moisture-wicking socks to keep your feet dry and blister-free.\r\nSleeping Gear:\r\n\r\nSleeping Bag: Select a lightweight and compact sleeping bag suitable for the springtime temperatures in Pirin.\r\nCamping Gear:\r\n\r\nTent: If you prefer camping, a lightweight, weatherproof tent will provide a cozy shelter during the nights.\r\nHydration and Nutrition:\r\n\r\nWater: Bring a reusable water bottle or a hydration system to stay hydrated during the hike.\r\nSnacks: Pack energy-boosting snacks, such as granola bars, nuts, and dried fruits, to keep you energized on the trail.\r\nPersonal Essentials:\r\n\r\nPersonal Identification: Carry your identification documents in a secure pouch.\r\nFirst Aid Kit: Include band-aids, pain relievers, antiseptic wipes, and any personal medications you may need.\r\nSunscreen and Sunglasses: Protect your skin and eyes from the sun's rays at higher altitudes.\r\nClothing Tips:\r\nAs we venture into Pirin's wilderness, follow these clothing tips to ensure your comfort and safety:\r\n\r\nLayering: Dress in multiple layers, so you can adjust your clothing according to changing weather conditions.\r\n\r\nBreathable Fabrics: Choose moisture-wicking and breathable fabrics to stay comfortable during exertion.\r\n\r\nProper Footwear: Wear well-fitted, broken-in hiking boots to prevent blisters and ensure stability on uneven terrain.\r\n\r\nConservative Dress: Respect local customs and culture by dressing modestly when visiting villages or towns.",
                            GroupMaxSize = 5,
                            GuideId = new Guid("3352a20e-6fa8-43b3-a919-5bd557363f5a"),
                            IsActive = false,
                            MountainId = 2,
                            PricePerPerson = 15.00m,
                            ReturnDate = new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Vihren's Summit Serenade: A Tale of Triumph in Pirin's Pristine Wilderness"
                        });
                });

            modelBuilder.Entity("ApplicationUserTrip", b =>
                {
                    b.HasOne("TrailVenturesSystem.Data.Models.Trip", null)
                        .WithMany()
                        .HasForeignKey("EnrolledTripsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrailVenturesSystem.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("HikersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("TrailVenturesSystem.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("TrailVenturesSystem.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrailVenturesSystem.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("TrailVenturesSystem.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TrailVenturesSystem.Data.Models.Guide", b =>
                {
                    b.HasOne("TrailVenturesSystem.Data.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TrailVenturesSystem.Data.Models.Trip", b =>
                {
                    b.HasOne("TrailVenturesSystem.Data.Models.Guide", "Guide")
                        .WithMany("CreatedTrips")
                        .HasForeignKey("GuideId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TrailVenturesSystem.Data.Models.Mountain", "Mountain")
                        .WithMany("Trips")
                        .HasForeignKey("MountainId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Guide");

                    b.Navigation("Mountain");
                });

            modelBuilder.Entity("TrailVenturesSystem.Data.Models.Guide", b =>
                {
                    b.Navigation("CreatedTrips");
                });

            modelBuilder.Entity("TrailVenturesSystem.Data.Models.Mountain", b =>
                {
                    b.Navigation("Trips");
                });
#pragma warning restore 612, 618
        }
    }
}
