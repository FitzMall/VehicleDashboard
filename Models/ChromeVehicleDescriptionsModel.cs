using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleDashboard.Models
{
    public class VehicleDataModel
    {
        public VehicleData VehicleData { get; set; }
        public StyleData StyleData { get; set; }
        public ExteriorColorData ExteriorColorData { get; set; }
        public InteriorColorData InteriorColorData { get; set; }

        public List<FeatureData> FeatureData { get; set; }
        public List<PackageData> PackageData { get; set; }
        public List<TechSpecData> TechSpecData { get; set; }
        public List<OptionData> OptionData { get; set; }
        public List<VehicleImages> VehicleImages { get; set; }
    }

    public class VehicleImages
    {
        public string ImageOrder { get; set; }
        public string ImagePath { get; set; }
    }

    public class VehicleData
    {
        public int Id { get; set; }
        public string VIN { get; set; }
        public string StockNumber { get; set; }
        public string XrefId { get; set; }
        public string Source { get; set; }
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string ModelId { get; set; }
        public decimal BuildMSRP { get; set; }
        public DateTime BuildDate { get; set; }
        public string Country { get; set; }
        public string Manufacturer { get; set; }
        public string BuildSource { get; set; }
        public int StyleId { get; set; }
        public int ExteriorColorId { get; set; }
        public int InteriorColorId { get; set; }
        public DateTime DateUpdated { get; set; }
        public string Condition { get; set; }
        public string CertificationLevelCode { get; set; }
        public string CertificationLevel { get; set; }
        public int InReconditioning { get; set; }
        public int ManagerSpecial { get; set; }
        public DateTime ManagerSpecialStartDate { get; set; }
        public DateTime ManagerSpecialEndDate { get; set; }
        public decimal VehiclePrice { get; set; }
        public string OptionsApprovedBy { get; set; }
        public DateTime OptionsApprovedDate { get; set; }
    }

    public class StyleData
    {
        public int Id { get; set; }
        public int StyleId { get; set; }
        public string StyleDescription { get; set; }
        public string Trim { get; set; }
        public decimal BaseMSRP { get; set; }
        public decimal DestinationCharge { get; set; }
        public string DriveType { get; set; }
        public string BodyType { get; set; }
        public int StandardCurbWeight { get; set; }
        public int StandardTowingCapacity { get; set; }
        public string Country { get; set; }
        public int StandardGVWR { get; set; }
        public string MFRModelCode { get; set; }
        public int Doors { get; set; }
        public string Segment { get; set; }
        public decimal Wheelbase { get; set; }
    }

    public class ExteriorColorData
    {
        public int Id { get; set; }
        public string GenericDescription { get; set; }
        public string Description { get; set; }
        public string ColorCode { get; set; }
        public string InstallCause { get; set; }
        public int StyleId { get; set; }
        public string RGBValue { get; set; }
        public string RGBHexValue { get; set; }
        public int Type { get; set; }
        public bool Primary { get; set; }
    }

    public class InteriorColorData
    {
        public int Id { get; set; }
        public string GenericDescription { get; set; }
        public string ColorCode { get; set; }
        public string Description { get; set; }
        public string InstallCause { get; set; }
        public int StyleId { get; set; }
    }

    public class FeatureData
    {
        public int Id { get; set; }
        public int FeatureId { get; set; }
        public string Key { get; set; }
        public int SectionId { get; set; }
        public int SubSectionId { get; set; }
        public string SectionName { get; set; }
        public string Name { get; set; }
        public string NameNoBrand { get; set; }
        public string Description { get; set; }
        public int RankingValue { get; set; }
        public int StyleId { get; set; }
        public string InstallCause { get; set; }
        public bool IsStandard { get; set; }
        public string BenefitTitle { get; set; }
        public string BenefitDefinition { get; set; }
        public string BenefitStatement { get; set; }
    }

    public class PackageData
    {
        public int Id { get; set; }
        public int PackageId { get; set; }
        public string Key { get; set; }
        public int SectionId { get; set; }
        public int SubSectionId { get; set; }
        public string SectionName { get; set; }
        public string Name { get; set; }
        public string NameNoBrand { get; set; }
        public string Description { get; set; }
        public int RankingValue { get; set; }
        public int StyleId { get; set; }
        public string InstallCause { get; set; }
        public bool IsStandard { get; set; }
        public string OptionCode { get; set; }
        public decimal MSRP { get; set; }
        public string Content { get; set; }
    }

    public class TechSpecData
    {
        public int Id { get; set; }
        public int TechSpecId { get; set; }
        public string Key { get; set; }
        public int SectionId { get; set; }
        public int SubSectionId { get; set; }
        public string SectionName { get; set; }
        public string Name { get; set; }
        public string NameNoBrand { get; set; }
        public string Description { get; set; }
        public int RankingValue { get; set; }
        public int StyleId { get; set; }
        public string InstallCause { get; set; }
        public bool IsStandard { get; set; }
        public string BenefitTitle { get; set; }
        public string BenefitDefinition { get; set; }
        public string BenefitStatement { get; set; }
    }

    public class OptionData
    {
        public int Id { get; set; }
        public int StyleId { get; set; }
        public string OptionCode { get; set; }
        public decimal MSRP { get; set; }
        public string OptionDescription { get; set; }
        public string InstallCause { get; set; }
        public string Content { get; set; }
    }

    public class InStockVehicle
    {
        public string VIN { get; set; }
        public string StockNumber { get; set; }
        public string XrefId { get; set; }
    }

    public class ChromeVehicleDescriptionModel
    {
        public string error { get; set; }
        public string copyright { get; set; }
        public VehicleResult result { get; set; }
    }

    public class VehicleResult
    {
        public string vinSubmitted { get; set; }
        public string vinProcessed { get; set; }
        public bool validVin { get; set; }
        public string source { get; set; }
        public int year { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public string modelID { get; set; }
        public decimal buildMSRP { get; set; }
        public DateTime buildDate { get; set; }
        public string buildSource { get; set; }
        public decimal estimatedMSRP { get; set; }
        public string wmiCountry { get; set; }
        public string wmiManufacturer { get; set; }
        public IEnumerable<Vehicle> vehicles { get; set; }
        public IEnumerable<ExteriorColor> exteriorColors { get; set; }
        public IEnumerable<InteriorColor> interiorColors { get; set; }
        public IEnumerable<Feature> features { get; set; }
        public IEnumerable<TechSpec> techSpecs { get; set; }
        public IEnumerable<Package> packages { get; set; }
        public string[] optionCodes { get; set; }
        public IEnumerable<OptionCodeContent> optionCodeContent { get; set; }
    }

    public class TechSpec
    {
        public int id { get; set; }
        public string key { get; set; }
        public int sectionId { get; set; }
        public int subSectionId { get; set; }
        public string sectionName { get; set; }
        public string name { get; set; }
        public string nameNoBrand { get; set; }
        public string description { get; set; }
        public int rankingValue { get; set; }
        public IEnumerable<Style> styles { get; set; }
    }

    public class Package
    {
        public int id { get; set; }
        public string key { get; set; }
        public int sectionId { get; set; }
        public int subSectionId { get; set; }
        public string sectionName { get; set; }
        public string name { get; set; }
        public string nameNoBrand { get; set; }
        public string description { get; set; }
        public int rankingValue { get; set; }
        public IEnumerable<Style> styles { get; set; }
        public IEnumerable<OptionDetail> optionDetails { get; set; }
    }

    public class OptionDetail
    {
        public string optionCode { get; set; }
        public decimal msrp { get; set; }
        public string[] content { get; set; }
    }

    public class OptionCodeContent
    {
        public string optionCode { get; set; }
        public decimal msrp { get; set; }
        public string optionDescription { get; set; }
        public string installCause { get; set; }
    }

    public class Feature
    {
        public int id { get; set; }
        public string key { get; set; }
        public int sectionId { get; set; }
        public int subSectionId { get; set; }
        public string sectionName { get; set; }
        public string name { get; set; }
        public string nameNoBrand { get; set; }
        public string description { get; set; }
        public int rankingValue { get; set; }
        public IEnumerable<Style> styles { get; set; }
        public IEnumerable<BenefitStatement> benefitStatement { get; set; }

    }
    public class Style
    {
        public int[] styleIds { get; set; }
        public string installCause { get; set; }
        public bool isStandard { get; set; }
    }

    public class BenefitStatement
    {
        public string title { get; set; }
        public string definition { get; set; }
        public string statement { get; set; }
    }

    public class ExteriorColor
    {
        public string genericDesc { get; set; }
        public string description { get; set; }
        public string colorCode { get; set; }
        public string installCause { get; set; }
        public int[] styles { get; set; }
        public string rgbValue { get; set; }
        public string rgbHexValue { get; set; }
        public int type { get; set; }
        public bool primary { get; set; }
    }

    public class InteriorColor
    {
        public string genericDesc { get; set; }
        public string description { get; set; }
        public string colorCode { get; set; }
        public string installCause { get; set; }
        public int[] styles { get; set; }
    }

    public class Vehicle
    {
        public int styleId { get; set; }
        public string styleDescription { get; set; }
        public string trim { get; set; }
        public decimal baseMSRP { get; set; }
        public decimal destinationCharge { get; set; }
        public string driveType { get; set; }
        public string bodyType { get; set; }
        public int standardCurbWeight { get; set; }
        public int standardPayload { get; set; }
        public string country { get; set; }
        public int standardGVWR { get; set; }
        public int standardTowingCapacity { get; set; }
        public string mfrModelCode { get; set; }
        public int doors { get; set; }
        public string[] segment { get; set; }
        public decimal wheelbase { get; set; }

    }
}