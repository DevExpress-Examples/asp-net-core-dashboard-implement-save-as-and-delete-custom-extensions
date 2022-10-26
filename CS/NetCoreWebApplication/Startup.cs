using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DevExpress.DashboardAspNetCore;
using DevExpress.DashboardWeb;
using DevExpress.AspNetCore;
using DevExpress.DashboardCommon;
using System.Data;
using System;
using NetCoreWebApplication.Storages;

namespace NetCoreWebApplication {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) {
            // Add a DashboardController class descendant with a specified dashboard storage 
            // and a connection string provider. 
            services
                .AddDevExpressControls()
                .AddMvc();
            services.AddScoped<DashboardConfigurator>((IServiceProvider serviceProvider) => {
                DashboardConfigurator configurator = new DashboardConfigurator();
                configurator.SetDashboardStorage(new CustomDashboardFileStorage("App_Data\\Dashboards"));
                configurator.SetConnectionStringsProvider(new DashboardConnectionStringsProvider(Configuration));
                return configurator;
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            // Register the DevExpress middleware.
            app.UseDevExpressControls();
            app.UseMvc(routes => {
                // Map dashboard routes.
                routes.MapDashboardRoute("api/dashboard", "DefaultDashboard");
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

