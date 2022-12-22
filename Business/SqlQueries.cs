using System;
using VehicleDashboard.Models;
using VehicleDashboard.Business;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Linq;

namespace VehicleDashboard.Business
{
    public class SqlQueries
    {
        
        public static List<CSV_vehicleUSED> GetAllUsedInventory()
        {        
            var sqlGet = @"Select * from [JUNK].[dbo].[CSV_vehicleUSED]";

            var vehicles = SqlMapperUtil.SqlWithParams<CSV_vehicleUSED>(sqlGet, new { }, "JJFServer");
            return vehicles;
        }

        public static List<AllInventory> GetWebsiteUsedInventory()
        {
            var sqlGet = @"Select * from [FITZWAY].dbo.[AllInventory] where V_nu = 'USED'";

            var vehicles = SqlMapperUtil.SqlWithParams<AllInventory>(sqlGet, new { }, "JJFServer");
            return vehicles;
        }

        public static List<CSV_vehicleNew> GetAllNewInventory()
        {
            var sqlGet = @"Select * from [JUNK].[dbo].[CSV_vehicleNew]";

            var vehicles = SqlMapperUtil.SqlWithParams<CSV_vehicleNew>(sqlGet, new { }, "JJFServer");
            return vehicles;
        }

        public static List<AllInventory> GetWebsiteNewInventory()
        {
            var sqlGet = @"Select * from [FITZWAY].dbo.[AllInventory] where V_nu = 'NEW'";

            var vehicles = SqlMapperUtil.SqlWithParams<AllInventory>(sqlGet, new { }, "JJFServer");
            return vehicles;
        }

        public static List<VehicleData> GetAllChromedVehicles()
        {
            var results = SqlMapperUtil.StoredProcWithParams<VehicleData>("sp_GetChromedInventory", new {  }, "ChromeData");

            return results;

        }


        public static VehicleData GetChromeVehicle(string vin)
        {
            var vData = new VehicleData();

            var results = SqlMapperUtil.StoredProcWithParams<VehicleData>("sp_GetVehicle", new { VIN = vin }, "ChromeData");

            if (results != null && results.Count > 0)
            {
                vData = results[0];
            }

            return vData;

        }

        public static StyleData GetChromeVehicleStyle(int styleId)
        {
            var vData = new StyleData();

            var results = SqlMapperUtil.StoredProcWithParams<StyleData>("sp_GetStyle", new { StyleId = styleId }, "ChromeData");

            if (results != null && results.Count > 0)
            {
                vData = results[0];
            }

            return vData;

        }

        public static ExteriorColorData GetChromeVehicleExteriorColor(int colorId)
        {
            var vData = new ExteriorColorData();

            var results = SqlMapperUtil.StoredProcWithParams<ExteriorColorData>("sp_GetVehicleExteriorColor", new { ColorId = colorId }, "ChromeData");

            if (results != null && results.Count > 0)
            {
                vData = results[0];
            }

            return vData;

        }

        public static InteriorColorData GetChromeVehicleInteriorColor(int colorId)
        {
            var vData = new InteriorColorData();

            var results = SqlMapperUtil.StoredProcWithParams<InteriorColorData>("sp_GetVehicleInteriorColor", new { ColorId = colorId }, "ChromeData");

            if (results != null && results.Count > 0)
            {
                vData = results[0];
            }

            return vData;

        }

        public static List<PackageData> GetChromeVehiclePackages(int vehicleId)
        {

            var results = SqlMapperUtil.StoredProcWithParams<PackageData>("sp_GetVehiclePackages", new { VehicleId = vehicleId }, "ChromeData");

            return results;

        }

        public static List<FeatureData> GetChromeVehicleFeatures(int vehicleId)
        {

            var results = SqlMapperUtil.StoredProcWithParams<FeatureData>("sp_GetVehicleFeatures", new { VehicleId = vehicleId }, "ChromeData");

            return results;

        }

        public static List<OptionData> GetChromeVehicleOptions(int vehicleId)
        {

            var results = SqlMapperUtil.StoredProcWithParams<OptionData>("sp_GetVehicleOptions", new { VehicleId = vehicleId }, "ChromeData");

            return results;

        }

        public static List<TechSpecData> GetChromeVehicleTechSpecs(int vehicleId)
        {

            var results = SqlMapperUtil.StoredProcWithParams<TechSpecData>("sp_GetVehicleTechSpecs", new { VehicleId = vehicleId }, "ChromeData");

            return results;

        }

        public static List<InStockVehicle> GetInStockVehicles()
        {
            var results = SqlMapperUtil.SqlWithParams<InStockVehicle>("Select V_Vin as VIN, v_Stock as StockNumber, V_xrefid as XrefId from fitzway.dbo.AllInventoryFM where v_vin <> 'XX' and v_vin not in (Select VIN from ChromeDataCVD.dbo.Vehicle)", "", "JJFServer");
            return results;
        }
        public static InStockVehicle GetInStockVehicle(string VIN)
        {
            var result = new InStockVehicle();
            var results = SqlMapperUtil.SqlWithParams<InStockVehicle>("Select stk as StockNumber, vin as VIN, '' as XrefId from [JUNK].[dbo].[CSV_vehicleUsed] where vin = @VIN1 UNION Select stk_no as StockNumber, vin as VIN, '' as XrefId from [JUNK].[dbo].[CSV_vehicleNew] where vin = @VIN2", new { VIN1 = VIN, VIN2 = VIN}, "JJFServer");

            if(results != null && results.Count > 0)
            {
                result = results[0];
            }

            return result;
        }
        public static bool CheckStyle(int styleId)
        {
            var styleExists = false;

            var results = SqlMapperUtil.StoredProcWithParams<StyleData>("sp_GetStyle", new { StyleId = styleId }, "ChromeData");

            if (results != null && results.Count > 0)
            {
                styleExists = true;
            }

            return styleExists;

        }

        public static int CheckExteriorColor(string colorCode, int styleId)
        {
            var colorCodeId = 0;

            var results = SqlMapperUtil.StoredProcWithParams<ExteriorColorData>("sp_GetExteriorColor", new { ColorCode = colorCode, StyleId = styleId }, "ChromeData");

            if (results != null && results.Count > 0)
            {
                colorCodeId = results[0].Id;
            }

            return colorCodeId;

        }


        public static int CheckInteriorColor(string colorCode, int styleId)
        {
            var colorCodeId = 0;

            var results = SqlMapperUtil.StoredProcWithParams<InteriorColorData>("sp_GetInteriorColor", new { ColorCode = colorCode, StyleId = styleId }, "ChromeData");

            if (results != null && results.Count > 0)
            {
                colorCodeId = results[0].Id;
            }

            return colorCodeId;

        }

        public static int CheckFeature(int Id, string key)
        {
            var featureId = 0;

            var results = SqlMapperUtil.StoredProcWithParams<FeatureData>("sp_GetFeature", new { FeatureId = Id, Key = key }, "ChromeData");

            if (results != null && results.Count > 0)
            {
                featureId = results[0].Id;
            }

            return featureId;

        }

        public static int CheckOption(string optionCode, int styleId)
        {
            var optionId = 0;

            var results = SqlMapperUtil.StoredProcWithParams<OptionData>("sp_GetOptionCodeContent", new { OptionCode = optionCode, StyleId = styleId }, "ChromeData");

            if (results != null && results.Count > 0)
            {
                optionId = results[0].Id;
            }

            return optionId;

        }

        public static int CheckPackage(int Id, string key)
        {
            var packageId = 0;

            var results = SqlMapperUtil.StoredProcWithParams<PackageData>("sp_GetPackage", new { PackageId = Id, Key = key }, "ChromeData");

            if (results != null && results.Count > 0)
            {
                packageId = results[0].Id;
            }

            return packageId;

        }

        public static int CheckTechSpec(int Id, string key)
        {
            var techSpecId = 0;

            var results = SqlMapperUtil.StoredProcWithParams<TechSpecData>("sp_GetTechSpec", new { TechSpecId = Id, Key = key }, "ChromeData");

            if (results != null && results.Count > 0)
            {
                techSpecId = results[0].Id;
            }

            return techSpecId;

        }

        public static int CheckVehicle(string vin)
        {
            var vehicleId = 0;

            var results = SqlMapperUtil.StoredProcWithParams<VehicleData>("sp_GetVehicle", new { VIN = vin }, "ChromeData");

            if (results != null && results.Count > 0)
            {
                vehicleId = results[0].Id;
            }

            return vehicleId;

        }

        public static int AddStyle(StyleData styleData)
        {
            var styleKeyId = 0;

            styleKeyId = SqlMapperUtil.InsertUpdateOrDeleteStoredProc("sp_InsertStyle", styleData, "ChromeData");

            return styleKeyId;

        }
        public static int AddExteriorColor(ExteriorColorData colorData)
        {
            var colorId = 0;

            var result = SqlMapperUtil.InsertUpdateOrDeleteStoredProc("sp_InsertExteriorColor", colorData, "ChromeData");
            colorId = CheckExteriorColor(colorData.ColorCode, colorData.StyleId);

            return colorId;

        }
        public static int AddInteriorColor(InteriorColorData colorData)
        {
            var colorId = 0;

            var result = SqlMapperUtil.InsertUpdateOrDeleteStoredProc("sp_InsertInteriorColor", colorData, "ChromeData");
            colorId = CheckInteriorColor(colorData.ColorCode, colorData.StyleId);

            return colorId;

        }

        public static int AddVehicle(VehicleData vehicleData)
        {
            var vehicleId = 0;

            var result = SqlMapperUtil.InsertUpdateOrDeleteStoredProc("sp_InsertVehicle", vehicleData, "ChromeData");
            vehicleId = CheckVehicle(vehicleData.VIN);

            return vehicleId;

        }

        public static int AddFeature(FeatureData featureData)
        {
            var featureId = 0;

            var result = SqlMapperUtil.InsertUpdateOrDeleteStoredProc("sp_InsertFeature", featureData, "ChromeData");
            featureId = CheckFeature(featureData.FeatureId, featureData.Key);

            return featureId;

        }

        public static int AddOption(OptionData optionData)
        {
            var optionId = 0;

            var result = SqlMapperUtil.InsertUpdateOrDeleteStoredProc("sp_InsertOptionCode", optionData, "ChromeData");
            optionId = CheckOption(optionData.OptionCode, optionData.StyleId);

            return optionId;

        }

        public static int AddPackage(PackageData packageData)
        {
            var packageId = 0;

            var result = SqlMapperUtil.InsertUpdateOrDeleteStoredProc("sp_InsertPackage", packageData, "ChromeData");
            packageId = CheckPackage(packageData.PackageId, packageData.Key);

            return packageId;

        }

        public static int AddTechSpec(TechSpecData techSpecData)
        {
            var techSpecId = 0;

            var result = SqlMapperUtil.InsertUpdateOrDeleteStoredProc("sp_InsertTechSpec", techSpecData, "ChromeData");
            techSpecId = CheckTechSpec(techSpecData.TechSpecId, techSpecData.Key);

            return techSpecId;

        }

        public static void AddVehicleFeatureMapping(int vehicleId, int featureId)
        {

            var result = SqlMapperUtil.InsertUpdateOrDeleteStoredProc("sp_InsertVehicleFeatureMapping", new { VehicleId = vehicleId, FeatureId = featureId }, "ChromeData");

        }

        public static void AddVehicleOptionMapping(int vehicleId, int optionId)
        {

            var result = SqlMapperUtil.InsertUpdateOrDeleteStoredProc("sp_InsertVehicleOptionMapping", new { VehicleId = vehicleId, OptionId = optionId }, "ChromeData");

        }

        public static void AddVehiclePackageMapping(int vehicleId, int packageId)
        {

            var result = SqlMapperUtil.InsertUpdateOrDeleteStoredProc("sp_InsertVehiclePackageMapping", new { VehicleId = vehicleId, PackageId = packageId }, "ChromeData");

        }

        public static void AddVehicleTechSpecMapping(int vehicleId, int techSpecId)
        {

            var result = SqlMapperUtil.InsertUpdateOrDeleteStoredProc("sp_InsertVehicleTechSpecMapping", new { VehicleId = vehicleId, TechSpecId = techSpecId }, "ChromeData");

        }

        public static bool InsertOrUpdateDealers() //IEnumerable<DealerModel> dealers
        {
            var bSuccess = false;

            //foreach (var dealer in dealers)
            //{
            //    SqlMapperUtil.InsertUpdateOrDeleteSql("INSERT INTO [dbo].[Dealer] VALUES (@DealerID, @DealerName, @DealerBrands, @DealerAddress, @DealerCity, @DealerStateProvince, @DealerPostalCode, @DealerCountry, @RecordStatusCode, @LastUpdatedUTCDate)", 
            //        new { DealerID = dealer.DealerID,
            //            DealerName = dealer.DealerName,
            //            DealerBrands = dealer.DealerBrands,
            //            DealerAddress = dealer.DealerAddress,
            //            DealerCity = dealer.DealerCity,
            //            DealerStateProvince = dealer.DealerStateProvince,
            //            DealerPostalCode = dealer.DealerPostalCode,
            //            DealerCountry = dealer.DealerCountry,
            //            RecordStatusCode = dealer.RecordStatusCode,
            //            LastUpdatedUTCDate = dealer.LastUpdatedUTCDate
            //        }, "ChromeData");
            //}
            return bSuccess;
        }

        public static List<VehicleImages> GetVehicleImages(string VIN, string StockNumber)
        {
            var sqlGet = @"SELECT [ImagePath],[ImageOrder] FROM [FITZWAY].[dbo].[FM_HomeNetImages] where VIN = @VIN order by ImageOrder";

            var images = SqlMapperUtil.SqlWithParams<VehicleImages>(sqlGet, new { VIN = VIN }, "Rackspace");
            return images;
        }
    }
}

