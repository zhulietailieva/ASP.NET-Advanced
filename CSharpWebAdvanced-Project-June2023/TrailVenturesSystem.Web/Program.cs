namespace TrailVenturesSystem.Web
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;
    using TrailVenturesSystem.Data;
    using TrailVenturesSystem.Data.Models;
    using TrailVenturesSystem.Services.Data.Interfaces;
    using TrailVenturesSystem.Services.Mapping;
    using TrailVenturesSystem.Web.Infrastructure.Extensions;
    using TrailVenturesSystem.Web.Infrastructure.ModelBinders;
    using TrailVenturesSystem.Web.ViewModels.Home;
    using static Common.GeneralApplicationConstants;

    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
          
            string  connectionString = 
                builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            
            builder.Services.AddDbContext<TrailVenturesDbContext>(options =>
                options.UseSqlServer(connectionString));           

            builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = 
                            builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");
                options.Password.RequireLowercase =
                            builder.Configuration.GetValue<bool>("Identity:Password:RequireLowercase");
                options.Password.RequireUppercase =
                            builder.Configuration.GetValue<bool>("Identity:Password:RequireUppercase");
                options.Password.RequireNonAlphanumeric=
                            builder.Configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");
                options.Password.RequiredLength =
                            builder.Configuration.GetValue<int>("Identity:Password:RequiredLength");
            }).AddRoles<IdentityRole<Guid>>()
                .AddEntityFrameworkStores<TrailVenturesDbContext>();

            builder.Services.AddApplicationServices(typeof(ITripService));

            builder.Services.AddRecaptchaService();

            builder.Services.AddMemoryCache();
            builder.Services.AddResponseCaching();

            //redirect to custom implemented login page
            builder.Services.ConfigureApplicationCookie(cfg =>
            {
                cfg.LoginPath = "/User/Login";
                cfg.AccessDeniedPath = "/Home/Error/401";
            });

            builder.Services
                .AddControllersWithViews()
                .AddMvcOptions(options =>
                {
                    options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
                    //commenting out because of the ajax testing that i want to try
                   // options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
                });


            WebApplication app = builder.Build();

            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);


            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error/500");
                app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");
               
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseResponseCaching();

            app.UseAuthentication();
            app.UseAuthorization();

            if (app.Environment.IsDevelopment())
            {
                app.SeedAdministrator(DevelopmentAdminEmail);
            }
          
            app.UseEndpoints(config =>
            {
                config.MapControllerRoute(
                    name: "areas",
                    pattern: "/{area:exists}/{controller=Home}/{action=Index}/{id?}");

                config.MapControllerRoute(
                    name: "ProtectingUrlRoute",
                    pattern: "/{controller}/{action}/{id}/{information}",
                    defaults: new {Controller="Mountain",Action="Details"});
             
                config.MapDefaultControllerRoute();
                config.MapRazorPages();
            });

            app.Run();
        }
    }
}