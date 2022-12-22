using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehicleDashboard.Models;
using VehicleDashboard.Business;
using System.Web.Mvc;

namespace VehicleDashboard.Controllers
{
    public class ChromeController : Controller
    {
        // GET: Chrome
        public ActionResult Index(string Location)
        {
            var vehicleOptionModel = new VehicleOptionModel();

            if (Location == null)
            {
                Location = "ALL";
            }

            vehicleOptionModel.UsedVehicleDashboard = new UsedVehicleDashboard();
            vehicleOptionModel.UsedVehicleDashboard.AllUsedInventory = Business.SqlQueries.GetAllUsedInventory();
            vehicleOptionModel.UsedVehicleDashboard.WebsiteUsedInventory = Business.SqlQueries.GetWebsiteUsedInventory();

            vehicleOptionModel.NewVehicleDashboard = new NewVehicleDashboard();
            vehicleOptionModel.NewVehicleDashboard.AllNewInventory = Business.SqlQueries.GetAllNewInventory();
            vehicleOptionModel.NewVehicleDashboard.WebsiteNewInventory = Business.SqlQueries.GetWebsiteNewInventory();

            //if(Location != null && Location != "")
            //{
            //    vehicleOptionModel.UsedVehicleDashboard.AllUsedInventory = vehicleOptionModel.UsedVehicleDashboard.AllUsedInventory.FindAll(x => x.loc == Location);
            //    vehicleOptionModel.UsedVehicleDashboard.WebsiteUsedInventory = vehicleOptionModel.UsedVehicleDashboard.WebsiteUsedInventory.FindAll(x => x.V_loc == Location);

            //    vehicleOptionModel.NewVehicleDashboard.AllNewInventory = vehicleOptionModel.NewVehicleDashboard.AllNewInventory.FindAll(x => x.LOC == Location);
            //    vehicleOptionModel.NewVehicleDashboard.WebsiteNewInventory = vehicleOptionModel.NewVehicleDashboard.WebsiteNewInventory.FindAll(x => x.V_loc == Location);

                vehicleOptionModel.Location = Location;
            //}

            vehicleOptionModel.VehicleData = Business.SqlQueries.GetAllChromedVehicles();


            return View(vehicleOptionModel);
        }
        public ActionResult Vehicle(string VIN, string Chromed = "true")
        {
            var vehicleDataModel = new VehicleDataModel();

            if (VIN != null && VIN != "" && Chromed == "true")
            {
                
                vehicleDataModel.VehicleData = SqlQueries.GetChromeVehicle(VIN);

                vehicleDataModel.StyleData = SqlQueries.GetChromeVehicleStyle(vehicleDataModel.VehicleData.StyleId);
                vehicleDataModel.ExteriorColorData = SqlQueries.GetChromeVehicleExteriorColor(vehicleDataModel.VehicleData.ExteriorColorId);
                vehicleDataModel.InteriorColorData = SqlQueries.GetChromeVehicleInteriorColor(vehicleDataModel.VehicleData.InteriorColorId);

                vehicleDataModel.PackageData = SqlQueries.GetChromeVehiclePackages(vehicleDataModel.VehicleData.Id);
                vehicleDataModel.OptionData = SqlQueries.GetChromeVehicleOptions(vehicleDataModel.VehicleData.Id);
                vehicleDataModel.FeatureData = SqlQueries.GetChromeVehicleFeatures(vehicleDataModel.VehicleData.Id);
                vehicleDataModel.TechSpecData = SqlQueries.GetChromeVehicleTechSpecs(vehicleDataModel.VehicleData.Id);
            }
            else if(VIN != null && VIN != "" && Chromed == "false")
            {
                vehicleDataModel.VehicleData = SqlQueries.GetChromeVehicle(VIN);

                var vehicle = SqlQueries.GetInStockVehicle(VIN);

                if (vehicle != null && vehicleDataModel.VehicleData.Id == 0)
                {
                    var vehicleDescription = APIHelper.GetVehicleDescription(VIN);

                    ChromeData.MapVehicleData(vehicleDescription, vehicle.StockNumber, vehicle.XrefId);

                    vehicleDataModel.VehicleData = SqlQueries.GetChromeVehicle(VIN);

                    vehicleDataModel.StyleData = SqlQueries.GetChromeVehicleStyle(vehicleDataModel.VehicleData.StyleId);
                    vehicleDataModel.ExteriorColorData = SqlQueries.GetChromeVehicleExteriorColor(vehicleDataModel.VehicleData.ExteriorColorId);
                    vehicleDataModel.InteriorColorData = SqlQueries.GetChromeVehicleInteriorColor(vehicleDataModel.VehicleData.InteriorColorId);

                    vehicleDataModel.PackageData = SqlQueries.GetChromeVehiclePackages(vehicleDataModel.VehicleData.Id);
                    vehicleDataModel.OptionData = SqlQueries.GetChromeVehicleOptions(vehicleDataModel.VehicleData.Id);
                    vehicleDataModel.FeatureData = SqlQueries.GetChromeVehicleFeatures(vehicleDataModel.VehicleData.Id);
                    vehicleDataModel.TechSpecData = SqlQueries.GetChromeVehicleTechSpecs(vehicleDataModel.VehicleData.Id);
                }
            }

            vehicleDataModel.VehicleImages = SqlQueries.GetVehicleImages(VIN,"");

            return View(vehicleDataModel);
        }

        [HttpPost]
        public ActionResult Vehicle(string VIN)
        {
            var vehicleDataModel = new VehicleDataModel();

            vehicleDataModel.VehicleData = SqlQueries.GetChromeVehicle(VIN);
            vehicleDataModel.StyleData = SqlQueries.GetChromeVehicleStyle(vehicleDataModel.VehicleData.StyleId);
            vehicleDataModel.ExteriorColorData = SqlQueries.GetChromeVehicleExteriorColor(vehicleDataModel.VehicleData.ExteriorColorId);
            vehicleDataModel.InteriorColorData = SqlQueries.GetChromeVehicleInteriorColor(vehicleDataModel.VehicleData.InteriorColorId);

            vehicleDataModel.PackageData = SqlQueries.GetChromeVehiclePackages(vehicleDataModel.VehicleData.Id);
            vehicleDataModel.OptionData = SqlQueries.GetChromeVehicleOptions(vehicleDataModel.VehicleData.Id);
            vehicleDataModel.FeatureData = SqlQueries.GetChromeVehicleFeatures(vehicleDataModel.VehicleData.Id);
            vehicleDataModel.TechSpecData = SqlQueries.GetChromeVehicleTechSpecs(vehicleDataModel.VehicleData.Id);



            return View(vehicleDataModel);
        }
    }
}