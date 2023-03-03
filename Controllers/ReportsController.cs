using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VehicleDashboard.Models;

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
            usedVehicleDashboard.VehicleData = Business.SqlQueries.GetAllChromedVehicles();


            return View(usedVehicleDashboard);
        }

        public ActionResult ManagerSpecials(string Location, string Condition)
        {
            var vehicleOptionModel = new VehicleOptionModel();

            if (Location == null || Location == "")
            {
                Location = "ALL";
            }

            if (Condition == null || Condition == "")
            {
                Condition = "ALL";
            }

            vehicleOptionModel.UsedVehicleDashboard = new UsedVehicleDashboard();
            vehicleOptionModel.UsedVehicleDashboard.AllUsedInventory = Business.SqlQueries.GetAllUsedInventory();
            vehicleOptionModel.UsedVehicleDashboard.WebsiteUsedInventory = Business.SqlQueries.GetWebsiteUsedInventory();

            vehicleOptionModel.NewVehicleDashboard = new NewVehicleDashboard();
            vehicleOptionModel.NewVehicleDashboard.AllNewInventory = Business.SqlQueries.GetAllNewInventory();
            vehicleOptionModel.NewVehicleDashboard.WebsiteNewInventory = Business.SqlQueries.GetWebsiteNewInventory();

            vehicleOptionModel.Location = Location;
            vehicleOptionModel.Condition = Condition;
            vehicleOptionModel.VehicleData = Business.SqlQueries.GetAllChromedVehicles();

            return View(vehicleOptionModel);
        }

        public ActionResult AllVehicles(string Location, string Condition)
        {
            var vehicleOptionModel = new VehicleOptionModel();

            if (Location == null || Location == "")
            {
                Location = "ALL";
            }

            if (Condition == null || Condition == "")
            {
                Condition = "ALL";
            }

            vehicleOptionModel.UsedVehicleDashboard = new UsedVehicleDashboard();
            vehicleOptionModel.UsedVehicleDashboard.AllUsedInventory = Business.SqlQueries.GetAllUsedInventory();
            vehicleOptionModel.UsedVehicleDashboard.WebsiteUsedInventory = Business.SqlQueries.GetWebsiteUsedInventory();

            vehicleOptionModel.NewVehicleDashboard = new NewVehicleDashboard();
            vehicleOptionModel.NewVehicleDashboard.AllNewInventory = Business.SqlQueries.GetAllNewInventory();
            vehicleOptionModel.NewVehicleDashboard.WebsiteNewInventory = Business.SqlQueries.GetWebsiteNewInventory();

            vehicleOptionModel.Location = Location;
            vehicleOptionModel.Condition = Condition;
            vehicleOptionModel.VehicleData = Business.SqlQueries.GetAllChromedVehicles();

            return View(vehicleOptionModel);
        }

        public ActionResult ShouldBeOnFitzMall(string Location, string Condition)
        {
            var vehicleOptionModel = new VehicleOptionModel();

            if (Location == null || Location == "")
            {
                Location = "ALL";
            }

            if (Condition == null || Condition == "")
            {
                Condition = "ALL";
            }

            vehicleOptionModel.UsedVehicleDashboard = new UsedVehicleDashboard();
            vehicleOptionModel.UsedVehicleDashboard.AllUsedInventory = Business.SqlQueries.GetAllUsedInventory();
            vehicleOptionModel.UsedVehicleDashboard.WebsiteUsedInventory = Business.SqlQueries.GetWebsiteUsedInventory();

            vehicleOptionModel.NewVehicleDashboard = new NewVehicleDashboard();
            vehicleOptionModel.NewVehicleDashboard.AllNewInventory = Business.SqlQueries.GetAllNewInventory();
            vehicleOptionModel.NewVehicleDashboard.WebsiteNewInventory = Business.SqlQueries.GetWebsiteNewInventory();

            vehicleOptionModel.Location = Location;
            vehicleOptionModel.Condition = Condition;
            vehicleOptionModel.VehicleData = Business.SqlQueries.GetAllChromedVehicles();

            return View(vehicleOptionModel);
        }


        public ActionResult NotChromed(string Location, string Condition)
        {
            var vehicleOptionModel = new VehicleOptionModel();

            if (Location == null || Location == "")
            {
                Location = "ALL";
            }

            if (Condition == null || Condition == "")
            {
                Condition = "ALL";
            }

            vehicleOptionModel.UsedVehicleDashboard = new UsedVehicleDashboard();
            vehicleOptionModel.UsedVehicleDashboard.AllUsedInventory = Business.SqlQueries.GetAllUsedInventory();
            vehicleOptionModel.UsedVehicleDashboard.WebsiteUsedInventory = Business.SqlQueries.GetWebsiteUsedInventory();

            vehicleOptionModel.NewVehicleDashboard = new NewVehicleDashboard();
            vehicleOptionModel.NewVehicleDashboard.AllNewInventory = Business.SqlQueries.GetAllNewInventory();
            vehicleOptionModel.NewVehicleDashboard.WebsiteNewInventory = Business.SqlQueries.GetWebsiteNewInventory();

            vehicleOptionModel.Location = Location;
            vehicleOptionModel.Condition = Condition;
            vehicleOptionModel.VehicleData = Business.SqlQueries.GetAllChromedVehicles();

            return View(vehicleOptionModel);
        }

        public ActionResult NeedsStyle(string Location, string Condition)
        {
            var vehicleOptionModel = new VehicleOptionModel();

            if (Location == null || Location == "")
            {
                Location = "ALL";
            }

            if (Condition == null || Condition == "")
            {
                Condition = "ALL";
            }

            vehicleOptionModel.UsedVehicleDashboard = new UsedVehicleDashboard();
            vehicleOptionModel.UsedVehicleDashboard.AllUsedInventory = Business.SqlQueries.GetAllUsedInventory();
            vehicleOptionModel.UsedVehicleDashboard.WebsiteUsedInventory = Business.SqlQueries.GetWebsiteUsedInventory();

            vehicleOptionModel.NewVehicleDashboard = new NewVehicleDashboard();
            vehicleOptionModel.NewVehicleDashboard.AllNewInventory = Business.SqlQueries.GetAllNewInventory();
            vehicleOptionModel.NewVehicleDashboard.WebsiteNewInventory = Business.SqlQueries.GetWebsiteNewInventory();

            vehicleOptionModel.Location = Location;
            vehicleOptionModel.Condition = Condition;

            vehicleOptionModel.VehicleData = Business.SqlQueries.GetAllChromedVehicles();

            return View(vehicleOptionModel);
        }

    }
}