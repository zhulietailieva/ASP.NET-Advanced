﻿namespace TrailVenturesSystem.Web.Infrastructure.Extensions
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using System.Reflection;
    using TrailVenturesSystem.Data.Models;

    using static Common.GeneralApplicationConstants;

    public static class WebApplicationBuilderExtensions
    {
        /// <summary>
        /// This method registers all services wwith their interfaces and implementation of given assembly.
        /// The assembly is taken from the type of random service interface or implementation provided.
        /// </summary>
        /// <param name="serviceType">Type of random service implementation</param>
        /// <exception cref="InvalidOperationException"></exception>
        public static void AddApplicationServices(this IServiceCollection services,Type serviceType)
        {
            Assembly? serviceAssembly = Assembly.GetAssembly(serviceType);
            

            if (serviceAssembly == null)
            {
                throw new InvalidOperationException("Invalid service type provided!");
            }

            Type[] implementationTypes = serviceAssembly
                .GetTypes()
                .Where(t => t.Name.EndsWith("Service") && !t.IsInterface)
                .ToArray();

            foreach(Type implementationType in implementationTypes)
            {
                Type? interfaceType = implementationType
                    .GetInterface($"I{implementationType.Name}");

                if (interfaceType == null)
                {
                    throw new InvalidOperationException($"No interface is provided for the service with name: {implementationType.Name}");
                }
                services.AddScoped(interfaceType, implementationType);

            }
        }
        /// <summary>
        /// This method seeds admin role if it does not exist yet
        /// Passed email shoul be a valid email of existing user in the app.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public static IApplicationBuilder SeedAdministrator(this IApplicationBuilder app,string email)
        {
            //executes synchronously
            using IServiceScope scopedServices = app.ApplicationServices.CreateScope();

            IServiceProvider serviceProvider = scopedServices.ServiceProvider;

            //this action is similar to when we require service trough a ctor
            UserManager<ApplicationUser> userManager =
                serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            RoleManager<IdentityRole<Guid>> roleManager =
                serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

            ApplicationUser user = new ApplicationUser()
            {
                UserName = "admin@trailventures.bg",
                NormalizedUserName = "ADMIN@TRAILVENTURES.BG",
                Email = "admin@trailventures.bg",
                NormalizedEmail = "ADMIN@TRAILVENTURES.BG",
                EmailConfirmed = true,
                TwoFactorEnabled = false,
                FirstName = "Admin",
                LastName = "Admin"
            };

            var result = userManager.CreateAsync(user, "123456").Result;

            Task.Run(async () =>
            {
                if (await roleManager.RoleExistsAsync(AdminRoleName))
                {
                    //admin role already exists, no need for seeding
                    return;
                }

                IdentityRole<Guid> role = new IdentityRole<Guid>(AdminRoleName);

                await roleManager.CreateAsync(role);

                ApplicationUser adminUser =await userManager.FindByEmailAsync(email);

                await userManager.AddToRoleAsync(adminUser, AdminRoleName);
            }).GetAwaiter()
                .GetResult();

            return app;
        }
    }
}
