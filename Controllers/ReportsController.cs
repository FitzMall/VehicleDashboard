using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VehicleDashboard.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult InRecon(string Location)
        {
            var usedVehicleDashboard = new Models.UsedVehicleDashboard();

            if (Location == null)
            {
                Location = "ALL";
            }

            usedVehicleDashboard.AllUsedInventory = Business.SqlQueries.GetAllUsedInventory();
            usedVehicleDashboard.WebsiteUsedInventory = Business.SqlQueries.GetWebsiteUsedInventory();
            usedVehicleDashboard.Location = Location;

            return View(usedVehicleDashboard);
        }
    }
}