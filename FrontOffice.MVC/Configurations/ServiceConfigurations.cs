using BusinessLayer.Helpers;
using CommonLayer;
using DataLayer;
using DataLayer.Repositories;
using DataLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.Interfaces;
using ServiceLayer.Services;
using System.Net.Http;

namespace FrontOffice.MVC.Configurations
{
    public static class ServiceConfigurations
    {
        public static void AddAppServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region Database

            services.AddDbContextPool<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("CarService"), sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure();
                }));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IVehicleRepository), typeof(VehicleRepository));
            services.AddScoped(typeof(IUserRoleRepository), typeof(UserRoleRepository));

            #endregion

            #region Http Clients

            services.AddHttpClient(Constants.FetchDataHttpClientName).ConfigurePrimaryHttpMessageHandler(() =>
            {
                var handler = new HttpClientHandler();
                //handler.ClientCertificates.Add(CertificateHelper.LoadPrivateCertificate(
                //    Configuration.GetValue<string>("PhysicalPersonCertificatePath"),
                //    Configuration.GetValue<string>("PhysicalPersonCertificatePassword")));
                return handler;
            });

            #endregion

            #region Auth

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);

            #endregion

            #region Helpers

            services.AddScoped<UserHelper>();
            services.AddScoped<UserRoleHelper>();
            services.AddScoped<OrderHelper>();
            services.AddScoped<VehicleHelper>();

            #endregion

            #region Application Services

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRoleService, UserRoleService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IVehicleService, VehicleService>();

            #endregion

            services.AddControllersWithViews();
        }
    }
}
