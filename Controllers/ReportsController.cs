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
        public ActionResult Handyman(string Location)
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
            string[] dddd = Business.SqlQueries.ALL_1551and1550_Files();

            return View(usedVehicleDashboard);
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
        public ActionResult NotCheckedOut(string Location)
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

        public ActionResult FuelType(string Location, string Condition)
        {
            var vehicleOptionModel = new VehicleOptionModel();

            if (Location == null)
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

        public ActionResult AllVehicles(string Location, string Condition, string PhotoShow)
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

            var mNewInventory = Business.SqlQueries.GetAllNewInventory();
            var mUsedInventory = Business.SqlQueries.GetAllUsedInventory();
            var mNewWeb = Business.SqlQueries.GetWebsiteNewInventory();
            var mUsedWeb =  Business.SqlQueries.GetWebsiteUsedInventory();

            vehicleOptionModel.UsedVehicleDashboard = new UsedVehicleDashboard();
            vehicleOptionModel.NewVehicleDashboard = new NewVehicleDashboard();
            
            if (PhotoShow == null || PhotoShow =="") { 
                vehicleOptionModel.UsedVehicleDashboard.AllUsedInventory = mUsedInventory;
                vehicleOptionModel.UsedVehicleDashboard.WebsiteUsedInventory = mUsedWeb;
                vehicleOptionModel.NewVehicleDashboard.AllNewInventory = mNewInventory;
                vehicleOptionModel.NewVehicleDashboard.WebsiteNewInventory = mNewWeb;
            } else
            {
                switch (PhotoShow)
                { case "10P":
                        vehicleOptionModel.UsedVehicleDashboard.AllUsedInventory = mUsedInventory.FindAll(x=> x.Photos > 10);
                        vehicleOptionModel.UsedVehicleDashboard.WebsiteUsedInventory = mUsedWeb.FindAll(x => x.Photos > 10);
                        vehicleOptionModel.NewVehicleDashboard.AllNewInventory = mNewInventory.FindAll(x => x.Photos > 10);
                        vehicleOptionModel.NewVehicleDashboard.WebsiteNewInventory = mNewWeb.FindAll(x => x.Photos > 10);
                        break;
                    case "NONE":
                        vehicleOptionModel.UsedVehicleDashboard.AllUsedInventory = mUsedInventory.FindAll(x => x.Photos == 0);
                        vehicleOptionModel.UsedVehicleDashboard.WebsiteUsedInventory = mUsedWeb.FindAll(x => x.Photos == 0);
                        vehicleOptionModel.NewVehicleDashboard.AllNewInventory = mNewInventory.FindAll(x => x.Photos == 0);
                        vehicleOptionModel.NewVehicleDashboard.WebsiteNewInventory = mNewWeb.FindAll(x => x.Photos == 0);
                        break;
                    case "10L":
                        vehicleOptionModel.UsedVehicleDashboard.AllUsedInventory = mUsedInventory.FindAll(x => x.Photos < 11 && x.Photos > 0);
                        vehicleOptionModel.UsedVehicleDashboard.WebsiteUsedInventory = mUsedWeb.FindAll(x => x.Photos < 11 && x.Photos > 0);
                        vehicleOptionModel.NewVehicleDashboard.AllNewInventory = mNewInventory.FindAll(x => x.Photos < 11 && x.Photos > 0);
                        vehicleOptionModel.NewVehicleDashboard.WebsiteNewInventory = mNewWeb.FindAll(x => x.Photos < 11 && x.Photos > 0);
                        break;
                }
            }


            vehicleOptionModel.Location = Location;
            vehicleOptionModel.Condition = Condition;
            vehicleOptionModel.PhotoShow = PhotoShow;
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