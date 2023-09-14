using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VehicleDashboard.Controllers
{
    public class UsedController : Controller
    {
        // GET: Used
        public ActionResult Index(string Location)
        {
            var usedVehicleDashboard = new Models.UsedVehicleDashboard();

            if(Location == null)
            {
                Location = "ALL";
            }

            usedVehicleDashboard.AllUsedInventory = Business.SqlQueries.GetAllUsedInventory();
            usedVehicleDashboard.WebsiteUsedInventory = Business.SqlQueries.GetWebsiteUsedInventory();
            usedVehicleDashboard.Location = Location;
            usedVehicleDashboard.Photos = Business.SqlQueries.GetPhotoNumberByVIN_USED();
            return View(usedVehicleDashboard);
        }
    }
}