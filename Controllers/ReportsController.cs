﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
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

        public ActionResult _UploadFile(string VIN)
        {
            // "~/PDFs1550/"
            //var path = Server.MapPath(@"C:\inetpub\wwwroot\production\FITZWAY\Pictures\UCPDFS");
            var path = (@"C:\inetpub\wwwroot\production\FITZWAY\Pictures\UCPDFS");

            var dir = new DirectoryInfo(path);

        //    var files = dir.EnumerateFiles("????" + VIN + ".pdf").Select(f => f.Name);
            var files = dir.EnumerateFiles(VIN + ".pdf").Select(f => f.Name);
            ViewBag.UserMsg = VIN + ".pdf";
            ViewBag.UserWarn = "";
            if (files.Count() > 0)
            {
                ViewBag.UserWarn = "File Already There";
            }
            return View(files);
        }

        [HttpPost]
        public ActionResult _UploadFile(HttpPostedFileBase file)
        {
   
            if (file != null)
            {
                //   var path = Path.Combine(Server.MapPath(@"C:\inetpub\wwwroot\production\FITZWAY\Pictures\UCPDFS"), file.FileName);
                var path = Path.Combine((@"C:\inetpub\wwwroot\production\FITZWAY\Pictures\UCPDFS"), file.FileName);

                var data = new byte[file.ContentLength];
                file.InputStream.Read(data, 0, file.ContentLength);

                using (var sw = new FileStream(path, FileMode.Create))
                {
                    sw.Write(data, 0, data.Length);
                }
               
            }
            ViewBag.Processed = true;
            return View("");
        }
        public ActionResult yHandyman(string Location, string NoPDF)
        {
            var usedVehicleDashboard = new Models.UsedVehicleDashboard();

            if (Location == null)
            {
                Location = "ALL";
            }

            if (NoPDF == null)
            {
                NoPDF = "";
            }

            usedVehicleDashboard.AllUsedInventory = Business.SqlQueries.GetAllUsedInventory();
            usedVehicleDashboard.AllUsedInventory = usedVehicleDashboard.AllUsedInventory.FindAll(x => (x.status == 1 || x.status == 2 || x.status == 4));

            usedVehicleDashboard.WebsiteUsedInventory = Business.SqlQueries.GetWebsiteUsedInventory();
            usedVehicleDashboard.Location = Location;
            usedVehicleDashboard.VehicleData = Business.SqlQueries.GetAllChromedVehicles();
            usedVehicleDashboard.PDFs_1550_1551 = Business.SqlQueries.ALL_1551and1550_Files();
            usedVehicleDashboard.NoPDF = NoPDF;  // 1550, 1551, BOTH or blank if regular Handyman report

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

        public ActionResult Handyman(string Location, string NoPDF, string DeleteFile)
        {
            var usedVehicleDashboard = new Models.UsedVehicleDashboard();

            if (Location == null)
            {
                Location = "ALL";
            }

            if (NoPDF == null)
            {
                NoPDF = "";
            }


            if (System.IO.File.Exists(DeleteFile))
            {
                System.IO.File.Delete(DeleteFile); // Delete the file
               // System.Threading.Thread.Sleep(4000);
            }

            usedVehicleDashboard.AllUsedInventory = Business.SqlQueries.GetAllUsedInventory();
            usedVehicleDashboard.AllUsedInventory = usedVehicleDashboard.AllUsedInventory.FindAll(x => (x.status == 1 || x.status == 2 || x.status == 4));

            usedVehicleDashboard.WebsiteUsedInventory = Business.SqlQueries.GetWebsiteUsedInventory();
            usedVehicleDashboard.Location = Location;
            usedVehicleDashboard.VehicleData = Business.SqlQueries.GetAllChromedVehicles();
            usedVehicleDashboard.PDFs_1550_1551 = Business.SqlQueries.ALL_1551and1550_Files();
            usedVehicleDashboard.NoPDF = NoPDF;  // 1550, 1551, BOTH or blank if regular Handyman report

            return View(usedVehicleDashboard);
        }



        public ActionResult NotCheckedOut(string Location)
        {
            var usedVehicleDashboard = new Models.UsedVehicleDashboard();

            if (Location == null)
            {
                Location = "ALL";
            }

            string UserCookie = Request.Cookies["user"].Value;
            ViewBag.UserRank = Business.SqlQueries.GetUserRole(UserCookie);

            usedVehicleDashboard.AllUsedInventory = Business.SqlQueries.GetAllUsedInventory();
            usedVehicleDashboard.WebsiteUsedInventory = Business.SqlQueries.GetWebsiteUsedInventory();
            usedVehicleDashboard.Location = Location;
            usedVehicleDashboard.VehicleData = Business.SqlQueries.GetAllChromedVehicles();
            usedVehicleDashboard.FitzwayCheckoutIDs = Business.SqlQueries.FitzWayCheckout_IDs();


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
                        vehicleOptionModel.UsedVehicleDashboard.WebsiteUsedInventory = mUsedWeb;
                        vehicleOptionModel.NewVehicleDashboard.AllNewInventory = mNewInventory.FindAll(x => x.Photos > 10);
                        vehicleOptionModel.NewVehicleDashboard.WebsiteNewInventory = mNewWeb;
                        break;
                    case "NONE":
                        vehicleOptionModel.UsedVehicleDashboard.AllUsedInventory = mUsedInventory.FindAll(x => x.Photos == 0);
                        vehicleOptionModel.UsedVehicleDashboard.WebsiteUsedInventory = mUsedWeb;
                        vehicleOptionModel.NewVehicleDashboard.AllNewInventory = mNewInventory.FindAll(x => x.Photos == 0);
                        vehicleOptionModel.NewVehicleDashboard.WebsiteNewInventory = mNewWeb;
                        break;
                    case "10L":
                        vehicleOptionModel.UsedVehicleDashboard.AllUsedInventory = mUsedInventory.FindAll(x => x.Photos < 11 && x.Photos > 0);
                        vehicleOptionModel.UsedVehicleDashboard.WebsiteUsedInventory = mUsedWeb;
                        vehicleOptionModel.NewVehicleDashboard.AllNewInventory = mNewInventory.FindAll(x => x.Photos < 11 && x.Photos > 0);
                        vehicleOptionModel.NewVehicleDashboard.WebsiteNewInventory = mNewWeb;
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