using DevExpress.DashboardAspNetCore;
using DevExpress.DashboardWeb;
using Microsoft.Extensions.FileProviders;
using AspNetCoreDashboard.Storages;

namespace AspNetCoreDashboard {
    public static class DashboardUtils {
        public static DashboardConfigurator CreateDashboardConfigurator(IConfiguration configuration, IFileProvider fileProvider) {
            DashboardConfigurator configurator = new DashboardConfigurator();
            configurator.SetConnectionStringsProvider(new DashboardConnectionStringsProvider(configuration));

            DashboardFileStorage dashboardFileStorage = new CustomDashboardFileStorage(@"Data/Dashboards");
            configurator.SetDashboardStorage(dashboardFileStorage);
            
            return configurator;
        }
    }
}