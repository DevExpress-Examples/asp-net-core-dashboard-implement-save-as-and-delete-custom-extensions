using AspNetCoreDashboard.Storages;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreDashboard.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }
        public ActionResult DeleteDashboard(string DashboardID) {
            CustomDashboardFileStorage newDashboardStorage = new CustomDashboardFileStorage(@"Data/Dashboards");
            newDashboardStorage.DeleteDashboard(DashboardID);
            return new EmptyResult();
        }
    }
}
