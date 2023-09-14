using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VehicleDashboard.Controllers
{
    public class NewController : Controller
    {
        // GET: New
        public ActionResult Index(string Location)
        {
            var newVehicleDashboard = new Models.NewVehicleDashboard();

            if (Location == null)
            {
                Location = "ALL";
            }

            newVehicleDashboard.AllNewInventory = Business.SqlQueries.GetAllNewInventory();
            newVehicleDashboard.WebsiteNewInventory = Business.SqlQueries.GetWebsiteNewInventory();
            newVehicleDashboard.Location = Location;
            newVehicleDashboard.Photos = Business.SqlQueries.GetPhotoNumberByVIN_NEW();

            return View(newVehicleDashboard);
        }
    }
}