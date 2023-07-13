using DevExpress.DashboardWeb;

namespace AspNetCoreDashboard.Storages {
    public class CustomDashboardFileStorage : DashboardFileStorage {
        public CustomDashboardFileStorage(string workingDirectory)
            : base(workingDirectory) {
        }

        public void DeleteDashboard(string dashboardID) {
            var dashboardPath = base.ResolveFileName(dashboardID);
            if (File.Exists(dashboardPath))
                File.Delete(dashboardPath);
        }
    }
}

