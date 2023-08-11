namespace TrailVenturesSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TrailVenturesSystem.Data.Models;
    public class HutEntityConfiguration : IEntityTypeConfiguration<Hut>
    {
        public void Configure(EntityTypeBuilder<Hut> builder)
        {
            builder
                .Property(h => h.IsActive)
                .HasDefaultValue(true);

            builder
                .HasOne(h => h.Mountain)
                .WithMany(m => m.Huts)
                .HasForeignKey(h => h.MountainId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(GenerateHuts());
        }

        private Hut[] GenerateHuts()
        {
            ICollection<Hut> huts = new HashSet<Hut>();

            Hut hut;

            hut = new Hut
            {
                Id=1,
                Name= "Mountain Paradise Hut",
                HostPhoneNumber= "+359888123456",
                PricePerNight=7 ,
                Altitude= 1500,
                MountainId=5 ,
            };

            huts.Add(hut);

            hut = new Hut
            {
                Id = 2,
                Name = "EcoHut Balkan",
                HostPhoneNumber = "+359877987654",
                PricePerNight =10 ,
                Altitude = 1800,
                MountainId =5 ,
            };

            huts.Add(hut);

            hut = new Hut
            {
                Id = 3,
                Name = "Alpine Retreat Hut",
                HostPhoneNumber = "+359878111222",
                PricePerNight =8 ,
                Altitude = 2000,
                MountainId = 2,
            };

            huts.Add(hut);

            hut = new Hut
            {
                Id = 4,
                Name = "Mountain Vista Hut",
                HostPhoneNumber = "+359889333444",
                PricePerNight = 12,
                Altitude = 2000,
                MountainId =2 ,
            };

            huts.Add(hut);

            hut = new Hut
            {
                Id = 5,
                Name = "Rila Peak Hut",
                HostPhoneNumber = "+359877555666",
                PricePerNight = 9,
                Altitude =2400 ,
                MountainId =1 ,
            };

            huts.Add(hut);

            hut = new Hut
            {
                Id = 6,
                Name = "Forest Haven Hut",
                HostPhoneNumber = "+359878777888",
                PricePerNight =10 ,
                Altitude = 1900,
                MountainId =1 ,
            };

            huts.Add(hut);

            return huts.ToArray();
        }
    }
}
