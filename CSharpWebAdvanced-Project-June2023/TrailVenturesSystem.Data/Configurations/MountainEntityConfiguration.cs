namespace TrailVenturesSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TrailVenturesSystem.Data.Models;

    public class MountainEntityConfiguration : IEntityTypeConfiguration<Mountain>
    {
        public void Configure(EntityTypeBuilder<Mountain> builder)
        {
            builder.HasData(GenerateMountains());
        }

        private Mountain[] GenerateMountains()
        {
            ICollection<Mountain> mountains = new HashSet<Mountain>();

            Mountain mountain;

            mountain = new Mountain
            {
                Id = 1,
                Name= "Rila"
            };

            mountains.Add(mountain);

            mountain = new Mountain
            {
                Id = 2,
                Name = "Pirin"
            };

            mountains.Add(mountain);

            mountain = new Mountain
            {
                Id = 3,
                Name = "Vitosha"
            };

            mountains.Add(mountain);

            mountain = new Mountain
            {
                Id = 4,
                Name = "Rhodope Mountains"
            };

            mountains.Add(mountain);

            mountain = new Mountain
            {
                Id = 5,
                Name = "Balkan Mountains"
            };

            mountains.Add(mountain);

            mountain = new Mountain
            {
                Id = 6,
                Name = "Strandzha"
            };

            mountains.Add(mountain);

            mountain = new Mountain
            {
                Id = 7,
                Name = "Osogovo"
            };

            mountains.Add(mountain);

            mountain = new Mountain
            {
                Id = 8,
                Name = "Sredna Gora"
            };

            mountains.Add(mountain);

            mountain = new Mountain
            {
                Id = 9,
                Name = "Slavyanka"
            };

            mountains.Add(mountain);

            mountain = new Mountain
            {
                Id = 10,
                Name = "Belasitsa"
            };

            mountains.Add(mountain);

            return mountains.ToArray();

        }
    }
}
