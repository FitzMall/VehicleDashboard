using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehicleDashboard.Models;
using VehicleDashboard.Business;
using System.Web.Mvc;
using System.Web.Routing;
using System.Collections.Specialized;

namespace VehicleDashboard.Controllers
{
    public class ChromeController : Controller
    {

        public bool GetUserInformation()
        {

            if (Request.Cookies["User"] != null)
            {
                var cookieValue = Request.Cookies["User"].Value;

                NameValueCollection qsCollection = HttpUtility.ParseQueryString(cookieValue);

                var userIdFromCookie = qsCollection["login"].ToString();
                var userNameFromCookie = qsCollection["name"].ToString();

                return true;
            }
            else
            {
                return false;
            }

        }
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

        [HttpPost]
        public ActionResult Vehicle(VehicleOptionModel vehicleOptionModel)
        {
            var vin = "";
            var stock = "";

            if(Request.Form != null)
            {
                var vehicleInformation = new VehicleData();
                vehicleInformation.InReconditioning = 0;

                if (Request.Form["vin"] != null)
                {
                    vehicleInformation.VIN = Request.Form["vin"];
                    vin = Request.Form["vin"];
                }
                if (Request.Form["stock"] != null)
                {
                    vehicleInformation.StockNumber = Request.Form["stock"];
                    stock = Request.Form["stock"];
                }


                if (Request.Form["chkInRecon"] != null)
                {
                    if(Request.Form["chkInRecon"] == "on")
                    {
                        vehicleInformation.InReconditioning = 1;
                    }
                }

                vehicleInformation.ManagerSpecial = 0;
                vehicleInformation.ManagerSpecialStartDate = new DateTime();
                vehicleInformation.ManagerSpecialEndDate = new DateTime();
                if (Request.Form["chkMgrSpecial"] != null)
                {
                    if (Request.Form["chkMgrSpecial"] == "on")
                    {
                        vehicleInformation.ManagerSpecial = 1;
                    }
                    if (Request.Form["startDate"] != null)
                    {
                        vehicleInformation.ManagerSpecialStartDate = DateTime.Parse(Request.Form["startDate"].ToString());
                    }

                    if (Request.Form["endDate"] != null)
                    {
                        if (Request.Form["endDate"] == "")
                        {
                            vehicleInformation.ManagerSpecialEndDate = new DateTime(1900, 1, 1);
                        }
                        else
                        {
                            vehicleInformation.ManagerSpecialEndDate = DateTime.Parse(Request.Form["endDate"].ToString());
                        }
                    }
                }

                vehicleInformation.VehiclePrice = 0;
                if (Request.Form["vehiclePrice"] != null && Request.Form["vehiclePrice"] != "")
                {
                    vehicleInformation.VehiclePrice = Decimal.Parse(Request.Form["vehiclePrice"]);
                }

                vehicleInformation.CertificationLevel = "";
                vehicleInformation.CertificationLevelCode = "";
                if(Request.Form["rdoCertification"] != null)
                {
                    vehicleInformation.CertificationLevelCode = Request.Form["rdoCertification"];
                }

                vehicleInformation.DateUpdated = DateTime.Now;
                
                SqlQueries.UpdateVehicleOptions(vehicleInformation);

                
            }

            var routeValues = new RouteValueDictionary {
              { "VIN", vin },
              { "Chromed", "true" }
            };

            return RedirectToAction("Vehicle", "Chrome", routeValues);
        }

        [HttpPost]
        public ActionResult VehicleOptions()
        {
            var vin = "";
            var stock = "";

            if (Request.Form != null)
            {
                if (Request.Form["vin"] != null)
                {
                    vin = Request.Form["vin"];
                }
                if (Request.Form["stock"] != null)
                {
                    stock = Request.Form["stock"];
                }

                foreach (var key in Request.Form.AllKeys)
                {
                    if (key.StartsWith("Option"))
                    {
                        var value = Request.Form[key];
                        var optionId = 0;
                        var showOption = true;

                        optionId = Int32.Parse(key.Replace("Option-", ""));
                        var values = value.Split(',');
                        if (values.Length == 1)
                        {
                            showOption = bool.Parse(values[0]);
                        }
                        else
                        {
                            showOption = bool.Parse(values[1]);
                        }
                        SqlQueries.UpdateVehicleOptionCode(optionId, showOption);
                    }
                }

            }

            var routeValues = new RouteValueDictionary {
              { "VIN", vin },
              { "Chromed", "true" }
            };

            return RedirectToAction("Vehicle", "Chrome", routeValues);
        }

        [HttpPost]
        public ActionResult VehiclePackages()
        {
            var vin = "";
            var stock = "";

            if (Request.Form != null)
            {
                if (Request.Form["vin"] != null)
                {
                    vin = Request.Form["vin"];
                }
                if (Request.Form["stock"] != null)
                {
                    stock = Request.Form["stock"];
                }

                foreach (var key in Request.Form.AllKeys)
                {
                    if (key.StartsWith("Package"))
                    {
                        var value = Request.Form[key];
                        var optionId = 0;
                        var showOption = true;

                        optionId = Int32.Parse(key.Replace("Package-", ""));
                        var values = value.Split(',');
                        if (values.Length == 1)
                        {
                            showOption = bool.Parse(values[0]);
                        }
                        else
                        {
                            showOption = bool.Parse(values[1]);
                        }
                        SqlQueries.UpdateVehiclePackages(optionId, showOption);
                    }
                }

            }

            var routeValues = new RouteValueDictionary {
              { "VIN", vin },
              { "Chromed", "true" }
            };

            return RedirectToAction("Vehicle", "Chrome", routeValues);
        }

        [HttpPost]
        public ActionResult VehicleFeatures()
        {
            var vin = "";
            var stock = "";

            if (Request.Form != null)
            {
                if (Request.Form["vin"] != null)
                {
                    vin = Request.Form["vin"];
                }
                if (Request.Form["stock"] != null)
                {
                    stock = Request.Form["stock"];
                }

                foreach (var key in Request.Form.AllKeys)
                {
                    if (key.StartsWith("Feature"))
                    {
                        var value = Request.Form[key];
                        var optionId = 0;
                        var showOption = true;

                        optionId = Int32.Parse(key.Replace("Feature-", ""));
                        var values = value.Split(',');
                        if (values.Length == 1)
                        {
                            showOption = bool.Parse(values[0]);
                        }
                        else
                        {
                            showOption = bool.Parse(values[1]);
                        }
                        SqlQueries.UpdateVehicleFeatures(optionId, showOption);
                    }
                }

            }

            var routeValues = new RouteValueDictionary {
              { "VIN", vin },
              { "Chromed", "true" }
            };

            return RedirectToAction("Vehicle", "Chrome", routeValues);
        }

        [HttpPost]
        public ActionResult VehicleTechSpecs()
        {
            var vin = "";
            var stock = "";

            if (Request.Form != null)
            {
                if (Request.Form["vin"] != null)
                {
                    vin = Request.Form["vin"];
                }
                if (Request.Form["stock"] != null)
                {
                    stock = Request.Form["stock"];
                }

                foreach (var key in Request.Form.AllKeys)
                {
                    if (key.StartsWith("Techspec"))
                    {
                        var value = Request.Form[key];
                        var optionId = 0;
                        var showOption = true;

                        optionId = Int32.Parse(key.Replace("Techspec-", ""));
                        var values = value.Split(',');
                        if (values.Length == 1)
                        {
                            showOption = bool.Parse(values[0]);
                        }
                        else
                        {
                            showOption = bool.Parse(values[1]);
                        }
                        SqlQueries.UpdateVehicleTechSpecs(optionId, showOption);
                    }
                }

            }

            var routeValues = new RouteValueDictionary {
              { "VIN", vin },
              { "Chromed", "true" }
            };

            return RedirectToAction("Vehicle", "Chrome", routeValues);
        }

        [HttpPost]
        public ActionResult UpdateOptions(int Id, bool Show)
        {
            var updated = SqlQueries.UpdateVehicleOptionCode(Id, Show);
            return Json(updated, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdatePackages(int Id, bool Show)
        {
            var updated = SqlQueries.UpdateVehiclePackages(Id, Show);
            return Json(updated, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateTechSpecs(int Id, bool Show)
        {
            var updated = SqlQueries.UpdateVehicleTechSpecs(Id, Show);
            return Json(updated, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateFeatures(int Id, bool Show)
        {
            var updated = SqlQueries.UpdateVehicleFeatures(Id, Show);
            return Json(updated, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Vehicle(string VIN, string Chromed = "true", int styleId = 0)
        {
            //if(!GetUserInformation())
            //{
            //    return Redirect("http://jjfserver");
            //}

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

                if(vehicleDataModel.VehicleData.StyleId == 0)
                {
                    var vehicleDescription = APIHelper.GetVehicleDescription(VIN);
                    if(vehicleDescription.result != null && vehicleDescription.result.vehicles.Count() > 0)
                    {
                        vehicleDataModel.PossibleStyleData = vehicleDescription.result.vehicles.ToList();
                    }
                }
            }
            else if(VIN != null && VIN != "" && Chromed == "false")
            {
                vehicleDataModel.VehicleData = SqlQueries.GetChromeVehicle(VIN);

                var vehicle = SqlQueries.GetInStockVehicle(VIN);

                if (vehicle != null && vehicleDataModel.VehicleData.Id == 0)
                {
                    var vehicleDescription = APIHelper.GetVehicleDescription(VIN);
                    
                    // NEED TO SEND LOCATION...
                    ChromeData.MapVehicleData(vehicleDescription, vehicle.StockNumber, vehicle.XrefId, vehicle.Condition, styleId, vehicle.Location);

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


        public ActionResult UpdateStyle(string vin, string stock, int styleId)
        {
            //Update the StyleID for this VIN...
            SqlQueries.UpdateStyleId(vin, stock, styleId);

            var routeValues = new RouteValueDictionary {
              { "VIN", vin },
              { "Chromed", "true" }
            };

            return RedirectToAction("Vehicle", "Chrome", routeValues);
            
        }

        public ActionResult ChromeNoStyle(string vin)
        {

            var possibleStyles = new List<Vehicle>();

            var vehicle = SqlQueries.GetInStockVehicle(vin);

            if (vehicle != null)
            {
                var vehicleDescription = APIHelper.GetVehicleDescription(vin);

                if (vehicleDescription != null && vehicleDescription.result != null)
                {
                    if (vehicleDescription.result.vehicles != null && vehicleDescription.result.vehicles.Count() > 0)
                    {
                        foreach(var vehicleDesc in vehicleDescription.result.vehicles)
                        {      
                            possibleStyles.Add(vehicleDesc);
                        }
                    }
                }
            }
        
            var vehicleDataModel = new VehicleDataModel();
            var vehicleData = new VehicleData();

            vehicleData.Year = Int32.Parse(vehicle.Year);
            vehicleData.Make = vehicle.Make;
            vehicleData.Model = vehicle.Model;
            vehicleData.StockNumber = vehicle.StockNumber;
            vehicleData.VIN = vin;

            vehicleDataModel.PossibleStyleData = possibleStyles;
            vehicleDataModel.VehicleData = vehicleData;

            return View(vehicleDataModel);
        }

        public ActionResult ChromeNoVIN(string stock, int year, string make, string model)
        {
            var service = new VehicleDashboard.ChromeData7c.Description7cPortTypeClient();

            var accountInfo = new VehicleDashboard.ChromeData7c.AccountInfo();
            accountInfo.number = "215862";
            accountInfo.secret = "f37e12d776934048";
            accountInfo.country = "US";
            accountInfo.language = "en";
            accountInfo.behalfOf = "ADS";

            //1. Get Division ID from the Model Year and Make
            var divisionRequest = new ChromeData7c.DivisionsRequest();
            divisionRequest.accountInfo = accountInfo;
            divisionRequest.modelYear = year;
            var divisionResponse = service.getDivisions(divisionRequest);
            var division = divisionResponse.division.ToList().Find(x => x.Value.ToUpper() == make.ToUpper());
            
            //2. Get Vehicle Model id from the Divison and Year
            var modelRequest = new ChromeData7c.ModelsRequest();
            modelRequest.accountInfo = accountInfo;
            modelRequest.modelYear = year;
            modelRequest.ItemElementName = ChromeData7c.ItemChoiceType.divisionId;
            modelRequest.Item = division.id;
            var modelResponse = service.getModels(modelRequest);
            var vehicleModel = modelResponse.model.ToList().Find(x => x.Value.ToUpper() == model.ToUpper());

            //3. Get the list of potential Style Ids from the Model ID
            var styleRequest = new ChromeData7c.StylesRequest();
            //var styleRequest = new StyleRequest
            styleRequest.accountInfo = accountInfo;
            styleRequest.modelId = vehicleModel.id;

            var styleResponse = service.getStyles(styleRequest);
            var possibleStyles = new List<Vehicle>();
            foreach(var possibleStyle in styleResponse.style)
            {
                var newStyle = new Vehicle();
                newStyle.styleId = possibleStyle.id;
                newStyle.styleDescription = possibleStyle.Value;
                possibleStyles.Add(newStyle);
            }

            // This is how you get a vehicle by the VIN...
            ////var vehicleRequest = new VehicleDashboard.ChromeData7c.VehicleDescriptionRequest();
            //var vehicleRequest = new VehicleDashboard.ChromeData7c.VehicleDescriptionRequest();
            //vehicleRequest.accountInfo = accountInfo;

            ////vehicleRequest.Items = new object[1];
            ////vehicleRequest.ItemsElementName = new VehicleDashboard.ChromeData7c.ItemsChoiceType[1];
            ////vehicleRequest.Items = new object[1];
            ////vehicleRequest.Items[0] = "1GTU9CED0KZ228146";
            ////vehicleRequest.ItemsElementName[0] = VehicleDashboard.ChromeData7c.ItemsChoiceType.vin;

            //vehicleRequest.ItemsElementName = new VehicleDashboard.ChromeData7c.ItemsChoiceType[3];
            //vehicleRequest.Items = new object[3];
            //vehicleRequest.Items[0] = 2023;
            //vehicleRequest.ItemsElementName[0] = VehicleDashboard.ChromeData7c.ItemsChoiceType.modelYear;
            //vehicleRequest.Items[1] = "SUBARU";
            //vehicleRequest.ItemsElementName[1] = VehicleDashboard.ChromeData7c.ItemsChoiceType.makeName;
            //vehicleRequest.Items[2] = "OUTBACK";
            //vehicleRequest.ItemsElementName[2] = VehicleDashboard.ChromeData7c.ItemsChoiceType.modelName;
            //vehicleRequest.manufacturerModelCode = "PDH";

            ////vehicleRequest.@switch = new[] { VehicleDashboard.ChromeData7c.Switch.ShowExtendedDescriptions, VehicleDashboard.ChromeData7c.Switch.ShowAvailableEquipment, VehicleDashboard.ChromeData7c.Switch.ShowConsumerInformation, VehicleDashboard.ChromeData7c.Switch.ShowExtendedTechnicalSpecifications, VehicleDashboard.ChromeData7c.Switch.IncludeRegionalVehicles, VehicleDashboard.ChromeData7c.Switch.IncludeDefinitions };
            //vehicleRequest.@switch = new[] { VehicleDashboard.ChromeData7c.Switch.ShowExtendedDescriptions, VehicleDashboard.ChromeData7c.Switch.ShowAvailableEquipment, VehicleDashboard.ChromeData7c.Switch.ShowConsumerInformation, VehicleDashboard.ChromeData7c.Switch.ShowExtendedTechnicalSpecifications, VehicleDashboard.ChromeData7c.Switch.IncludeRegionalVehicles, VehicleDashboard.ChromeData7c.Switch.IncludeDefinitions };


            ////, ChromeData.Switch.IncludeOnlyOEMBuildDataDecode
            //var vehicleResponse = service.describeVehicle(vehicleRequest);

            //var x = vehicleResponse.vinDescription;

            var vehicleDataModel = new VehicleDataModel();
            var vehicleData = new VehicleData();

            vehicleData.Year = year;
            vehicleData.Make = make;
            vehicleData.Model = model;
            vehicleData.ModelId = vehicleModel.id.ToString();
            vehicleData.StockNumber = stock;

            vehicleDataModel.PossibleStyleData = possibleStyles;
            vehicleDataModel.VehicleData = vehicleData;

            return View(vehicleDataModel);
        }

        public ActionResult VehicleNoVIN(string stock, int year, string make, int modelId, int styleId)
        {
            var service = new VehicleDashboard.ChromeData7c.Description7cPortTypeClient();

            var accountInfo = new VehicleDashboard.ChromeData7c.AccountInfo();
            accountInfo.number = "215862";
            accountInfo.secret = "f37e12d776934048";
            accountInfo.country = "US";
            accountInfo.language = "en";
            accountInfo.behalfOf = "ADS";

            //1. Get the list of potential Style Ids from the Model ID
            var styleRequest = new ChromeData7c.StylesRequest();
            //var styleRequest = new StyleRequest
            styleRequest.accountInfo = accountInfo;
            styleRequest.modelId = modelId;

            var styleResponse = service.getStyles(styleRequest);
            var possibleStyles = new List<Vehicle>();
            foreach (var possibleStyle in styleResponse.style)
            {
                var newStyle = new Vehicle();
                newStyle.styleId = possibleStyle.id;
                newStyle.styleDescription = possibleStyle.Value;
                possibleStyles.Add(newStyle);
            }

            var vehicleRequest = new VehicleDashboard.ChromeData7c.VehicleDescriptionRequest();
            vehicleRequest.accountInfo = accountInfo;
            vehicleRequest.ItemsElementName = new VehicleDashboard.ChromeData7c.ItemsChoiceType[1];
            vehicleRequest.Items = new object[1];
            vehicleRequest.Items[0] = styleId;
            vehicleRequest.ItemsElementName[0] = VehicleDashboard.ChromeData7c.ItemsChoiceType.styleId;
            vehicleRequest.@switch = new[] { VehicleDashboard.ChromeData7c.Switch.ShowExtendedDescriptions, VehicleDashboard.ChromeData7c.Switch.ShowAvailableEquipment, VehicleDashboard.ChromeData7c.Switch.IncludeCatalogData, VehicleDashboard.ChromeData7c.Switch.ShowExtendedTechnicalSpecifications, VehicleDashboard.ChromeData7c.Switch.IncludeRegionalVehicles, VehicleDashboard.ChromeData7c.Switch.IncludeDefinitions };
            var vehicleResponse = service.describeVehicle(vehicleRequest);
                        
            var vehicleDataModel = new VehicleDataModel();
            var vehicleData = new VehicleData();

            vehicleData.Condition = "NEW";
            vehicleData.Make = vehicleResponse.bestMakeName;
            vehicleData.Model = vehicleResponse.bestModelName;
            vehicleData.ModelId = modelId.ToString();
            vehicleData.StyleId = styleId;
            vehicleData.StockNumber = stock;
            vehicleData.Year = vehicleResponse.modelYear;

            vehicleDataModel.PossibleStyleData = possibleStyles;
            vehicleDataModel.VehicleData = vehicleData;
            vehicleDataModel.VehicleDescription = vehicleResponse;

            return View(vehicleDataModel);
        }
    }
}