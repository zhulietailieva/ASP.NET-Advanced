namespace TrailVenturesSystem.WebApi
{
    using Microsoft.EntityFrameworkCore;
    using TrailVenturesSystem.Data;
    using TrailVenturesSystem.Services.Data;
    using TrailVenturesSystem.Services.Data.Interfaces;
    using TrailVenturesSystem.Web.Infrastructure.Extensions;

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            // Add services to the container.
            builder.Services.AddDbContext<TrailVenturesDbContext>(opt =>
            opt.UseSqlServer(connectionString));

            //builder.Services.AddTransient<ITripService, TripService>();
            
            builder.Services.AddApplicationServices(typeof(ITripService));

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(setup =>
            {
                setup.AddPolicy("TrailVenturesSystem", policyBuilder =>
                {
                    policyBuilder.WithOrigins("https://localhost:7022")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.UseCors("TrailVenturesSystem");

            app.Run();
        }
    }
}