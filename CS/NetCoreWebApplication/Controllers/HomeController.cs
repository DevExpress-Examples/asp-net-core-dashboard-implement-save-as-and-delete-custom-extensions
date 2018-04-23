using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreWebApplication.Models;
using NetCoreWebApplication.Storages;

namespace NetCoreWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult DeleteDashboard(string DashboardID) {
            CustomDashboardFileStorage newDashboardStorage = new CustomDashboardFileStorage("App_Data\\Dashboards");
            newDashboardStorage.DeleteDashboard(DashboardID);
            return new EmptyResult();
        }
    }
}
